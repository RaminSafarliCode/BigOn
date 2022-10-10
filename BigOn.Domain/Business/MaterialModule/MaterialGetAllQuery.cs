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
    public class MaterialGetAllQuery : IRequest<List<ProductMaterial>>
    {

        public class MaterialGetAllQueryHandler : IRequestHandler<MaterialGetAllQuery, List<ProductMaterial>>
        {
            private readonly BigOnDbContext db;

            public MaterialGetAllQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public async Task<List<ProductMaterial>> Handle(MaterialGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ProductMaterials.Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}