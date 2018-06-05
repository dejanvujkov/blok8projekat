namespace RentApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BranchOffices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImagePath = c.String(),
                        Address = c.String(),
                        Longtitue = c.Double(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Available = c.Boolean(nullable: false),
                        Type = c.String(),
                        Model = c.String(),
                        Description = c.String(),
                        ProductionYear = c.Int(nullable: false),
                        Manifacturer = c.String(),
                        Price = c.Int(nullable: false),
                        ImagePath = c.String(),
                        Service_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .Index(t => t.Service_Id);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TimeFrom = c.DateTime(nullable: false),
                        TimeTo = c.DateTime(nullable: false),
                        ReturnBranchOffice_Id = c.Int(),
                        Service_Id = c.Int(),
                        TakeAwayBranchOffice_Id = c.Int(),
                        User_Id = c.Int(),
                        Vehicle_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BranchOffices", t => t.ReturnBranchOffice_Id)
                .ForeignKey("dbo.Services", t => t.Service_Id)
                .ForeignKey("dbo.BranchOffices", t => t.TakeAwayBranchOffice_Id)
                .ForeignKey("dbo.AppUsers", t => t.User_Id)
                .ForeignKey("dbo.Vehicles", t => t.Vehicle_Id)
                .Index(t => t.ReturnBranchOffice_Id)
                .Index(t => t.Service_Id)
                .Index(t => t.TakeAwayBranchOffice_Id)
                .Index(t => t.User_Id)
                .Index(t => t.Vehicle_Id);
            
            AddColumn("dbo.AppUsers", "Name", c => c.String());
            AddColumn("dbo.AppUsers", "Surname", c => c.String());
            AddColumn("dbo.AppUsers", "Username", c => c.String());
            AddColumn("dbo.AppUsers", "Password", c => c.String());
            AddColumn("dbo.AppUsers", "Approved", c => c.Boolean(nullable: false));
            AddColumn("dbo.AppUsers", "ImagePath", c => c.String());
            AddColumn("dbo.AppUsers", "Email", c => c.String());
            AddColumn("dbo.AppUsers", "UserType", c => c.Int(nullable: false));
            AddColumn("dbo.Services", "Approved", c => c.Boolean(nullable: false));
            AddColumn("dbo.Services", "ImagePath", c => c.String());
            AddColumn("dbo.Services", "Description", c => c.String());
            AddColumn("dbo.Services", "Email", c => c.String());
            AddColumn("dbo.Services", "Manager_Id", c => c.Int());
            CreateIndex("dbo.Services", "Manager_Id");
            AddForeignKey("dbo.Services", "Manager_Id", "dbo.AppUsers", "Id");
            DropColumn("dbo.AppUsers", "FullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AppUsers", "FullName", c => c.String());
            DropForeignKey("dbo.Reservations", "Vehicle_Id", "dbo.Vehicles");
            DropForeignKey("dbo.Reservations", "User_Id", "dbo.AppUsers");
            DropForeignKey("dbo.Reservations", "TakeAwayBranchOffice_Id", "dbo.BranchOffices");
            DropForeignKey("dbo.Reservations", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Reservations", "ReturnBranchOffice_Id", "dbo.BranchOffices");
            DropForeignKey("dbo.Vehicles", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.BranchOffices", "Service_Id", "dbo.Services");
            DropForeignKey("dbo.Services", "Manager_Id", "dbo.AppUsers");
            DropIndex("dbo.Reservations", new[] { "Vehicle_Id" });
            DropIndex("dbo.Reservations", new[] { "User_Id" });
            DropIndex("dbo.Reservations", new[] { "TakeAwayBranchOffice_Id" });
            DropIndex("dbo.Reservations", new[] { "Service_Id" });
            DropIndex("dbo.Reservations", new[] { "ReturnBranchOffice_Id" });
            DropIndex("dbo.Vehicles", new[] { "Service_Id" });
            DropIndex("dbo.Services", new[] { "Manager_Id" });
            DropIndex("dbo.BranchOffices", new[] { "Service_Id" });
            DropColumn("dbo.Services", "Manager_Id");
            DropColumn("dbo.Services", "Email");
            DropColumn("dbo.Services", "Description");
            DropColumn("dbo.Services", "ImagePath");
            DropColumn("dbo.Services", "Approved");
            DropColumn("dbo.AppUsers", "UserType");
            DropColumn("dbo.AppUsers", "Email");
            DropColumn("dbo.AppUsers", "ImagePath");
            DropColumn("dbo.AppUsers", "Approved");
            DropColumn("dbo.AppUsers", "Password");
            DropColumn("dbo.AppUsers", "Username");
            DropColumn("dbo.AppUsers", "Surname");
            DropColumn("dbo.AppUsers", "Name");
            DropTable("dbo.Reservations");
            DropTable("dbo.Vehicles");
            DropTable("dbo.BranchOffices");
        }
    }
}
