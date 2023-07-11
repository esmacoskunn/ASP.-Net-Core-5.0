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
    public class ContactManager : IContactService
    {
        IContactDal _ıcontactDal;

        public ContactManager(IContactDal ıContactDal)
        {
            _ıcontactDal = ıContactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _ıcontactDal.Insert(contact);
        }
    }
}
