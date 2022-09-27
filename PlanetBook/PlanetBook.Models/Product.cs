using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace PlanetBook.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tiêu đề")]
        [DisplayName("Tiêu đề")]
        public string Title { get; set; }
        [DisplayName("Mô tả")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập ISBN")]
        public string ISBN { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tác giả")]
        [DisplayName("Tác giả")]
        public string Author { get; set; }
        [Required]
        [Range(1, 1000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Price { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Price50 { get; set; }
        [Required]
        [Range(1, 1000)]
        public double Price100 { get; set; }
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn thể loại")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Required(ErrorMessage = "Vui lòng chọn loại bìa")]
        public int CoverTypeId { get; set; }
        [ForeignKey("CoverTypeId")]
        public CoverType CoverType { get; set; }
    }
}
