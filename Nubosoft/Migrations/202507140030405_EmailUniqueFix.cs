﻿namespace Nubosoft.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailUniqueFix : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 100));
            CreateIndex("dbo.Users", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "Email" });
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
        }
    }
}
