using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Models
{
    public interface IExpiration
    {
        public DateTime GetExpirationTime();
        public bool IsExpired();
    }
}
