using Microsoft.EntityFrameworkCore;
using SMA.ApplicationServices.DTOs;
using SMA.ApplicationServices.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.ManagementServices
{
    public class CommentManagementService : BaseManagementService
    {
        public IEnumerable<CommentDto> GetAll()
        {
            return _context.Comments.AsNoTracking().AsEnumerable().ToCommentDtos();
        }

        public CommentDto GetById(int id)
        {
            return _context.Comments.Find(id).ToCommentDto();
        }

       

        public int Save(CommentDto commentDto)
        {
            try
            {
                _context.Comments.Add(commentDto.ToCommentEntity());
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
                var comment = _context.Comments.Find(id);
                if (comment == null)
                    return -1;

                _context.Comments.Remove(comment);
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
