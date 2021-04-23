using Microsoft.EntityFrameworkCore;
using SMA.ApplicationServices.DTOs;
using SMA.ApplicationServices.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.ManagementServices
{
    public class ImageManagementService : BaseManagementService
    {
        public IEnumerable<ImageDto> GetAll()
        {
            return _context.Images.AsNoTracking().AsEnumerable().ToImageDtos();
        }

        public ImageDto GetById(int id)
        {
            return _context.Images.AsNoTracking().SingleOrDefault(x => x.Id == id).ToImageDto();

        }

        

        public ImageDto GetByCreatedByUserId(int CreatedByUserId)
        {
            return _context.Images.AsNoTracking().SingleOrDefault(x => x.CreatedByUserId == CreatedByUserId).ToImageDto();
        }

        public string GetImagePathByImageId(int imageId)
        {
           ImageDto img =  _context.Images.AsNoTracking().SingleOrDefault(x => x.Id == imageId).ToImageDto();

            string ImgPath = img.ImageUrl;

            return ImgPath;
        }


        public int Save(ImageDto imageDto)
        {
            try
            {
                _context.Images.Add(imageDto.ToImageEntity());
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public int Delete(int id)
        {
            try
            {
                var image = _context.Images.Find(id);
                if (image == null)
                    return -1;

                _context.Images.Remove(image);
                _context.SaveChanges();
                return 1;
            }
            catch (Exception)
            {
                return -1;
            }
        }




    }
}
