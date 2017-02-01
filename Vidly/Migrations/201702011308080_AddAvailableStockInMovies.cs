namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAvailableStockInMovies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "StockAvailable", c => c.Int(nullable: false));
            Sql("UPDATE dbo.Movies SET StockAvailable = Stock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "StockAvailable");
        }
    }
}
