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
    public class SizeCreateCommand : IRequest<ProductSize>
    {
        public string Name { get; set; }
        public string SmallName { get; set; }

        public class SizeCreateCommandHandler : IRequestHandler<SizeCreateCommand, ProductSize>
        {
            private readonly BigOnDbContext db;

            public SizeCreateCommandHandler(BigOnDbContext db)
            {
                this.db = db;
            }


            public async Task<ProductSize> Handle(SizeCreateCommand request, CancellationToken cancellationToken)
            {
                var model = new ProductSize();
                model.Name = request.Name;
                model.SmallName = request.SmallName;

                await db.ProductSizes.AddAsync(model, cancellationToken);
                await db.SaveChangesAsync(cancellationToken);

                return model;
            }

        }
    }
}