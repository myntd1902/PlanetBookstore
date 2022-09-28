using Microsoft.AspNetCore.Identity;
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
    public class ApplicationUser : IdentityUser
    {
        [Required(ErrorMessage = "Vui lòng nhập tên")]
        [DisplayName("Tên")]
        public string Name { get; set; }
        [DisplayName("Số nhà/ Đường")]
        public string StreetAddress { get; set; }
        [DisplayName("Thành phố/ Tỉnh")]
        public string City { get; set; }
        [DisplayName("Quận/ Huyện")]
        public string State { get; set; }
        [DisplayName("Mã bưu điện")]
        public string PostalCode { get; set; }
        [DisplayName("Công ty")]
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        public Company Company { get; set; }
        [NotMapped]
        [DisplayName("Vai trò")]
        public string Role { get; set; }

    }
}
