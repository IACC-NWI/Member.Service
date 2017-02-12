namespace Member.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MemberTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        MemberId = c.Guid(nullable: false),
                        MemberSince = c.DateTime(nullable: false, storeType: "date"),
                        PhoneNumber = c.String(maxLength: 10),
                        FirstName = c.String(maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        AddressLine1 = c.String(maxLength: 100),
                        AddressLine2 = c.String(maxLength: 100),
                        City = c.String(maxLength: 50),
                        State = c.String(maxLength: 2),
                        Zip = c.String(maxLength: 5),
                        HasChildren = c.Boolean(nullable: false),
                        HasParent = c.Boolean(nullable: false),
                        ParentMemberId = c.Guid(),
                    })
                .PrimaryKey(t => t.MemberId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Member");
        }
    }
}
