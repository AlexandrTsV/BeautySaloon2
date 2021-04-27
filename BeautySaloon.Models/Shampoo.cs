using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Models
{
    class Shampoo : CosmeticProductLongTerm
    {
        /* public Shampoo(float price, int quantity) : base()
        {
            name = "Shampoo";
            this.price = price;
            this.quantity = quantity;
        } */
        override public DateTime GetExpirationTime()
        {
            return base.GetExpirationTime();
        }
        public override CosmeticProduct Construct()
        {
            return new Shampoo() { id = this.id, name = this.name, price = this.price, quantity = this.quantity, deliveryTime = this.deliveryTime, type = this.type };
        }
    }
}
