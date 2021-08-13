using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Company : IEntity
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Kategori Adı Giriniz")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Minimum 2 karakter giriniz.")]

        public string companyName { get; set; }
    }
}
