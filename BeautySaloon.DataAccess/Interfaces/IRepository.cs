using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BeautySaloon.DataAccess.Interfaces
{
    public interface IRepository<ID, Entity>
    {
        public void Add(Entity entity);
        public Entity GetById(ID id);
        public void Delete(Entity entity);
        public void Update(Entity entity);
        public List<Entity> GetAll();
    }
}
