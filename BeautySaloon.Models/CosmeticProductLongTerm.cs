using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace BeautySaloon.Models
{
    abstract public class CosmeticProductLongTerm : CosmeticProduct, IExpiration
    {
        protected CosmeticProductLongTerm() : base()
        {

        }
        virtual public DateTime GetExpirationTime()
        {
            return new DateTime(2038, 1, 19, 3, 14, 18);
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
            return 0;
        }
        public bool IsExpired()
        {
            return false;
        }
    }

}