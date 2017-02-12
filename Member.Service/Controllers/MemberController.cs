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
                Zip = model.Zip
            });
            await _dbContext.SaveChangesAsync().ConfigureAwait(false);
            return Ok(model);
        }

        [HttpGet]
        [Route("lookupbyphone/{phonenumber}")]
        public async Task<IHttpActionResult> LookupMemberByPhone(string phonenumber)
        {
            var members = await _dbContext.Members.Where(t => t.PhoneNumber == phonenumber).ToListAsync();
            return Ok(members.Select(t => new MemberModel
            {
                AddressLine1 = t.AddressLine2,
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
