using Microsoft.Extensions.Hosting;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace BigOn.Domain.AppCode.Extensions
{
    public static partial class Extension
    {
        public static string GetImagePhysicalPath(this IHostEnvironment env, string fileName)
        {
            return Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", fileName);
        }

        public static void ArchieveImage(this IHostEnvironment env, string fileName)

        {
            var imageActualPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", fileName);
            if (File.Exists(imageActualPath))
            {
                var imageNewPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", $"archive-{DateTime.Now:yyyyMMddHHmmss}-{fileName}");
                File.Move(imageActualPath, imageNewPath);
            }
        }
    }
}
