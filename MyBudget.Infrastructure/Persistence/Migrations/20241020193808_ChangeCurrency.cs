using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyBudget.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeCurrency : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Currency_name",
                schema: "app",
                table: "Currency");

            migrationBuilder.DropColumn(
                name: "name",
                schema: "appAudit",
                table: "CurrencyAudit");

            migrationBuilder.DropColumn(
                name: "name_MOD",
                schema: "appAudit",
                table: "CurrencyAudit");

            migrationBuilder.DropColumn(
                name: "name",
                schema: "app",
                table: "Currency");

            migrationBuilder.RenameColumn(
                name: "IsAccounting_MOD",
                schema: "appAudit",
                table: "CurrencyAudit",
                newName: "isAccounting_MOD");

            migrationBuilder.RenameColumn(
                name: "IsAccounting",
                schema: "appAudit",
                table: "CurrencyAudit",
                newName: "isAccounting");

            migrationBuilder.RenameColumn(
                name: "IsAccounting",
                schema: "app",
                table: "Currency",
                newName: "isAccounting");

            migrationBuilder.Sql(@"
INSERT INTO [app].[Currency]
           ([id]
           ,[code]
           ,[iso4217]
           ,[IsAccounting]
           ,[active]
           ,[createDate]
           ,[createdBy]
           ,[modifyDate]
           ,[modifiedBy])
VALUES       
('48C41C71-DD52-4056-91BB-008D8EE1AB06', 'CNY', 156, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('4D0B7F64-78F0-4ADC-889F-057E562A8B32', 'RON', 946, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('CACC0ADF-C268-4EA2-9FF4-05810D05B885', 'GEL', 981, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('BA970A7C-BFC8-4989-80F6-05C645D6BD12', 'JPY', 392, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('564166FA-7043-4F7F-A321-0BF3C25821C8', 'CHF', 756, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('D1A48472-CCC7-4271-9A3A-0C891931DAE5', 'THB', 764, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('90EC0211-D23F-4AB3-BCFE-12CDF452847E', 'BRL', 986, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('E01553A5-2CA3-4B48-A4DD-12DAFB205CB1', 'HRK', 191, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('73E7691E-0AE6-4C19-8FA0-1412D6859925', 'LYD', 434, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('79C4BF2F-C5F4-4431-88CD-157804CB778E', 'RSD', 941, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('EA72E75F-0BE9-41C3-B19D-1E99F9547E4B', 'VND', 704, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('EE8FB2B8-44F0-4CF1-9566-228C84B74221', 'NZD', 554, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('5784E35B-B6E7-4D53-9324-274D3D9D8ACD', 'UZS', 860, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('A28A79C3-5669-4989-A9D4-30560ACA46F5', 'AZN', 944, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('6D306D77-7521-4109-B152-39814F116D92', 'NOK', 578, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('29767145-6070-4AB1-A2FB-3D9C6506ABAE', 'IRR', 364, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('EA5E83B9-D132-42DE-A287-3FE382972594', 'BDT', 50, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('EF946C28-65DA-45CE-B96E-420FE4F68E44', 'AUD', 36, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('FF39FBC2-E2AC-48BB-B87D-44DBBAB9A3E8', 'TMT', 934, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('D7DE0791-BD89-4D1C-87C8-4B1D04E1E06C', 'CZK', 203, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('EFACB6AA-357F-4814-B924-4F9C6CC353D0', 'KRW', 410, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('3540F827-EBAF-427D-A423-54C3907A1DAB', 'SEK', 752, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('6749D7A5-4AB2-41E4-891F-5556A2E68856', 'KGS', 417, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('13CC5DC4-93A2-4021-81A4-59838933AF35', 'RUB', 643, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('65B25ED8-38E3-44B4-95C2-5C30AAFA9941', 'HKD', 344, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('A93DF497-85E2-49F8-94BC-6BC931FF4055', 'INR', 356, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('390928CA-5D4A-4F4D-AFEB-6E0ADAA2957F', 'KZT', 398, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('4C6F269B-45AB-47FB-8A70-7066BBDF2C2F', 'PKR', 586, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('3EEBA9C6-F381-403B-B520-7240A8404D38', 'IQD', 368, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('3879088A-5DC0-4F1E-9ED6-772CFFB33BCB', 'GBP', 826, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('5F5EB8B8-EB4D-459C-AEE2-82A778542DAF', 'CAD', 124, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('7D3F7ED4-8733-4D29-AC24-871D81DA0E5E', 'TND', 788, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('7571C10D-C7B1-4C09-AB53-8B99253F2462', 'AED', 784, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('EC547E50-976F-4755-A264-91BA5FA1964A', 'TJS', 972, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('25E84466-EA84-4617-A0C5-992B72767DAB', 'EGP', 818, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('590659F5-5A77-4C50-8ED7-A064AB7FAF65', 'BGN', 975, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('0911D8DF-D6B1-4182-9114-A36AE80D6E09', 'DZD', 12, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('F3C0EB35-A2C4-49F4-9A4A-ACA1067D1DBE', 'DKK', 208, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('B14E5440-A310-411B-80B1-ADBE88E7ED45', 'MDL', 498, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('6D560EB8-FF96-4301-8F9A-B3D033B27AC8', 'ZAR', 710, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('F99E826F-F1F8-442C-BA53-B95C7945DD60', 'SAR', 682, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('993C1413-FBBB-4F56-BE0A-B96DEC8EB698', 'PLN', 985, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('B7EFA785-1FB4-433E-95D4-BE58E49D13C5', 'IDR', 360, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('BBD0FD9F-F996-4B75-A52D-C1A7D4D6CB23', 'UAH', 980, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('8DBB2430-0CB3-4885-AE51-C8AE89CA321D', 'BYN', 933, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('AA952B10-3EAA-4973-BB22-CB2132FC60A8', 'MXN', 484, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('14DA1287-11B1-410B-B133-D282DF83251A', 'AMD', 51, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('1BFD807E-8C78-476D-A2F7-D5E8F20F010F', 'HUF', 348, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('F7F60BAD-0DA2-433A-8FE6-EA0E7D0DED3A', 'TRY', 949, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('5CD88F52-F9BD-4D83-9C39-EB1B6CEBF17E', 'USD', 840, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('BF3BFEDE-41E7-4D03-B72E-EB37E57820A9', 'ILS', 376, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('F2469272-E92D-4340-9BC4-EDB7FC434D12', 'LBP', 422, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('D1A4540C-CEA8-4A0C-878B-EEE649E98911', 'SGD', 702, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('E0F36CB2-5006-44FD-8572-EF5CFF673100', 'MAD', 504, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('27019180-4D8A-428B-B74A-F332BC8A35C4', 'EUR', 978, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration'),
('ABE9B61B-0116-43E2-A4B9-F8901E957241', 'MYR', 458, 0, 1, GETDATE(), 'Migration', GETDATE(), 'Migration')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isAccounting_MOD",
                schema: "appAudit",
                table: "CurrencyAudit",
                newName: "IsAccounting_MOD");

            migrationBuilder.RenameColumn(
                name: "isAccounting",
                schema: "appAudit",
                table: "CurrencyAudit",
                newName: "IsAccounting");

            migrationBuilder.RenameColumn(
                name: "isAccounting",
                schema: "app",
                table: "Currency",
                newName: "IsAccounting");

            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "appAudit",
                table: "CurrencyAudit",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "name_MOD",
                schema: "appAudit",
                table: "CurrencyAudit",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "name",
                schema: "app",
                table: "Currency",
                type: "nvarchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Currency_name",
                schema: "app",
                table: "Currency",
                column: "name",
                unique: true);
        }
    }
}
