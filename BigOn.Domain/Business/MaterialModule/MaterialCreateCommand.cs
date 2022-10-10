using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BigOn.Domain.Business.MaterialModule
{
    public class MaterialCreateCommand : IRequest<ProductMaterial>
    {
        public string Name { get; set; }
        public class MaterialCreateCommandHandler : IRequestHandler<MaterialCreateCommand, ProductMaterial>
        {
            private readonly BigOnDbContext db;

            public MaterialCreateCommandHandler(BigOnDbContext db)
            {
                this.db = db;
            }


            public async Task<ProductMaterial> Handle(MaterialCreateCommand request, CancellationToken cancellationToken)
            {
                var model = new ProductMaterial();
                model.Name = request.Name;

                await db.ProductMaterials.AddAsync(model, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return model;
            }
        }
    }
}