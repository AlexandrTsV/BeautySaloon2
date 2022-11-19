using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace BeautySaloon.Models
{
    public class CosmeticProductExpiration : CosmeticProduct, IExpiration
    {
        public TimeSpan StorageTime { get; set; }
        public CosmeticProductExpiration() : base()
        {
        }

    }

}
