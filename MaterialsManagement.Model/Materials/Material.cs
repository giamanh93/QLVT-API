using System;

namespace MaterialsManagement.Model.Materials
{
    public class Material
    {
        public Material()
        {

        }

        public Material(long id, string? name, string? unit, int? priceSell, int totalWeight, int totalWeightSell, int totalWeightRenaining, int totalInvestAmount, string? supplier, int? priceBuy, bool? active, string? note)
        {
            Id = id;
            Name = name;
            Unit = unit;
            Price_Sell = priceSell;
            Total_Weight = totalWeight;
            Total_Weight_Sell = totalWeightSell;
            Total_Weight_Renaining = totalWeightRenaining;
            Total_Invest_Amount = totalInvestAmount;
            this.supplier = supplier;
            Price_Buy = priceBuy;
            Active = active;
            Note = note;
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Unit { get; set; }
        public int? Price_Sell { get; set; }
        public int Total_Weight { get; set; }
        public int Total_Weight_Sell { get; set; }
        public int Total_Weight_Renaining { get; set; }
        public int Total_Invest_Amount { get; set; }
        public string? supplier { get; set; }
        public int? Price_Buy { get; set; }
        public bool? Active { get; set; }
        public string? Note { get; set; }



    }
}
