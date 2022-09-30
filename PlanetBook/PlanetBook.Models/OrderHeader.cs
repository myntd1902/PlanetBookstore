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
    public class OrderHeader
    {
        [Key]
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime ShippingDate { get; set; }
        [Required]
        public double OrderTotal { get; set; }
        public string TrackingNumber { get; set; }
        public string Carrier { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime PaymentDueDate { get; set; }
        public string TransactionId { get; set; }
        [DisplayName("SĐT")]
        public string PhoneNumber { get; set; }
        [DisplayName("Số nhà/ Đường")]
        public string StreetAddress { get; set; }
        [DisplayName("Thành phố/ Tỉnh")]
        public string City { get; set; }
        [DisplayName("Quận/ Huyện")]
        public string State { get; set; }
        [DisplayName("Mã bưu điện")]
        public string PostalCode { get; set; }
        public string Name { get; set; }
    }
}
