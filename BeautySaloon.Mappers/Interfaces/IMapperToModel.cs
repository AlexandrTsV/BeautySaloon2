using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Mappers.Interfaces
{
    public interface IMapperToEntity<Entity, Model>
    {
        public abstract Entity ModelToEntity(Model model);
    }
}
