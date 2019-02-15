using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shop_server.Models
{
    public class Category
    {
        public int ID { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Наименование пиктограммы")]
        public string Icon { get; set; }
    }
    public enum ProductCategories
    {
        Телефоны, Компьютеры, Принтеры, Телевизоры, Фото, Гаджеты, Игры
    }
}
