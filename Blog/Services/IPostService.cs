using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog.Models;

namespace Blog.Services
{
    public interface IPostService
    {
        Post Add(Post post);
        int Update();
        int Delete(Post post);
        Post Get(int id);
    }
}
