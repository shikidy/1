using Microsoft.VisualStudio.TestTools.UnitTesting;
using ValidationLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ValidationLib.Tests
{
    [TestClass()]
    public class DBvalidationTests
    {
        [TestMethod()]
        public void PositiveCostValidationTest() => Assert.IsTrue(DBvalidation.CostValidation(100));

        [TestMethod()]

        public void NegativeValidationTest() => Assert.IsFalse(DBvalidation.CostValidation(-100));


        [TestMethod()]
        public void PositiveFloatValidationTest() => Assert.IsTrue(DBvalidation.CostValidation(100.0f));

        [TestMethod()]
        public void NegativeFloatValidationTest() => Assert.IsFalse(DBvalidation.CostValidation(-100.0f));


        [TestMethod()]
        public void OverDiscountValidationTest() => Assert.IsFalse(DBvalidation.DiscountValidation(101));

        [TestMethod()]
        public void LowerDiscountValidationTest() => Assert.IsFalse(DBvalidation.DiscountValidation(-1));


        [TestMethod()]
        public void GoodDiscountValidationTest() => Assert.IsTrue(DBvalidation.DiscountValidation(10));
    }
}