using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new ContextBlog())
            {
                var x = ctx.Database.Connection.ConnectionString;
                var tags = new List<Tag>()
                {
                    new Tag() { Name = "asdf"},
                    new Tag() { Name = "asdf1"}
                };

                var comments = new List<Comment>()
                {
                    new Comment() { Text = "asdasdasd", User = new User() { name = "patata"} },
                    new Comment() { Text = "uiggfgjjgd", User = new User() { name = "tomate"} }
                };

                var post = new Post() { Comments = comments, Tags = tags };
                ctx.Posts.Add(post);
                ctx.SaveChanges();
            }
        }
    }
}
