using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Category : IEntity
    {
        [Key]
       
        public int id { get; set; }
        [Required(ErrorMessage = "Kategori Adı Giriniz")]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "Minimum 2 karakter giriniz.")]
        public string categoryName { get; set; }
        public Boolean isActive { get; set; }

    }

}
