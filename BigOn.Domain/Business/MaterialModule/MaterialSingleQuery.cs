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
    public class MaterialSingleQuery : IRequest<ProductMaterial>
    {
        public int Id { get; set; }
        public class MaterialSingleQueryHandler : IRequestHandler<MaterialSingleQuery, ProductMaterial>
        {
            private readonly BigOnDbContext db;

            public MaterialSingleQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public Task<ProductMaterial> Handle(MaterialSingleQuery request, CancellationToken cancellationToken)
            {
                var data = db.ProductMaterials
                    .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);

                return data;
            }
        }
    }
}