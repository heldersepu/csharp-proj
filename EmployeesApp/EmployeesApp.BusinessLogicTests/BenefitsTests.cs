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
                Predicate = "Name.StartsWith(\"A\")"
            },
            new BenefitsDiscount {
                Percentage = percent * 2,
                Predicate = "Name.EndsWith(\"0\")"
            },
            new BenefitsDiscount {
                Percentage = percent * 3,
                Predicate = "Name.Contains(\"123\")"
            },
            new BenefitsDiscount {
                Percentage = percent * 4,
                Predicate = "Age > 65"
            },
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
        public void DiscountTest1()
        {
            var benef = new Benefits(cost, discounts);
            double discount = benef.Discount(new Employee { Name = "Anton" });
            Assert.AreEqual(discount, percent);
            discount = benef.Discount(new Employee { Name = "Mary" });
            Assert.AreEqual(discount, 0);
        }

        [TestMethod()]
        public void DiscountTest2()
        {
            var benef = new Benefits(cost, discounts);
            double discount = benef.Discount(new Employee { Name = "abc0" });
            Assert.AreEqual(discount, percent * 2);            
        }

        [TestMethod()]
        public void DiscountTest3()
        {
            var benef = new Benefits(cost, discounts);
            double discount = benef.Discount(new Employee { Name = "x123y" });
            Assert.AreEqual(discount, percent * 3);
        }

        [TestMethod()]
        public void DiscountTest4()
        {
            var benef = new Benefits(cost, discounts);
            double discount = benef.Discount(new Employee { Age = 78 });
            Assert.AreEqual(discount, percent * 4);
        }
    }
}