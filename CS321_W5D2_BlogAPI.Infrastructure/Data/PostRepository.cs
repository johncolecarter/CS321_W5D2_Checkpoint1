using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W5D2_BlogAPI.Core.Models;
using CS321_W5D2_BlogAPI.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace CS321_W5D2_BlogAPI.Infrastructure.Data
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _dbContext;

        public PostRepository(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Post Get(int id)
        {
            return _dbContext.Posts
                .Include(p => p.Blog)
                .Include(p => p.Blog.User)
                .SingleOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetBlogPosts(int blogId)
        {
            return _dbContext.Posts
                .Include(b => b.Blog.User)
                .Include(b => b.Blog)
                .Include(b => b.BlogId)
                .Where(b => b.Id == blogId)
                .ToList();
        }

        public Post Add(Post Post)
        {
            _dbContext.Posts.Add(Post);
            _dbContext.SaveChanges();

            return Post;
        }

        public Post Update(Post Post)
        {
            var existingPost = _dbContext.Posts.Find(Post.Id);

            if (existingPost == null) return null;

            _dbContext.Entry(existingPost)
                .CurrentValues
                .SetValues(Post);

            _dbContext.Posts.Update(existingPost);
            _dbContext.SaveChanges();

            return existingPost;
        }

        public IEnumerable<Post> GetAll()
        {
            return _dbContext.Posts
                .Include(p => p.Blog)
                .ToList();
        }

        public void Remove(int id)
        {
            var post = _dbContext.Posts.FirstOrDefault(p => p.Id == id);

            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }

    }
}
