using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NMock;
using Blog.Context;
using Blog.Services;
using System.Data.Entity;

namespace PruebaUnitaria.ORM
{
    [TestClass]
    public class PostDAOTest
    {
        private MockFactory _factory = new MockFactory();

        [TestCleanup]
        public void Cleanup()
        {
            _factory.VerifyAllExpectationsHaveBeenMet();
            _factory.ClearExpectations();
        }

        [TestMethod]
        public void UpdatePost()
        {
            var contextBlog = _factory.CreateMock<IContextBlog>();
            IPostService postService = new PostService(contextBlog.MockObject);
            var oldPost = postService.Get(1);

            oldPost.Description = "Hello";
            var result = postService.Update();

            Assert.AreEqual("Hello", oldPost.Description);
            Assert.AreEqual(1, result);
        }

    }
}
