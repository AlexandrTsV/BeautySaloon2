using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Models
{
    class Pomade : CosmeticProductLongTerm
    {
        /* public Pomade(float price, int quantity) : base()
        {
            name = "Pomade";
            this.price = price;
            this.quantity = quantity;
        } */
        override public DateTime GetExpirationTime()
        {
            return base.GetExpirationTime();
        }
        public override CosmeticProduct Construct()
        {
            return new Pomade() { id = this.id, name = this.name, price = this.price, quantity = this.quantity, deliveryTime = this.deliveryTime, type = this.type };
        }
    }
}
