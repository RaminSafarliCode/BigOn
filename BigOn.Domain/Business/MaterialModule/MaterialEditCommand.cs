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
    public class MaterialEditCommand : IRequest<ProductMaterial>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public class MaterialEditCommandHandler : IRequestHandler<MaterialEditCommand, ProductMaterial>
        {
            private readonly BigOnDbContext db;

            public MaterialEditCommandHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductMaterial> Handle(MaterialEditCommand request, CancellationToken cancellationToken)
            {
                var data = await db.ProductMaterials
                    .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);
                if (data == null)
                {
                    return null;
                }

                data.Name = request.Name;
                await db.SaveChangesAsync(cancellationToken);

                return data;
            }
        }
    }

}