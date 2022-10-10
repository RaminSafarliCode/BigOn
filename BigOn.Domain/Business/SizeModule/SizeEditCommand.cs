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
    public class SizeEditCommand : IRequest<ProductSize>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public class SizeEditCommandHandler : IRequestHandler<SizeEditCommand, ProductSize>
        {
            private readonly BigOnDbContext db;

            public SizeEditCommandHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductSize> Handle(SizeEditCommand request, CancellationToken cancellationToken)
            {
                var data = await db.ProductSizes
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