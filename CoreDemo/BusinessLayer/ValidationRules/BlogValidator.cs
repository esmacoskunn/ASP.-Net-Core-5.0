using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator:AbstractValidator<Blog>
    {
        public BlogValidator()  
        {
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş geçilemez ");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriğini boş geçilemez ");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görselini boş geçilemez ");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Lütfen 150 karekterden daha az vrei girşi yapın ");
            RuleFor(x => x.BlogTitle).MinimumLength(5).WithMessage("Lütfen 5 karekterden daha fazla vrei girşi yapın ");

        }
    }
}
