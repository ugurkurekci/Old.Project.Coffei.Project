using Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(p => p.categoryName).MinimumLength(2).NotEmpty().WithMessage("Kategori Adı Boş Bırakılamaz");
            

        }
    }
}
