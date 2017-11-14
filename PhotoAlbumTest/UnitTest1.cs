using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Net.Http;
using System.Threading;

namespace PhotoAlbumTest
{

    [TestClass]
    public class UnitTest1
    {
        private static HttpClient _client;

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/");
            _client.Timeout = TimeSpan.FromMilliseconds(1);
        }
        
        
        [TestMethod]
        public async Task TestGetContents()
        {
            var response = await _client.GetAsync("/photos?albumId=3");
            var result = await response.Content.ReadAsStringAsync();
            Assert.IsFalse(result.Length > 0);

        }

        [ClassCleanup]

        public static void ClassCleanup()
        {
            _client.Dispose();
        }

        [TestMethod]
        public async Task AlbumNumberNotExist()
        {
            PhotoAlbumLT.PhotoAlbum.ApiCall(20000000);
            Thread.Sleep(2000);

        }

        [TestMethod]
        public async Task AlbumNumberSuccess()
        {
            PhotoAlbumLT.PhotoAlbum.ApiCall(2);
            Thread.Sleep(2000);

        }
        /* Test Main Purpose is kinda pointless here.
        [TestMethod]
        public async Task TestMain()
        {
            
            PhotoAlbumLT.PhotoAlbum.Main(new string[] { });

        }
        */
        [TestMethod]
        public void TestConnectionString()
        {
            var c = new PhotoAlbumLT.Album();
            c.Id= 123;
            c.AlbumId = 123;
            c.thumbnailUrl = "abc";
            c.Title = "abc";
            c.url = "abc";
            Assert.AreEqual<string>("abc", c.thumbnailUrl);
            Assert.AreEqual<string>("abc", c.url);
            Assert.AreEqual<string>("abc", c.Title);
            Assert.AreEqual<int>(123, c.Id);
            Assert.AreEqual<int>(123, c.AlbumId);
            
        }
    }
}
