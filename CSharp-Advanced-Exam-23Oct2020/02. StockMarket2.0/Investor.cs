using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private List<Stock> portfolio;
        public Investor(string fulLN,string eA,decimal mTIND, string brokername)
        {
            FullName = fulLN;
            EmailAddress = eA;
            MoneyToInvest = mTIND;
            BrokerName = brokername;
            Portfolio = new List<Stock>();
        }
        public int Count => Portfolio.Count;
        public List<Stock> Portfolio { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public decimal MoneyToInvest { get; set; }
        public string BrokerName { get; set; }
        

        public void BuyStock(Stock stock)
        {
            if(stock.MarketCapitalization >10000 && MoneyToInvest>= stock.PricePerShare)
            {
                Portfolio.Add(stock);
                MoneyToInvest -= stock.PricePerShare;
            }
        }
        public string SellStock(string companyName, decimal sellPrice)
        {
            if(!Portfolio.Any(c=>c.CompanyName == companyName))
                return $"{companyName} does not exist.";
            else 
            {
                Stock stock = Portfolio.First(s => s.CompanyName == companyName);

                if(sellPrice<stock.PricePerShare)
                {
                    return $"Cannot sell {companyName}.";
                }
                else
                {
                    MoneyToInvest += sellPrice;
                    Portfolio.RemoveAll(s => s.CompanyName == companyName);
                    return $"{companyName} was sold.";
                }
            }

        }

        public Stock FindStock(string companyName)
        {
            return Portfolio.FirstOrDefault(s => s.CompanyName == companyName);
        }
        public Stock FindBiggestCompany()
        {
            if (Portfolio.Any())
            {
                return Portfolio.OrderByDescending(s => s.MarketCapitalization).First();
            }
            else
                return null;
        }

        public string InvestorInformation()
        {
           

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var item in Portfolio)
            {
                sb.AppendLine(item.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
