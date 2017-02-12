using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Service.Models
{
    public class MemberModel
    {
        public Guid MemberId { get; set; }
        public DateTime MemberSince { get; set; }
        [StringLength(10)]
        public string PhoneNumber { get; set; }
        [StringLength(100)]
        public string FirstName { get; set; }
        [StringLength(100)]
        public string LastName { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string AddressLine1 { get; set; }
        [StringLength(100)]
        public string AddressLine2 { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        [StringLength(2)]
        public string State { get; set; }
        [StringLength(5)]
        public string Zip { get; set; }

        public bool HasChildren { get; set; }
        public bool HasParent { get; set; }
        public Guid? ParentMemberId { get; set; }



    }
}
