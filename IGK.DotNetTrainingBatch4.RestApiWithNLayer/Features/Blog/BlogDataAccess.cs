using IGK.DotNetTrainingBatch4.RestApiWithNLayer.Db;
using IGK.DotNetTrainingBatch4.RestApiWithNLayer.Models;

namespace IGK.DotNetTrainingBatch4.RestApiWithNLayer.Features.Blog
{
    public class BlogDataAccess
    {
        private readonly AppDbContext _context;

        public BlogDataAccess()
        {
            _context = new AppDbContext();
        }

        public List<BlogModel> GetBlogs()
        {
            var lst = _context.Blogs.ToList();
            return lst;
        }

        public BlogModel GetBlogs(int id)
        {
            var item = _context.Blogs.FirstOrDefault( x=> x.BlogID == id);
            return item;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            _context.Blogs.Add(requestModel);
            var result = _context.SaveChanges();
            return result;
        }

        public int UpdateBlog(int id, BlogModel requestModel)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogID == id);
            if (item is null) return 0;

            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogTitle = requestModel.BlogTitle;
            item.BlogContent = requestModel.BlogContent;

            var result = _context.SaveChanges();
            return result;
        }

        public int DeleteBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogID == id);
            if (item is null) return 0;

            _context.Blogs.Remove(item); 

            var result = _context.SaveChanges();
            return result;
        }
    }
}
