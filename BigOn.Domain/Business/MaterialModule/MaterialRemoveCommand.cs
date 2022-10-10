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
    public class MaterialRemoveCommand : IRequest<ProductMaterial>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public class MaterialRemoveCommandHandler : IRequestHandler<MaterialRemoveCommand, ProductMaterial>
        {
            private readonly BigOnDbContext db;

            public MaterialRemoveCommandHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductMaterial> Handle(MaterialRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.ProductMaterials
                    .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);
                if (data == null)
                {
                    return null;
                }

                data.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);

                return data;
            }
        }
    }
}