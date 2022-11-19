using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;
using SuperMarketApi.Models.Enum;

namespace SuperMarketApi.Models
{
    public class Contact
    {

        public void load(string name, string surname, string phoneNo, string alternatePhoneNo,
            string emailAddress, string address, string city, string state, string zip)
        {
            Name = name;
            Surname = surname;
            PhoneNo = phoneNo;
            AlternatePhoneNo = alternatePhoneNo;
            Email = emailAddress;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
        }

        [Display(Name = "Status")]
        public bool IsActive { get; set; }

        [Display(Name = "Status")]
        public string StatusText
        {
            get
            {
                if (IsActive == true) return "Active";
                else return "Not in Use";
            }
        }
        public int Id { get; set; }

        public int ContactTypeId { get; set; }

        [NotMapped]
        public string ContactTypeDesc
        {
            get
            { return System.Enum.GetName(typeof(ContactType), ContactTypeId); }
        }

        public string Name { get; set; }

        public string FirstName { get; set; }
        public string Surname { get; set; }

        [DataType(DataType.EmailAddress)]
        //[EmailAddress(ErrorMessage = "Enter Valid Email Address")]
        public string Email { get; set; }

        [RegularExpression("^[0-9 &-,.()]*$", ErrorMessage = "Please Enter Valid Phone Number")]
        public string PhoneNo { get; set; }

        public string AlternatePhoneNo { get; set; }

        //[DataType(DataType.EmailAddress)]
        //public string AlternateEmail { get; set; }

        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        [Display(Name = "Pincode")]
        public string Zip { get; set; }

        public string Notes { get; set; }

        [Display(Name = "Joining Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public System.DateTime? StartDate { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public System.DateTime? CreatedDate { get; set; }

        //[ForeignKey("User")]
        //public int? CreatedBy { get; set; }
        //public virtual Contact User { get; set; }

        public string AadharId { get; set; }

        public string TaxIdentNumber { get; set; }

        public byte[] IdProof { get; set; }

        public byte[] AltIdProof { get; set; }

        public string GetName()
        {
            return FirstName + " " + Surname;
        }

        public void SetName()
        {
            Name = FirstName + " " + Surname;
        }

        [NotMapped]
        [DataType(DataType.Date)]
        public string StartDateStr
        {
            get;
            set;
        }

        [NotMapped]
        [DataType(DataType.Date)]
        public string DueDateStr
        {
            get;
            set;
        }

        public class DTO
        {
            public int ContactId { get; set; }
            public string Name { get; set; }
            public int ContactTypeId { get; set; }
            public bool IsActive { get; set; }
        }

        [ForeignKey("ParentContact")]
        public int? ParentContactId { get; set; }
        public virtual Contact ParentContact { get; set; }

        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}
