using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;
using Blog.Context;
using Blog.Services;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new ContextBlog())
            {
                var postDAO = new PostService(ctx);
                postDAO.Add(GeneratePost());

                // Bueno
                //var result = post.Comments.Select(c => c.User.name);

                // Malo
                //foreach (var comment in post.Comments)
                //{
                //    Console.WriteLine(comment.User.name);
                //}


            }
        }

        public static Post GeneratePost()
        {
            return new Post() { Comments = GenerateComments(), Tags = GenerateTags() };
        }

        public static List<Comment> GenerateComments()
        {
            return new List<Comment>()
                {
                    new Comment() { Description = "asdasdasd", User = new User() { Description = "patata"} },
                    new Comment() { Description = "uiggfgjjgd", User = new User() { Description = "tomate"} }
                };
        }

        public static List<Tag> GenerateTags()
        {
            return new List<Tag>()
                {
                    new Tag() { Description = "asdf"},
                    new Tag() { Description = "asdf1"}
                };
        }
    }
}
