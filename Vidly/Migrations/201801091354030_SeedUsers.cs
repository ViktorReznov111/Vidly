namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'46c1f10c-e496-4ecc-b1e9-77138186ac1f', N'guest', N'ABbiw5rIe7265BKJk2P+ODpCMNF3yvAa3ylgOCz11k4eWs6Ltun+sOKMN9E3SzYVrg==', N'909ad175-f4ec-4732-9a98-7e597c61f38f', N'ApplicationUser')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [PasswordHash], [SecurityStamp], [Discriminator]) VALUES (N'fa861398-9779-426b-927e-787d718be236', N'admin', N'AOdZa+ztR6GuF3gxGZQKe7Jx/JgfEIn/ttUJ52cm3AyxsDFrdrJ5L71fXoAcqwk1Sw==', N'72104928-77e8-46b0-bad4-b56788a2ccf6', N'ApplicationUser')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd785f1df-3e96-4df7-8368-f36bde69c7e5', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fa861398-9779-426b-927e-787d718be236', N'd785f1df-3e96-4df7-8368-f36bde69c7e5')

");
        }
        
        public override void Down()
        {
        }
    }
}
