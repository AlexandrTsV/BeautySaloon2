using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Models
{
    public class Balm : CosmeticProductLongTerm
    {
        /* public Balm(float price, int quantity) : base()
        {
            name = "Balm";
            this.price = price;
            this.quantity = quantity;
        } */
        override public DateTime GetExpirationTime()
        {
            return productionTime + new TimeSpan(20, 0, 0, 0);
        }
        public override CosmeticProduct Construct()
        {
            return new Balm() { id = this.id, name = this.name, price = this.price, quantity = this.quantity, deliveryTime = this.deliveryTime, type = this.type };
        }
    }
}
