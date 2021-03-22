using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TheCakeShop.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

        [Required(ErrorMessage = "Please Enter your First Name")]
        [Display(Name ="First Name")]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please Enter your Last Name")]
        [Display(Name = "Last Name")]
        [StringLength(30)]
        public string LastName { get; set; }

        [Display(Name ="Address Line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please Enter your City")]
        public string City { get; set; }
                
        public string State { get; set; }

        [Required(ErrorMessage = "Please Enter your Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Please Enter your Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Please Enter your Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        //[RegularExpression(@"",ErrorMessage = "The Email address is not entered correctly")]
        public string Email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public decimal OrderTotal { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime OrderPlaced { get; set; }
    }
}
