﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BeautySaloon.Mappers
{
    public class SaloonMapper : Interfaces.IMapperToEntity<Entities.Saloon, Models.Saloon>, Interfaces.IMapperToModel<Entities.Saloon, Models.Saloon>
    {
        public SaloonMapper()
        {
        }
        public Entities.Saloon ModelToEntity(Models.Saloon model)
        {
            Entities.Saloon saloon = new Entities.Saloon();
            saloon.Storage = new Collection<Entities.SaloonProduct>();
            saloon.ID = model.id;

            Interfaces.IMapperToEntity<Entities.CosmeticProduct, Models.CosmeticProduct> productMapper = new CosmeticProductMapper();

            var uof = new DataAccess.UnitOfWork
            {
                db = new DataAccess.BeautySaloonDbContext()
            };
            var dc = new DataAccess.CosmeticProductRepository(uof);
            uof.CosmeticProducts = dc;

            foreach (var product in model.storage)
            {
                Entities.SaloonProduct tmp = new Entities.SaloonProduct { CosmeticProduct = dc.GetById(productMapper.ModelToEntity(product).ID), CosmeticProductID = productMapper.ModelToEntity(product).ID, Saloon = saloon, SaloonID = saloon.ID, Quantity = product.Quantity };
                saloon.Storage.Add(tmp);
            }

            return saloon;
        }

        public Models.Saloon EntityToModel(Entities.Saloon entity)
        {
            Models.Saloon saloon = new Models.Saloon();
            saloon.id = entity.ID;
            saloon.storage = new List<Models.CosmeticProduct>();

            Interfaces.IMapperToModel<Entities.CosmeticProduct, Models.CosmeticProduct> productMapper = new CosmeticProductMapper();

            foreach (var product in entity.Storage)
            {
                var p = productMapper.EntityToModel(product.CosmeticProduct);
                p.Quantity = product.Quantity;
                saloon.storage.Add(p);
            }
            return saloon;
        }
    }
}
