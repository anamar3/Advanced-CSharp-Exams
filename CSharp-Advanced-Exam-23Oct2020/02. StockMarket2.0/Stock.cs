using System;
using System.Collections.Generic;
using System.Text;

namespace StockMarket
{
    public class Stock
    {
        public Stock(string compName,string dir,decimal PPS, int toNSh)
        {
            CompanyName = compName;
            Director = dir;
            PricePerShare = PPS;
            TotalNumberOfShares = toNSh;
            MarketCapitalization = toNSh * PPS;
        }
        public string CompanyName { get; set; }
        public string Director { get; set; }
        public decimal PricePerShare { get; set; }
        public int TotalNumberOfShares { get; set; }
        public decimal MarketCapitalization { get; set; }


        public override string ToString()
        {
           
                StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Company: {CompanyName}");
            sb.AppendLine($"Director: {Director}");
            sb.AppendLine($"Price per share: ${PricePerShare}");
            sb.AppendLine($"Market capitalization: ${MarketCapitalization}");
            return sb.ToString().TrimEnd();
        }
    }
}
