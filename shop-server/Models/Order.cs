using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace shop_server.Models
{
    public class Order
    {
        public int ID { get; set; }

        [Display(Name = "Заказчик")]
        public string Customer { get; set; }

        [Required]    
        public string ProdIds { get; set; }

        [Display(Name = "Адрес доставки")]
        public string DeliveryAddress { get; set; }

    
        [Display(Name = "Статус")]
        public string Status { get; set; }
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
