using PlanetBook.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanetBook.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            Count = 1;
        }
        [Key]
        public int Id { get; set; }
        [DisplayName("Nguời dùng")]
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        [DisplayName("Sản phẩm")]
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        [DisplayName("Số lượng")]
        [Range(1, 1000, ErrorMessage ="Vui lòng giá trị từ 1 đến 1000")]
        public int Count { get; set; }
        [NotMapped]
        public double Price { get; set; } 
    }
}
