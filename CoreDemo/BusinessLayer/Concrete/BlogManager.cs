using BusinessLayer.Abstract;
using DataAccsessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _BlogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _BlogDal = blogDal;
        }

      
        public List<Blog> GetBlogListWithCategory() 
        {
            return _BlogDal.GetListWithCategory(); 

        }


        public List<Blog> GetListWithCategoryByWriterbm(int id)  
        {
            return _BlogDal.GetListWithCategoryByWriter(id);
        }


        public Blog TGetById(int id) 
        {
            return _BlogDal.GetByID(id);
        } 

        public List<Blog> GetBlogByID(int id)
        {
            return _BlogDal.GetListAll(x => x.BlogID == id);  
        }
       
        public List<Blog> GetList()  
        {
            return _BlogDal.GetListAll(); 
        }

        public List<Blog> GetLast3Blog()
        {
            return _BlogDal.GetListAll().Take(3).ToList(); 
        }


        public List<Blog> GetBlogListByWriter(int id) 
        {
            return _BlogDal.GetListAll(x => x.WriterID == id);
        }



        public void TAdd(Blog t)   
        {
            _BlogDal.Insert(t);  
        }  


        public void TDelete(Blog t) 
        {
            _BlogDal.Delete(t);
        }

        public void TUpdate(Blog t) 
        {
            _BlogDal.Update(t);
        }

        public List<Blog> GetBlogsListWithCategory()
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetBlogsListWithWriter(int id)
        {
            throw new NotImplementedException();
        }
    }
}
