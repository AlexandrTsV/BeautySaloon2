using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Models
{
    public interface IExpiration
    {
        public TimeSpan StorageTime { get; set; }
    }
}
