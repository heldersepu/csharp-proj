using NLog;
using System;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;
using EmployeesApp.Framework.Interfaces;
using EmployeesApp.Models;

namespace EmployeesApp.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReportsController : ApiController
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Gets a report
        /// </summary>
        /// <param name="id">The unique report identifier</param>
        /// <returns>Returns the report data</returns>
        public IHttpActionResult Get(string id)
        {
            try
            {
                switch (id)
                {
                    case "AnnualBenefitsCost":
                        return Ok(AnnualBenefitsCost);
                    case "CumulativeMonthlyCost":
                        return Ok(MonthlyBenefitsCost);
                    case "CumulativeMonthlyChart":
                        return Ok(CumulativeMonthlyChart);
                    default:
                        return NotFound();
                }
            }
            catch (Exception e)
            {
                logger.Error(e);
                return InternalServerError(e);
            }
        }

        private IBenefits Benefits()
        {
            var cost = new BenefitsCostController().Get();
            var discounts = new BenefitsDiscountsController().Get();
            string file = AppDomain.CurrentDomain.BaseDirectory + "bin\\BusinessLogic.dll";
            Assembly assembly = Assembly.LoadFrom(file);
            Type type = assembly.GetType("EmployeesApp.BusinessLogic.Benefits");
            return (IBenefits)Activator.CreateInstance(type, cost, discounts);
        }

        private List<ReportNode> AnnualBenefitsCost
        {
            get
            {

                var report = new List<ReportNode>();
                var employees = new EmployeesController().Get();
                var benefits = Benefits();
                foreach (var employee in employees)
                {
                    var salary = employee.PaycheckAmount * employee.PaychecksPerYear;
                    var benefi = benefits.Deduction(employee);
                    report.Add(
                        new ReportNode
                        {
                            Name = employee.Name,
                            Salary = salary,
                            Benefits = benefi,
                            Total = salary - benefi
                        }
                    );
                }
                return report;
            }
        }

        private List<ReportNode> MonthlyBenefitsCost
        {
            get
            {
                double totalSalary = 0;
                double totalBenefits = 0;
                var employees = new EmployeesController().Get();
                var benefits = Benefits();
                foreach (var employee in employees)
                {
                    totalSalary += employee.PaycheckAmount * employee.PaychecksPerYear;
                    totalBenefits += benefits.Deduction(employee);
                }

                var report = new List<ReportNode>();
                DateTime date = new DateTime(2010, 01, 01);
                var sal_mnt = Math.Round(totalSalary / 12, 2);
                var ben_mnt = Math.Round(totalBenefits / 12, 2);

                for (int i = 1; i <= 11; i++)
                {
                    double salary = sal_mnt * i;
                    double benefi = ben_mnt * i;
                    report.Add(
                        new ReportNode
                        {
                            Name = date.ToString("MMMM"),
                            Salary = Math.Round(salary, 2),
                            Benefits = Math.Round(benefi, 2),
                            Total = Math.Round(salary - benefi,2)
                        }
                    );
                    date = date.AddMonths(1);
                }
                report.Add(
                    new ReportNode
                    {
                        Name = date.ToString("MMMM"),
                        Salary = totalSalary,
                        Benefits = totalBenefits,
                        Total = totalSalary - totalBenefits
                    }
                );
                return report;
            }
        }

        private ReportChart CumulativeMonthlyChart
        {
            get
            {
                var report = new ReportChart
                {
                    label = "Total",
                    data = new List<List<int>>()
                };

                int count = 1;
                foreach (var item in MonthlyBenefitsCost)
                {
                    var data = new List<int>();
                    data.Add(count);
                    data.Add((int)Math.Round(item.Total));
                    report.data.Add(data);
                    count++;
                }
                return report;
            }
        }
    }
}
