using Microsoft.EntityFrameworkCore;
using SMA.ApplicationServices.DTOs;
using SMA.ApplicationServices.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.ManagementServices
{
    public class PostManagementService : BaseManagementService
    {
        public IEnumerable<PostDto> GetAll()
        {
            return _context.Posts.AsNoTracking().AsEnumerable().ToPostDtos();
        }

        public PostDto GetById(int id)
        {
            return _context.Posts.Find(id).ToPostDto();
        }

      

        public int Save(PostDto postDto)
        {
            try
            {
                _context.Posts.Add(postDto.ToPostEntity());
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
                var post = _context.Posts.Find(id);
                if (post == null)
                    return -1;

                _context.Posts.Remove(post);
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
