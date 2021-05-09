using Microsoft.EntityFrameworkCore;
using SMA.ApplicationServices.DTOs;
using SMA.ApplicationServices.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SMA.Data.Repositories;

namespace SMA.ApplicationServices.ManagementServices
{
    public class CommentManagementService : BaseManagementService
    {
        private CommentRepository _repository;
        
        
        
        
        
        public IEnumerable<CommentDto> GetAll()
        {
            return _context.Comments.AsNoTracking().AsEnumerable().ToCommentDtos();
        }

        public CommentDto GetById(int id)
        {
            return _context.Comments.AsNoTracking().SingleOrDefault(x => x.Id == id).ToCommentDto();
        }

        public CommentDto GetByPostId(int id)
        {
            return _context.Comments.AsNoTracking().SingleOrDefault(x => x.PostId == id).ToCommentDto();
        }

        public int GetCommentsCountByPostId(int id)
        {
            return _context.Comments.Where(x => x.PostId == id).Count();
        }


        public CommentDto Edit(int id)
        {
            return _context.Comments.AsNoTracking().SingleOrDefault(x => x.Id == id).ToCommentDto();

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
