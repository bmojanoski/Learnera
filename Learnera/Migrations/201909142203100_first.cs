namespace Learnera.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Text = c.String(),
                    DateTime = c.DateTime(nullable: false),
                    CommentLikedByUser_Id = c.String(maxLength: 128),
                    Slide_Id = c.Int(),
                    Reply_Id = c.Int(),
                    CommentAuthor_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CommentLikedByUser_Id)
                .ForeignKey("dbo.Slides", t => t.Slide_Id)
                .ForeignKey("dbo.Replies", t => t.Reply_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CommentAuthor_Id)
                .Index(t => t.CommentLikedByUser_Id)
                .Index(t => t.Slide_Id)
                .Index(t => t.Reply_Id)
                .Index(t => t.CommentAuthor_Id);

            CreateTable(
                "dbo.AspNetUsers",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(),
                    LastName = c.String(),
                    Email = c.String(maxLength: 256),
                    EmailConfirmed = c.Boolean(nullable: false),
                    PasswordHash = c.String(),
                    SecurityStamp = c.String(),
                    PhoneNumber = c.String(),
                    PhoneNumberConfirmed = c.Boolean(nullable: false),
                    TwoFactorEnabled = c.Boolean(nullable: false),
                    LockoutEndDateUtc = c.DateTime(),
                    LockoutEnabled = c.Boolean(nullable: false),
                    AccessFailedCount = c.Int(nullable: false),
                    UserName = c.String(nullable: false, maxLength: 256),
                    Reply_Id = c.Int(),
                    Comment_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Replies", t => t.Reply_Id)
                .ForeignKey("dbo.Comments", t => t.Comment_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Reply_Id)
                .Index(t => t.Comment_Id);

            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    UserId = c.String(nullable: false, maxLength: 128),
                    ClaimType = c.String(),
                    ClaimValue = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.Replies",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DateTime = c.DateTime(nullable: false),
                    Text = c.String(),
                    Comment_Id = c.Int(),
                    ReplyAuthor_Id = c.String(maxLength: 128),
                    ReplyLikedByUser_Id = c.String(maxLength: 128),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comments", t => t.Comment_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReplyAuthor_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReplyLikedByUser_Id)
                .Index(t => t.Comment_Id)
                .Index(t => t.ReplyAuthor_Id)
                .Index(t => t.ReplyLikedByUser_Id);

            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                {
                    LoginProvider = c.String(nullable: false, maxLength: 128),
                    ProviderKey = c.String(nullable: false, maxLength: 128),
                    UserId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);

            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                {
                    UserId = c.String(nullable: false, maxLength: 128),
                    RoleId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);

            CreateTable(
                "dbo.Subjects",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Professor = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Presentations",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    name = c.String(),
                    Subject_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .Index(t => t.Subject_Id);

            CreateTable(
                "dbo.Slides",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    ImageUrl = c.String(),
                    Presentation_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Presentations", t => t.Presentation_Id)
                .Index(t => t.Presentation_Id);

            CreateTable(
                "dbo.AspNetRoles",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");

            CreateTable(
                "dbo.SubjectApplicationUsers",
                c => new
                {
                    Subject_Id = c.Int(nullable: false),
                    ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => new { t.Subject_Id, t.ApplicationUser_Id })
                .ForeignKey("dbo.Subjects", t => t.Subject_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Subject_Id)
                .Index(t => t.ApplicationUser_Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUsers", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.Comments", "CommentAuthor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Replies", "ReplyLikedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Comments", "CommentLikedByUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubjectApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubjectApplicationUsers", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Presentations", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Slides", "Presentation_Id", "dbo.Presentations");
            DropForeignKey("dbo.Comments", "Slide_Id", "dbo.Slides");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUsers", "Reply_Id", "dbo.Replies");
            DropForeignKey("dbo.Replies", "ReplyAuthor_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Replies", "Comment_Id", "dbo.Comments");
            DropForeignKey("dbo.Comments", "Reply_Id", "dbo.Replies");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.SubjectApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SubjectApplicationUsers", new[] { "Subject_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Slides", new[] { "Presentation_Id" });
            DropIndex("dbo.Presentations", new[] { "Subject_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Replies", new[] { "ReplyLikedByUser_Id" });
            DropIndex("dbo.Replies", new[] { "ReplyAuthor_Id" });
            DropIndex("dbo.Replies", new[] { "Comment_Id" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "Comment_Id" });
            DropIndex("dbo.AspNetUsers", new[] { "Reply_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Comments", new[] { "CommentAuthor_Id" });
            DropIndex("dbo.Comments", new[] { "CommentLikedByUser_Id" });
            DropIndex("dbo.Comments", new[] { "Slide_Id" });
            DropIndex("dbo.Comments", new[] { "Reply_Id" });
            DropTable("dbo.SubjectApplicationUsers");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Slides");
            DropTable("dbo.Presentations");
            DropTable("dbo.Subjects");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Replies");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Comments");
        }
    }
}