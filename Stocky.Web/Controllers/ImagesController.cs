using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Stocky.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocky.Web.Controllers
{
    public class ImagesController : BaseController<Image>
    {
        static readonly string contentPath = Path.Combine(Directory.GetCurrentDirectory(), $"");

        public ImagesController(AppDbContext context) : base(context, context.Images) { }

        [HttpGet("sync"), AllowAnonymous]
        public async Task<bool> SyncImageAsync()
        {
            if (Directory.Exists(contentPath) == false) Directory.CreateDirectory(contentPath);
            var userImages = _dbSet.Where(x => x.User != null).Include(x => x.User).ToList();
            var imagePath = $"wwwroot/media";

            // Copy user avatar
            foreach (var image in userImages)
            {
                var fileDir = $"{contentPath}/{imagePath}/{image.SharedKey}/avatars";
                if (Directory.Exists(fileDir) == false) Directory.CreateDirectory(fileDir);

                var ext = Path.GetExtension(image.Name);
                var fileName = $"{image.Id}{ext}";

                var storePath = $"{fileDir}/{fileName}";
                image.Data.SaveOnDisk(storePath);
                //System.IO.File.WriteAllBytes(storePath, image.Data);

                image.ImageURL = $"{imagePath}/{image.SharedKey}/avatars/{fileName}";
                if (image.IsActive) image.User.AvatarURL = image.ImageURL;
            }

            //Todo: __:: copy product images

            //Todo: __:: Copy product documents
            try
            {
                _dbSet.UpdateRange(userImages);
                var res = await _context.SaveChangesAsync() > 0;
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
