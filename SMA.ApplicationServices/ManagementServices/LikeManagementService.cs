using Microsoft.EntityFrameworkCore;
using SMA.ApplicationServices.DTOs;
using SMA.ApplicationServices.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SMA.ApplicationServices.ManagementServices
{
        public class LikeManagementService : BaseManagementService
        {
            public IEnumerable<LikeDto> GetAll()
            {
                return _context.Likes.AsNoTracking().AsEnumerable().ToLikeDtos();
            }

            public LikeDto GetByPostId(int PostId)
            {
                return _context.Likes.Find(PostId).ToLikeDto();
            }

          

            public int Save(LikeDto likeDto)
            {
                try
                {
                    _context.Likes.Add(likeDto.ToLikeEntity());
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
                    var like = _context.Likes.Find(id);
                    if (like == null)
                        return -1;

                    _context.Likes.Remove(like);
                    _context.SaveChanges();
                    return 1;
                }
                catch (Exception)
                {
                    return -1;
                }
            }

        public int Edit(LikeDto dto)
        {
            try
            {
                _context.Likes.Add(dto.ToLikeEntity());
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

