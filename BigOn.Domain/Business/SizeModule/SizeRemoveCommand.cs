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
    public class SizeRemoveCommand : IRequest<ProductSize>
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public class SizeRemoveCommandHandler : IRequestHandler<SizeRemoveCommand, ProductSize>
        {
            private readonly BigOnDbContext db;

            public SizeRemoveCommandHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductSize> Handle(SizeRemoveCommand request, CancellationToken cancellationToken)
            {
                var data = await db.ProductSizes
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