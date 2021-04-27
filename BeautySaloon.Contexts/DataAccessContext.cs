using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Contexts
{
    public class DataAccessContext
    {
        public DataAccess.Interfaces.IBankRepository bankRepository { get; set; }
        public DataAccess.Interfaces.ICosmeticProductRepository cosmeticProductRepository { get; set; }
        public DataAccess.Interfaces.ISaloonRepository saloonRepository { get; set; }
    }
}
