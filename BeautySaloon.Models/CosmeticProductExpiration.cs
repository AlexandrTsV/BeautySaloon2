using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace BeautySaloon.Models
{
    abstract public class CosmeticProductExpiration : CosmeticProduct, IExpiration
    {
        protected CosmeticProductExpiration() : base()
        {

        }
        virtual public DateTime GetExpirationTime()
        {
            return productionTime + new TimeSpan(0, 0, 0, 5);
        }
        public override CosmeticProduct Construct()
        {
            return this;
        }
        public override int IsNeeded()
        {
            if (quantity < 10)
            {
                return 100 - quantity;
            }

            if (IsExpired())
            {
                return 50;
            }

            return 0;
        }
        public bool IsExpired()
        {
            if (GetExpirationTime() < DateTime.Now)
            {
                return true;
            }
            return false;
        }
    }

}
