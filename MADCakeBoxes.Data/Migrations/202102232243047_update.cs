namespace MADCakeBoxes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cake", "UserId", c => c.Guid(nullable: false));
            AddColumn("dbo.Cake", "Icing", c => c.String());
            AddColumn("dbo.Cart", "CakeId", c => c.Int(nullable: false));
            AddColumn("dbo.GiftBox", "GiftBoxUser", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.GiftBox", "GiftBoxUser");
            DropColumn("dbo.Cart", "CakeId");
            DropColumn("dbo.Cake", "Icing");
            DropColumn("dbo.Cake", "UserId");
        }
    }
}
