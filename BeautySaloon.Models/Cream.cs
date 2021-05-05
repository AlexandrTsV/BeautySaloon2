using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Models
{
    public class Cream : CosmeticProductExpiration
    {
        /* public Cream(float price, int quantity) : base()
        {
            name = "Cream";
            this.price = price;
            this.quantity = quantity;
        } */
        override public DateTime GetExpirationTime()
        {
            return productionTime + new TimeSpan(0, 0, 5);
        }
        public override CosmeticProduct Construct()
        {
            return new Cream() { id = this.id, name = this.name, price = this.price, quantity = this.quantity, deliveryTime = this.deliveryTime, type = this.type };
        }
    }
}
