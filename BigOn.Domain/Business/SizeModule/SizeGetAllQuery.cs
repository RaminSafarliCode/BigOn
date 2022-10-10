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

namespace BigOn.Domain.Business.SizeModule
{
    public class SizeGetAllQuery : IRequest<List<ProductSize>>
    {

        public class SizeGetAllQueryHandler : IRequestHandler<SizeGetAllQuery, List<ProductSize>>
        {
            private readonly BigOnDbContext db;

            public SizeGetAllQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public async Task<List<ProductSize>> Handle(SizeGetAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.ProductSizes.Where(m => m.DeletedDate == null)
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}