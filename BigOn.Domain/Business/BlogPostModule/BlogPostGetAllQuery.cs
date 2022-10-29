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

namespace BigOn.Domain.Business.BlogPostModule
{
    public class BlogPostGetAllQuery : IRequest<List<BlogPost>>
    {
        public class BlogPostGetAllQueryHandler : IRequestHandler<BlogPostGetAllQuery, List<BlogPost>>
        {
            private readonly BigOnDbContext db;

            public BlogPostGetAllQueryHandler(BigOnDbContext db)
            {
                this.db = db;
            }
            public async Task<List<BlogPost>> Handle(BlogPostGetAllQuery request, CancellationToken cancellationToken)
            {
                var posts = await db.BlogPosts
                .Where(bp => bp.DeletedDate == null && bp.PublishedDate != null)
                .ToListAsync(cancellationToken);

                return posts;
            }
        }
    }
}
