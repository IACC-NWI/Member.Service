using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Member.Service.Database;
using Member.Service.Models;
using Entities = Member.Service.Database.Model;

namespace Member.Service.Controllers
{
    [RoutePrefix("api/member")]
    public class MemberController : ApiController
    {
        private readonly IMemberDbContext _dbContext;

        public MemberController(IMemberDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("addMember")]
        public async Task<IHttpActionResult> AddMember(MemberModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _dbContext.Members.Add(new Entities.MemberDbModel
            {
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2,
                City = model.City,
                FirstName = model.FirstName,
                HasChildren = false,
                HasParent = model.HasParent,
                LastName = model.LastName,
                MemberId = model.MemberId,
                MemberSince = model.MemberSince,
                ParentMemberId = model.ParentMemberId,
                PhoneNumber = model.PhoneNumber,
                State = model.State,
                Zip = model.Zip,
                Email = model.Email
            });
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return Ok(model);
        }

        [HttpPost]
        [Route("updatemember")]
        public async Task<IHttpActionResult> UpdateMember(MemberModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var memberToUpdate = await _dbContext.Members.FirstAsync(t => t.MemberId == model.MemberId);
            memberToUpdate.AddressLine1 = model.AddressLine1;
            memberToUpdate.AddressLine2 = model.AddressLine2;
            memberToUpdate.City = model.City;
            memberToUpdate.FirstName = model.FirstName;
            memberToUpdate.HasChildren = false;
            memberToUpdate.HasParent = model.HasParent;
            memberToUpdate.LastName = model.LastName;
            memberToUpdate.MemberId = model.MemberId;
            memberToUpdate.MemberSince = model.MemberSince;
            memberToUpdate.ParentMemberId = model.ParentMemberId;
            memberToUpdate.PhoneNumber = model.PhoneNumber;
            memberToUpdate.State = model.State;
            memberToUpdate.Zip = model.Zip;
            memberToUpdate.Email = model.Email;
            await _dbContext.SaveChangesAsync();
            return Ok(model);
        }

        [HttpGet]
        [Route("lookupbyid/{memberid}")]
        public async Task<IHttpActionResult> GetMemberById(Guid memberid)
        {
            var member = await _dbContext.Members.FirstOrDefaultAsync(t => t.MemberId == memberid);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(new MemberModel
            {
                AddressLine1 = member.AddressLine1,
                MemberId = member.MemberId,
                MemberSince = member.MemberSince,
                HasParent = member.HasParent,
                ParentMemberId = member.ParentMemberId,
                PhoneNumber = member.PhoneNumber,
                FirstName = member.FirstName,
                LastName = member.LastName,
                HasChildren = member.HasChildren,
                State = member.State,
                City = member.City,
                AddressLine2 = member.AddressLine2,
                Zip = member.Zip,
                Email = member.Email,
            });
        }
        [HttpGet]
        [Route("lookupbyphone/{phonenumber}")]
        public async Task<IHttpActionResult> LookupMemberByPhone(string phonenumber)
        {
            var members = await _dbContext.Members.Where(t => t.PhoneNumber == phonenumber).ToListAsync();
            return Ok(members.Select(t => new MemberModel
            {
                AddressLine1 = t.AddressLine1,
                MemberId = t.MemberId,
                MemberSince = t.MemberSince,
                HasParent = t.HasParent,
                ParentMemberId = t.ParentMemberId,
                PhoneNumber = t.PhoneNumber,
                FirstName = t.FirstName,
                LastName = t.LastName,
                HasChildren = t.HasChildren,
                State = t.State,
                City = t.City,
                AddressLine2 = t.AddressLine2,
                Zip = t.Zip,
                Email = t.Email,
            }).ToList());
        }

        [HttpGet]
        [Route("getallmembers")]
        public async Task<IHttpActionResult> GetAllMembers()
        {
            var members = await _dbContext.Members.ToListAsync();
            return Ok(members.Select(t => new MemberModel
            {
                AddressLine1 = t.AddressLine1,
                MemberId = t.MemberId,
                MemberSince = t.MemberSince,
                HasParent = t.HasParent,
                ParentMemberId = t.ParentMemberId,
                PhoneNumber = t.PhoneNumber,
                FirstName = t.FirstName,
                LastName = t.LastName,
                HasChildren = t.HasChildren,
                State = t.State,
                City = t.City,
                AddressLine2 = t.AddressLine2,
                Zip = t.Zip,
                Email = t.Email,
            }).ToList());
        }

        [HttpGet]
        [Route("getfamily/{parentMemberId}")]
        public async Task<IHttpActionResult> GetFamily(Guid parentMemberId)
        {
            var members = await _dbContext.Members.Where(t=>t.ParentMemberId == parentMemberId).ToListAsync();
            return Ok(members.Select(t => new MemberModel
            {
                AddressLine1 = t.AddressLine1,
                MemberId = t.MemberId,
                MemberSince = t.MemberSince,
                HasParent = t.HasParent,
                ParentMemberId = t.ParentMemberId,
                PhoneNumber = t.PhoneNumber,
                FirstName = t.FirstName,
                LastName = t.LastName,
                HasChildren = t.HasChildren,
                State = t.State,
                City = t.City,
                AddressLine2 = t.AddressLine2,
                Zip = t.Zip,
                Email = t.Email,
            }).ToList());
        }
    }
}
