using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shop_server.Models
{
    public class Product
    {
        public int ID { get; set; }
        [Display(Name= "Наименование")]
        [MaxLength(25, ErrorMessage = "Не более 25 символов")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
      
        [MaxLength(200, ErrorMessage = "Не более 200 символов")]
        public string Description { get; set; }
        [Display(Name = "Рейтинг")]
        public int Rating { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        [Display(Name = "Категория")]
        public Category Category { get; set; }
        public bool HasImage { get; set; }
    }
}
