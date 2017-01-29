namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDurationInMonthsInMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("EXEC sp_RENAME 'MembershipTypes.DurationinMonths', 'DurationInMonths', 'COLUMN'");
        }
        
        public override void Down()
        {
            Sql("EXEC sp_RENAME 'MembershipTypes.DurationInMonths', 'DurationinMonths', 'COLUMN'");
        }
    }
}
