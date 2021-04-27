using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySaloon.Contexts
{
    public class BusinessLogicContext
    {
        public BusinessLogic.Interfaces.IBankService bankService { get; set; }
        public BusinessLogic.Interfaces.ICosmeticProductService cosmeticProductService { get; set; }
        public BusinessLogic.Interfaces.ISaloonService saloonService { get; set; }

        public Mappers.Interfaces.IMapperToModel<Entities.Bank, Models.Bank> toModelBankMapper { get; set; }
        public Mappers.Interfaces.IMapperToModel<Entities.CosmeticProduct, Models.CosmeticProduct> toModelCosmeticProductMapper { get; set; }
        public Mappers.Interfaces.IMapperToModel<Entities.Saloon, Models.Saloon> toModelSaloonMapper { get; set; }
        public Mappers.Interfaces.IMapperToEntity<Entities.Bank, Models.Bank> toEntityBankMapper { get; set; }
        public Mappers.Interfaces.IMapperToEntity<Entities.CosmeticProduct, Models.CosmeticProduct> toEntityCosmeticProductMapper { get; set; }
        public Mappers.Interfaces.IMapperToEntity<Entities.Saloon, Models.Saloon> toEntitySaloonMapper { get; set; }
    }
}
