namespace MADCakeBoxes.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecake : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cake", "Flavor", c => c.String());
            AlterColumn("dbo.Cake", "Toppings", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cake", "Toppings", c => c.String(nullable: false));
            AlterColumn("dbo.Cake", "Flavor", c => c.String(nullable: false));
        }
    }
}
