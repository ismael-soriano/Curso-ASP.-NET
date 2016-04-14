using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Context;

namespace Blog.Services
{
    public class PostService : IPostService
    {
        readonly IContextBlog _contextBlog;

        public PostService(IContextBlog contextBlog)
        {
            if (null == contextBlog)
            {
                throw new ArgumentNullException("ctx");
            }
            _contextBlog = contextBlog;
        }

        public Post Add(Post post) {
            _contextBlog.Posts.Add(post);
            SaveChanges();
            return new Post();        
        }

        public int Delete(Post post)
        {
            _contextBlog.Posts.Remove(post);
            return SaveChanges();
        }

        public int Update()
        {
            return SaveChanges();
        }

        public Post Get(int id)
        {
            return _contextBlog.Posts.Where(c => c.Id == id).ToList().FirstOrDefault();
        }

        private int SaveChanges()
        {
            return _contextBlog.SaveChanges();
        }
    }
}
