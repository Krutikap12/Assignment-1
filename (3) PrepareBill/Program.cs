using System;
using System.Collections.Generic;
namespace PrepareBill_3_
{

    public enum CommodityCategory
    {
        Furniture,
        Grocery,
        Service
    }
    public class Commodity
    {
        public Commodity(CommodityCategory category, string commodityName, int commodityQuantity, double commodityPrice)
        {
            Category = category;
            CommodityName = commodityName;
            CommodityQuantity = commodityQuantity;
            CommodityPrice = commodityPrice;
        }
        public CommodityCategory Category { get; set; }
        public string CommodityName { get; set; }
        public int CommodityQuantity { get; set; }
        public double CommodityPrice { get; set; }
    }
    public class PrepareBill
    {
        private readonly IDictionary<CommodityCategory, double> _taxRates;

        public PrepareBill()
        {
            _taxRates = new Dictionary<CommodityCategory, double>();
        }

        public void SetTaxRates(CommodityCategory category, double taxRate)
        {
            if (!(_taxRates.ContainsKey(category)))
            {
                _taxRates.Add(category, taxRate);
            }
        }
        public double CalculateBillAmount(IList<Commodity> items)
        {
            double price = 0;
            double total = 0;
            double tax = 0;
            foreach (var item in items)
            {
                if (!(_taxRates.ContainsKey(item.Category)))
                {
                    throw new ArgumentException();
                }
                else
                {
                    price = item.CommodityPrice * item.CommodityQuantity;
                    tax = ((item.CommodityPrice * _taxRates[item.Category]) / 100) * item.CommodityQuantity;
                }
                total = price + tax;
            }
            return total;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            var commodities = new List<Commodity>()
        {
            new Commodity(CommodityCategory.Furniture,"Bed", 2, 50000),
            new Commodity(CommodityCategory.Grocery,"Flour", 5,80),
            new Commodity(CommodityCategory.Furniture,"Bed", 8, 8500),

        };
            PrepareBill prepareBill = new PrepareBill();
            prepareBill.SetTaxRates(CommodityCategory.Furniture, 18);
            prepareBill.SetTaxRates(CommodityCategory.Grocery, 5);
            prepareBill.SetTaxRates(CommodityCategory.Service, 12);

            var billAmount = prepareBill.CalculateBillAmount(commodities);
            Console.WriteLine(billAmount);

        }
    }
}
