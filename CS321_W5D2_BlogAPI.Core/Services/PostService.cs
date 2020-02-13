﻿using System;
using System.Collections.Generic;
using CS321_W5D2_BlogAPI.Core.Models;

namespace CS321_W5D2_BlogAPI.Core.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IBlogRepository _blogRepository;
        private readonly IUserService _userService;

        public PostService(IPostRepository postRepository, IBlogRepository blogRepository, IUserService userService)
        {
            _postRepository = postRepository;
            _blogRepository = blogRepository;
            _userService = userService;
        }

        public Post Add(Post newPost)
        {
            var currentUser = _userService.CurrentUserId;
            var currentBlog = _blogRepository.Get(newPost.BlogId);

            if(currentUser == currentBlog.UserId)
            {
                newPost.DatePublished = DateTime.Now;
                return _postRepository.Add(newPost);
            }

            throw new Exception("You can only add on your own blog.");
        }

        public Post Get(int id)
        {
            return _postRepository.Get(id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _postRepository.GetAll();
        }
        
        public IEnumerable<Post> GetBlogPosts(int blogId)
        {
            return _postRepository.GetBlogPosts(blogId);
        }

        public void Remove(int id)
        {
            var post = this.Get(id);
            if(_userService.CurrentUserId == post.Blog.UserId)
            {
                _postRepository.Remove(id);
            }
            throw new Exception("You can only delete your own posts.");
        }

        public Post Update(Post updatedPost)
        {
            var currentPost = _userService.CurrentUserId;

            if(currentPost == updatedPost.Blog.UserId)
            {
                return _postRepository.Update(updatedPost);
            }

            throw new Exception("You can only update your own posts.");
        }

    }
}
