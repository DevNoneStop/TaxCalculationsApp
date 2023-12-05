using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculatorWeb.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaxCalculatorWeb.Models;

namespace TaxCalculatorWeb.Controllers.Tests
{
    [TestClass()]
    public class EmployeeControllerTests
    {


        /* 
         
        This unittest is testing the Tax Calculation for 3 different catetories:
             - Progressive Tax with Postal Code = 7441 OR 1000
             - Flat Value Tax with Postal Code = A100
             - Flat Value Tax with Postal Code = 7000

        The income amounts used may vary based on the employees income and postal code.

         */

        #region Calculate Prograssive Tax

        [TestMethod()]
        public void Calculate_PrograssiveTax_CorrectTax() //Returns the correct Tax amount
        {
            //Assign
            double income = 35000;
            string postalCode = "7441"; //Expected out is 4937.5

            //Act
            TaxCalculator taxCalculator = new TaxCalculator();
            var results = taxCalculator.GetTotalTaxedPerAmountPerPostalCode(income, postalCode);

            //Assert
            Assert.AreEqual(4937.5, results);
        }
        [TestMethod()]
        public void Calculate_PrograssiveTax_NotCorrectTax() //Returns wrong Tax amount
        {
            //Assign
            double income = 35000;
            string postalCode = "7441"; //Expected out is 4937.5

            //Act
            TaxCalculator taxCalculator = new TaxCalculator();
            var results = taxCalculator.GetTotalTaxedPerAmountPerPostalCode(income, postalCode);

            //Assert
            Assert.AreEqual(4937, results);
        } 
        #endregion

        #region  Calculate Flat Value Tax

        [TestMethod()]
        public void Calculate_FlatValueTax_CorrectTaxAmount() //Returns the correct Tax amount
        {
            //Assign
            double income = 25000;
            string postalCode = "A100"; //Expected out is 1250

            //Act
            TaxCalculator taxCalculator = new TaxCalculator();
            var results = taxCalculator.GetTotalTaxedPerAmountPerPostalCode(income, postalCode);

            //Assert
            Assert.AreEqual(1250, results);
        }
        [TestMethod()]
        public void Calculate_FlatValueTax_NotCorrectTaxAmount() //Returns wrong Tax amount
        {
            //Assign
            double income = 25000;
            string postalCode = "A100"; //Expected out is 1250

            //Act
            TaxCalculator taxCalculator = new TaxCalculator();
            var results = taxCalculator.GetTotalTaxedPerAmountPerPostalCode(income, postalCode);

            //Assert
            Assert.AreEqual(1251, results);
        }


        #endregion

        #region Calculate Flat Rate Tax

        [TestMethod()]
        public void Calculate_FlatRateTax_CorrectTaxAmount()//Returns the correct Tax amount
        {
            //Assign
            double income = 17000;
            string postalCode = "7000"; //Expected out is 850

            //Act
            TaxCalculator taxCalculator = new TaxCalculator();
            var results = taxCalculator.GetTotalTaxedPerAmountPerPostalCode(income, postalCode);

            //Assert
            Assert.AreEqual(850, results);
        }
        [TestMethod()]
        public void Calculate_FlatRateTax_NotCorrectTaxAmount() //Returns wrong Tax amount
        {
            //Assign
            double income = 17000;
            string postalCode = "7000"; //Expected out is 850

            //Act
            TaxCalculator taxCalculator = new TaxCalculator();
            var results = taxCalculator.GetTotalTaxedPerAmountPerPostalCode(income, postalCode);

            //Assert
            Assert.AreEqual(852, results); 
        }

        #endregion

    }
}