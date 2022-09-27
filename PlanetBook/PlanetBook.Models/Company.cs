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
        public string Name { get; set; }
        [DisplayName("Đường")]
        public string StreetAddress { get; set; }
        [DisplayName("Thành phố")]
        public string City { get; set; }
        [DisplayName("Quận")]
        public string State { get; set; }
        [DisplayName("Mã bưu điện")]
        public string PostalCode { get; set; }
        [DisplayName("Liên lạc")]
        public string PhoneNumber { get; set; }
        [DisplayName("Ủy quyền")]
        public bool IsAuthorizedCompany { get; set; }
    }
}
