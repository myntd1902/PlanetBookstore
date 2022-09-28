using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace PlanetBook.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên công ty")]
        [DisplayName("Tên công ty")]
        public string Name { get; set; }
        [DisplayName("Số nhà/ Đường")]
        public string StreetAddress { get; set; }
        [DisplayName("Thành phố/ Tỉnh")]
        public string City { get; set; }
        [DisplayName("Quận/ Huyện")]
        public string State { get; set; }
        [DisplayName("Mã bưu điện")]
        public string PostalCode { get; set; }
        [DisplayName("SĐT")]
        public string PhoneNumber { get; set; }
        [DisplayName("Ủy quyền")]
        public bool IsAuthorizedCompany { get; set; }
    }
}
