using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Mappers.Interfaces
{
    public interface IMapperToModel<Entity, Model>
    {
        public abstract Model EntityToModel(Entity entity);
    }
}
