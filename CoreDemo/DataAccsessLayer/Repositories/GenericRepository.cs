using DataAccsessLayer.Abstract;
using DataAccsessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccsessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class  //tüm sınıflar için ortak olan metotların görevlerini yerine geitrme zmanı...
    {
        public void Delete(T t)
        {
            using var c = new Context();
            c.Remove(t);
            c.SaveChanges();
        }

        public T GetByID(int id)
        {
            using var c = new Context();
            return c.Set<T>().Find(id);   //fin metodu primary key olanı bulur. metodun özelliğidir.id si 1 olan primary key olanı bulur.
        }

        public List<T> GetListAll()
        {
            using var c = new Context();
          
            return c.Set<T>().ToList();   //BURADA DİREKT LİSLEME İŞLEMİ OLDU....
        }

        public void Insert(T t)
        {
            using var c = new Context();
            c.Add(t);
            c.SaveChanges();
        }

        public List<T> GetListAll(Expression<Func<T, bool>> filter) //bir clasın içindekileri şartlı getirecek.  
            //ŞÖYLE BİR ŞEY VAR ENTİTİYLER BELİRLENİR.VE BUNLARIN EKLEME SİLME GÜNCELLEME LİSTELME İŞLEMİ SQL TARAFINDA OLUR. 

        {
            using var c = new Context();  ///NEREDEN ŞARLI VERİ GETİRECEK. SQL DE TABİKİ VERİLER ORAYA YAZILIYOR ÇÜNKÜ...
            return c.Set<T>().Where(filter).ToList();  //BURADA İSE ŞARTLI LİSTELEME İŞLEMİ OLDU....FİLTERDEN GELEN DEĞERE GÖRE LİSTELE DEMEK..
        }

        public void Update(T t)
        {
            using var c = new Context();
            c.Update(t);
            c.SaveChanges();
        }
    }
}
