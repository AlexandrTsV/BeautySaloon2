using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Models
{
    public class Gel : CosmeticProductLongTerm
    {
        /* public Gel(float price, int quantity) : base()
        {
            name = "Gel";
            this.price = price;
            this.quantity = quantity;
        } */
        override public DateTime GetExpirationTime()
        {
            return base.GetExpirationTime();
        }
        public override CosmeticProduct Construct()
        {
            return new Gel() { id = this.id, name = this.name, price = this.price, quantity = this.quantity, deliveryTime = this.deliveryTime, type = this.type };
        }
    }
}
