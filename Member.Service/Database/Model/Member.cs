using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Member.Service.Database.Model
{
    [Table("Member")]
    public class MemberDbModel
    {
        [Key]
        public Guid MemberId { get; set; }
        [Column(TypeName = "Date")]
        public DateTime MemberSince { get; set; }
        [MaxLength(10)]
        public string PhoneNumber { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]    
        public string AddressLine1 { get; set; }
        [MaxLength(100)]
        public string AddressLine2 { get; set; }
        [MaxLength(50)]
        public string City { get; set; }
        [MaxLength(2)]
        public string State { get; set; }
        [MaxLength(5)]
        public string Zip { get; set; }

        public bool HasChildren { get; set; }
        public bool HasParent { get; set; }
        public Guid? ParentMemberId { get; set; }
    }
}
