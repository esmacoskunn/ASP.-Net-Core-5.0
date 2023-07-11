using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface INewsLetterService   //bunlarda artık generic dahil etmemiş...
    {
        void AddNewsLetter(NewsLetter newsLetter);



    }
}
