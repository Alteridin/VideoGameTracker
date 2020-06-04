namespace GameTracker.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievement",
                c => new
                    {
                        AchievementID = c.Int(nullable: false, identity: true),
                        AchievementName = c.String(nullable: false),
                        AchievementNotes = c.String(),
                        AchievementCompleted = c.Boolean(nullable: false),
                        VideoGameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AchievementID)
                .ForeignKey("dbo.VideoGame", t => t.VideoGameID, cascadeDelete: true)
                .Index(t => t.VideoGameID);
            
            CreateTable(
                "dbo.VideoGame",
                c => new
                    {
                        VideoGameID = c.Int(nullable: false, identity: true),
                        OwnerID = c.Guid(nullable: false),
                        VideoGameName = c.String(nullable: false),
                        VideoGameGenre = c.Int(nullable: false),
                        VideoGameNotes = c.String(),
                        TimesBeat = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VideoGameID);
            
            CreateTable(
                "dbo.Quest",
                c => new
                    {
                        QuestID = c.Int(nullable: false, identity: true),
                        QuestName = c.String(nullable: false),
                        QuestNotes = c.String(),
                        MainQuest = c.Boolean(nullable: false),
                        QuestComplete = c.Boolean(nullable: false),
                        VideoGameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestID)
                .ForeignKey("dbo.VideoGame", t => t.VideoGameID, cascadeDelete: true)
                .Index(t => t.VideoGameID);
            
            CreateTable(
                "dbo.Boss",
                c => new
                    {
                        BossID = c.Int(nullable: false, identity: true),
                        BossName = c.String(nullable: false),
                        BossNotes = c.String(),
                        BossBeaten = c.Boolean(nullable: false),
                        VideoGameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BossID)
                .ForeignKey("dbo.VideoGame", t => t.VideoGameID, cascadeDelete: true)
                .Index(t => t.VideoGameID);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        InventoryID = c.Int(nullable: false, identity: true),
                        InventoryItem = c.String(nullable: false),
                        ItemQuantity = c.Int(nullable: false),
                        ItemDescription = c.String(),
                        ItemAcquired = c.Boolean(nullable: false),
                        VideoGameID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InventoryID)
                .ForeignKey("dbo.VideoGame", t => t.VideoGameID, cascadeDelete: true)
                .Index(t => t.VideoGameID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Inventory", "VideoGameID", "dbo.VideoGame");
            DropForeignKey("dbo.Boss", "VideoGameID", "dbo.VideoGame");
            DropForeignKey("dbo.Achievement", "VideoGameID", "dbo.VideoGame");
            DropForeignKey("dbo.Quest", "VideoGameID", "dbo.VideoGame");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Inventory", new[] { "VideoGameID" });
            DropIndex("dbo.Boss", new[] { "VideoGameID" });
            DropIndex("dbo.Quest", new[] { "VideoGameID" });
            DropIndex("dbo.Achievement", new[] { "VideoGameID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Inventory");
            DropTable("dbo.Boss");
            DropTable("dbo.Quest");
            DropTable("dbo.VideoGame");
            DropTable("dbo.Achievement");
        }
    }
}
