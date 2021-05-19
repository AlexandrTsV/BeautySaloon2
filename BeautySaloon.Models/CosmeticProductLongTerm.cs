using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;


namespace BeautySaloon.Models
{
    public class CosmeticProductLongTerm : CosmeticProduct, IExpiration
    {
        public TimeSpan StorageTime { get; set; }
        public CosmeticProductLongTerm() : base()
        {
        }
    }

}