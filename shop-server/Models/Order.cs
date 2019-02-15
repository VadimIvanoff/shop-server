using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace shop_server.Models
{
    public class Order
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Заказчик")]
        public string Customer { get; set; }
        [Required]
        public IList<Product> Products { get; set; }
        [Required]
        [Display(Name = "Способ доставки")]
        public Delivery Delivery { get; set; }
        [Required]
        [Display(Name = "Статус")]
        public OrderStatus Status { get; set; }
    }
    public enum OrderStatus
    {
        Новый, Ждет_оплаты, Готов_к_выдаче, Отменен, Завершен, В_пути
    }
    public enum Delivery
    {
        Самовывоз, Доставка
    }
}
