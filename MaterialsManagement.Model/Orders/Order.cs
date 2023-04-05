

using System;
using System.Collections.Generic;

namespace MaterialsManagement.Model.Orders
{
    public class Order
    {
        public Order()
        {

        }

        public Order(long id, string? code, string? unit, DateTime createDate, DateTime updateDate, int amount, string note, long cusId, List<DetailsOrder> details)
        {
            Id = id;
            Code = code;
            Unit = unit;
            Create_Date = createDate;
            Update_Date = updateDate;
            Amount = amount;
            Note = note;
            Cust_Id = cusId;
            Details = details;
        }

        public long Id { get; set; }
        public string? Code { get; set; }
        public string? Unit { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Update_Date { get; set; }
        public int? Amount { get; set; }
        public string? Note { get; set; }
        public long? Cust_Id { get; set; }
        public List<DetailsOrder> Details { get; set; }

    }


    public class DetailsOrder
    {
        public DetailsOrder()
        {

        }

        public DetailsOrder(long id, long? orderId, DateTime createDate, DateTime updateDate, int? price, int? priceChange, int? quantity, int? amount, long? materialId, string? note)
        {
            Id = id;
            Order_Id = orderId;
            Create_Date = createDate;
            Update_Date = updateDate;
            Price = price;
            Price_Change = priceChange;
            Quantity = quantity;
            Material_Id = materialId;
            Note = note;
        }
        public long Id { get; set; }
        public long? Order_Id { get; set; }
        public DateTime Create_Date { get; set; }
        public DateTime Update_Date { get; set; }
        public int? Price { get; set; }
        public int? Price_Change { get; set; }
        public int? Quantity { get; set; }
        public int? Amount { get => ((Price_Change > 0) ? Price_Change : Price) * Quantity; }
        public long? Material_Id { get; set; }
        public string? Note { get; set; }
    }
}
