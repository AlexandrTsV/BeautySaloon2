using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloon.DataAccess.Interfaces
{
    public interface IRepository<Entity>
    {
        public void Add(Entity entity);
        public Entity GetById(int id);
        public void Delete(int id);
        public void Update(Entity entity);
        public List<Entity> GetAll();
    }
}
