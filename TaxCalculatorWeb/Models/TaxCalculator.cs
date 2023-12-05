using System.Reflection;

namespace TaxCalculatorWeb.Models
{
    public class TaxCalculator
    {

        //tax brackets limits 
        readonly double limit1 = 0,
        limit2 = 8350, limit3 = 8351,
        limit4 = 33950, limit5 = 33951,
        limit6 = 82250, limit7 = 82251,
        limit8 = 171550, limit9 = 171551,
        limit10 = 82250, limit11 = 82251;

        private double taxedAmount = 0;

        private double GetProgressiveTax(double Income)//progressive tax calculation
        {
            
            if ((Income >= limit1) && (Income <= limit2)) //10% tax rate
            {
                taxedAmount = Income * 0.1;
                return taxedAmount;
            }
            else if ((Income >= limit3) && (Income <= limit4)) 
            {
                
                taxedAmount = GetProgressiveTax(limit2) + ((Income - limit2) * 0.15); //15% tax rate
                return taxedAmount;
            }
            else if ((Income >= limit5) && (Income <= limit6)) 
            {
               
                taxedAmount = GetProgressiveTax(limit4) + ((Income - limit4) * 0.25);//25% tax rate
                return taxedAmount;
            }
            else if ((Income >= limit7) && (Income <= limit8)) 
            {
                
                taxedAmount = GetProgressiveTax(limit6) + ((Income - limit6) * 0.28);//28% tax rate rate
                return taxedAmount;
            }
            else if ((Income >= limit9) && (Income <= limit10)) 
            {
               
                taxedAmount = GetProgressiveTax(limit8) + ((Income - limit8) * 0.33);//33% tax  rate
                return taxedAmount;
            }
            else if ((Income > limit11)) 
            {
               
                taxedAmount = GetProgressiveTax(limit10) + ((Income - limit10) * 0.35); //above the limit 11 is taxed at 35%
                return taxedAmount;
            }
            return 0;
        }

        public double CalculateNetIncome(double Income = 0) //get the calculate net Income
        {
            Income = Income - GetProgressiveTax(Income);
            return Income;
        }

        public double GetTaxAmount(double Income) //get Taxed Income amount 
        {
            Income = GetProgressiveTax(Income);
            return Income;
        }

        public double GetFlatValueTax(double Income = 0) //get Flat value Taxed Income amount (the individual earns less than 200000 per year the tax will be at 5%)
        {
            double taxedAmount = 0;
            taxedAmount = Income * .05; //5% tax rate
            return taxedAmount;
        }

        public double GetFlatRateTax(double Income = 0) //getflat rate Taxed Income amount (All users pay 17.5% tax on their income)
        {
            double taxedAmount = 0;
            taxedAmount = Income  * 17.5; //17.5% tax rate
            return taxedAmount;
        }

        public double GetTotalTaxedPerAmountPerPostalCode(double Income, string PostalCode) //get calculated total taxed Income amount per postal code
        {
            double taxedIncomeAmount = 0;

            if (PostalCode == "7441" || PostalCode == "1000") //progressive tax
            {
                taxedIncomeAmount = GetProgressiveTax(Income);

            }
            else if (PostalCode == "A100" || Income <= 200000) //flat value
            {
                taxedIncomeAmount = GetFlatValueTax(Income);
            }
            else if (PostalCode == "7000") // Flat rate
            {
                taxedIncomeAmount = GetFlatRateTax(Income);
            }
            return taxedIncomeAmount;
        }


    }
}
