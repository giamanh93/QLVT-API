using System;

namespace MaterialsManagement.Model.Customers
{
    public class Customer
    {
        public Customer()
        {
            
        }

        public Customer(long id, string? name, string? phone, string? address, int totalPurchaseAmount, int totalPaidAmount, int totalDebtAmount, bool active, string? note)
        {
            Id = id;
            Name = name;
            Phone = phone;
            Address = address;
            Total_Purchase_Amount = totalPurchaseAmount;
            Total_Paid_Amount = totalPaidAmount;
            Total_Debt_Amount = totalDebtAmount;
            Active = active;
            this.Note = note;
        }

        public long Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public int Total_Purchase_Amount { get; set; }
        public int Total_Paid_Amount { get; set; }
        public int Total_Debt_Amount { get; set; }
        public bool Active { get; set; }
        public string? Note { get; set; }


    }
}
