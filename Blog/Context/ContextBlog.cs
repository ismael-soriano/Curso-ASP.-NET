using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blog.Configurations;
using Blog.Models;

namespace Blog.Context
{
    public class ContextBlog : DbContext, IContextBlog
    {
        public ContextBlog()
        {
            this.Configuration.LazyLoadingEnabled = true;
        }

        public IDbSet<Post> Posts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Properties<string>().Configure(c => c.HasColumnType("varchar"));
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());
            modelBuilder.Configurations.Add(new TagConfiguration());
            modelBuilder.Configurations.Add(new PostConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
