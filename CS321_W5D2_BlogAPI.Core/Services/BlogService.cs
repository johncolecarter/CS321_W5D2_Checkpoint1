using System;
using System.Collections.Generic;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.Core.Services
{
    public class BlogService : IBlogService
    {
        private readonly IBlogRepository _blogRepository;

        private readonly IUserService _userService;

        public BlogService(IBlogRepository blogRepository, IUserService userService)
        {
            _blogRepository = blogRepository;
            _userService = userService;
        }

        public Blog Add(Blog newBlog)
        {
            return _blogRepository.Add(newBlog);
        }

        public Blog Get(int id)
        {
            return _blogRepository.Get(id);
        }

        public IEnumerable<Blog> GetAll()
        {
            return _blogRepository.GetAll();
        }

        public void Remove(int id)
        {
            var userId = _blogRepository.Get(id).UserId;

            if(_userService.CurrentUserId == userId)
            {
                _blogRepository.Remove(id);
            } else
            {
                throw new Exception("You can only delete your own blogs,");
            }
        }

        public Blog Update(Blog updatedBlog)
        {
            var userId = _blogRepository.Get(updatedBlog.Id).UserId;

            if(_userService.CurrentUserId == userId)
            {
                return _blogRepository.Update(updatedBlog);
            } else
            {
                throw new Exception("You can only edit your own blogs.");
            }
        }
    }
}
