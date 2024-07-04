using IGK.DotNetTrainingBatch4.RestApiWithNLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace IGK.DotNetTrainingBatch4.RestApiWithNLayer.Features.Blog
{
    public class BusinessLogicBlog
    {
        private readonly BlogDataAccess _blogDataAccess;

        public BusinessLogicBlog()
        {
            _blogDataAccess = new BlogDataAccess();
        }

        public List<BlogModel> GetBlogs()
        {
            var lst = _blogDataAccess.GetBlogs();
            return lst;
        }

        public BlogModel GetBlogs(int id)
        {
            var item = _blogDataAccess.GetBlogs(id);
            return item;
        }

        public int CreateBlog(BlogModel requestModel)
        {
           
            var result = _blogDataAccess.CreateBlog(requestModel);
            return result;
        }

        public int UpdateBlog(int id, BlogModel requestModel)
        {
            var result = _blogDataAccess.UpdateBlog(id, requestModel);
            return result;
        }

        public int DeleteBlog(int id)
        {

            var result = _blogDataAccess.DeleteBlog(id);
            return result;
        }

        internal int PatchBlog(int id, BlogModel blog)
        {
            throw new NotImplementedException();
        }
    } 

}
