using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeesApp.Framework.DbSchema;

namespace EmployeesApp.BusinessLogic.Tests
{
    [TestClass()]
    public class BenefitsTests
    {
        const double empCost = 1000.00;
        const double depCost = 500.00;
        const double percent = 0.10;

        BenefitsCost cost = new BenefitsCost {
            Employee = empCost,
            Dependent = depCost,
        };
        List<BenefitsDiscount> discounts = new List<BenefitsDiscount> {
            new BenefitsDiscount {
                Percentage = percent,
                Type = "StartsWith",
                Value = "A",
            }
        };

        [TestMethod()]
        public void BenefitsTest()
        {
            var benef = new Benefits(cost, discounts);
            Assert.IsNotNull(benef);
        }

        [TestMethod()]
        public void DeductionTest()
        {
            var benef = new Benefits(cost, discounts);
            var anton = new Employee { Name = "Anton" };
            var deduct = benef.Deduction(anton);

            double result = (empCost * (1 - percent));
            Assert.AreEqual(deduct, result);

            anton.Dependents = new List<Dependent>
            {
                new Dependent { Name = "Mary"},
                new Dependent { Name = "Adam"},
            };
            deduct = benef.Deduction(anton);
            result += depCost + (depCost * (1 - percent));
            Assert.AreEqual(deduct, result);
        }

        [TestMethod()]
        public void DiscountTest()
        {
            var benef = new Benefits(cost, discounts);
            double discount = benef.Discount("Anton");
            Assert.AreEqual(discount, percent);
            discount = benef.Discount("Mary");
            Assert.AreEqual(discount, 0);
        }
    }
}