using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.DataAccess
{
    public class UnitOfWork : IDisposable
    {
        public BeautySaloonDbContext db { get; set; }
        public Interfaces.ICosmeticProductRepository CosmeticProducts { get; set; }
        public Interfaces.IBankRepository Banks { get; set; }
        public Interfaces.ISaloonRepository Saloons { get; set; }
        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
