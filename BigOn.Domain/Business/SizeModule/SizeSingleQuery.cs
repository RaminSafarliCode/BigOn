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
    public class SizeSingleQuery : IRequest<ProductSize>
    {
        public int Id { get; set; }
        public class SizeSingleQueryHandler : IRequestHandler<SizeSingleQuery, ProductSize>
        {
            private readonly BigOnDbContext db;

            public SizeSingleQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public Task<ProductSize> Handle(SizeSingleQuery request, CancellationToken cancellationToken)
            {
                var data = db.ProductSizes
                    .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedDate == null, cancellationToken);

                return data;
            }
        }
    }
}