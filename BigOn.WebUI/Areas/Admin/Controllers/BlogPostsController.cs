using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BigOn.Domain.Models.DataContexts;
using BigOn.Domain.Models.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using BigOn.Domain.AppCode.Extensions;

namespace BigOn.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogPostsController : Controller
    {
        private readonly BigOnDbContext _context;
        private readonly IHostEnvironment env;

        public BlogPostsController(BigOnDbContext context, IHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        // GET: Admin/BlogPosts
        public async Task<IActionResult> Index()
        {
            var data = await _context.BlogPosts
                .Where(bp=>bp.DeletedDate == null)
                .ToListAsync();
            return View(data);
        }

        // GET: Admin/BlogPosts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogPost == null)
            {
                return NotFound();
            }

            return View(blogPost);
        }

        // GET: Admin/BlogPosts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/BlogPosts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Body")] BlogPost blogPost, IFormFile image)
        {
            if (image == null)
            {
                ModelState.AddModelError("ImagePath", "An image is required");
            }

            if (ModelState.IsValid)
            {
                string extension = Path.GetExtension(image.FileName);
                blogPost.ImagePath = $"blogpost-{Guid.NewGuid().ToString().ToLower()}{extension}";

                string fullPath = env.GetImagePhysicalPath(blogPost.ImagePath);

                using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    image.CopyTo(fs);
                }


                _context.Add(blogPost);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(blogPost);
        }

        // GET: Admin/BlogPosts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogPost = await _context.BlogPosts.FindAsync(id);
            if (blogPost == null)
            {
                return NotFound();
            }
            return View(blogPost);
        }

        // POST: Admin/BlogPosts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Title,Body")] BlogPost model, IFormFile image)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var entity = _context.BlogPosts.FirstOrDefault(bp => bp.Id == id && bp.DeletedDate == null);

                if (entity == null)
                {
                    return NotFound();
                }

                entity.Title = model.Title;
                entity.Body = model.Body;

                if (image==null)
                {
                    goto end;
                }

                string extension = Path.GetExtension(image.FileName);
                model.ImagePath = $"blogpost-{Guid.NewGuid().ToString().ToLower()}{extension}";

                string fullPath = env.GetImagePhysicalPath(model.ImagePath);

                using (var fs = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
                {
                    image.CopyTo(fs);
                }

                //var oldPath = env.GetImagePhysicalPath(entity.ImagePath);

                env.ArchieveImage(entity.ImagePath);

                entity.ImagePath = model.ImagePath;

            end:
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            return View(model);
        }

        // POST: Admin/BlogPosts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var entity = await _context.BlogPosts.FirstOrDefaultAsync(bp=>bp.Id == id && bp.DeletedDate == null);

            if (entity == null)
            {
                return NotFound();
            }

            entity.DeletedDate = DateTime.UtcNow.AddHours(4);

            env.ArchieveImage(entity.ImagePath);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogPostExists(int id)
        {
            return _context.BlogPosts.Any(e => e.Id == id);
        }
    }
}
