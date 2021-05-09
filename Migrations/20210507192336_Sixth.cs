using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Golden_Leaf_Back_End.Migrations
{
    public partial class Sixth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastPurchase",
                table: "Clients",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "CURRENT_TIMESTAMP",
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldDefaultValueSql: "getdate()");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                defaultValue: "iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAABuwAAAbsBOuzj4gAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAUbSURBVHic5ZvBa1RHHMc/s2EloEmhmpKkbSKFmmColBQJiJemh9KaUBqv6UEUPAhe/At6iEdPHhSvvXmQYEnx0IaCIIgtiUVtDg3bdpUa6qGmQWUlvx7eLC5vf7P7dt689zb1C8PCvPd+v+/vOzNvZn5v1ogIecAYsxeYBT4B3gGGbQF4ZEsV+B64LiJPciEmIpkVoATMA8vAS0ASlpf2mXmglCnHDIM/BtztIGhXuQsc2zECAH3AYoDA42UR6OtqAYDRQK3eqjeMhuRsLPHUMMZMAD8Ab7W47Z5tyWXgT6IXH0Qvw3eBj4EvgIkWNjaAaRG5l5YzEKYHAAPAOu6WWwYOd2DvsH3GZW8dGOiKIQDsAm46iD4Fjqewfdza0GzfBHZ1gwDnHQR/AyYC2J+wtjQf5wsVABgCthRij4GREF3U+hmxNuN+toChIgW4pJB6DhwJFXyDryPWdtzfpUIEAAaBmkJoIXTwDT4XFH81YLAIAU4rZDaA/gwF6Lc+4n5P+9os4Y8vlbqLIvI0hc2WsLYvJuSSCF4LIWNMH/AEKMcuHRKRX3zJJPT9AdGKsBE1YK+IbHZqz7cHvE9z8JWsgwewPiqx6rLl1DF8BRhW6sIsTZNB86VxaouQAjxS6rKC5itXAd5U6v72tOUDzZfGqS18BfhLqdvnacsHmi+NU1v4CvC7UufVBT2h+dI4tYWvABWlrtUePjQ0XxUfQ74CVIHtWN1+O0dnCutjf6x623LqGF4CiEgNuK1c8l6RdQDNx23LqXOkWJefpHv2AieL2AztATYVMnnvBjeBPbkLYAldUQjlnQ+4kspuSlLjwDOFVF4ZoWfAeGECWHJnFWJ55QTPprYfgKABbjgIZpkVvoHdzhcqgCU65Hg718syYb8LbJAyGVovIb8MjQPf0bxIaUSIL0MV4DMR+TUdY4sQKja03CBwB3fLpS13SJEAzbQH1GGM2U301ebDoIZhBTgqIlshjaZJijbBGPMpsET44LE2l6yPcAjQ7Q0wR7ZdXxsKcxQ5C9jAvwLu5xh4vNy3HLyF8E2LvwF8A8wkfKRKNDTWgYdEb//6L0SzwNsNv+8BnxMdpkqCb4F5Efkn4f2v4NHyB4E12rfOCvA1MJmil01aGysJ/K0BBzMdAkTjTtsBNparwFjasan4HrO2W/neBOaCC0A0WywQZV5czn8EpkIHrnCZsr5cPLYt10TH65I47AGutXBYAWazDlzhNWt9u3hdA3pCCHChTasHOavjKcJAm95wIZUAwIkWxi8D5aKCb+BYtlxcPE94CQAcBV4oBmvAmaIDV/ieQT+w8YJoCZ1cAKIDj1oGRrox+JgIGufHOA5YugzdcnX7ooNMIIJrONxKJADRXO964RU+5hMIUG7xYmxaI8Qf7gEeKA9Winzbe4gwgD5FPiA2NcYfPOVQLvd5PoAIs45YTqkCAL1Em5amrl90MClE0IZCFejVBDjnUCzz5W2GAkw5YjqnCbCq3Hi16CACiKBtoFbr142IYIwZQT9gMC4ia0r9joExZgzQMsijIvJHPSeoJTZWd3rwADaGVeXSDLxKimoCLGZFqgBoscxAlNfbTXTqqjd2w0ci8nPGxHKBMWYS+ClW/RzYVwKmaQ6++n8JHsDGEj9C0wtMl4ADyjNLmbPKH1pMB0roR87WMyZTBLSYhktEX3bjeJgxmSKgxTTk6gF5nvvNC+r54te+BxjsKavYhX7x+PNBN8P+ySP+b5Z//wOqogHhayKfiQAAAABJRU5ErkJggg==",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Payments",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Orders",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastPurchase",
                table: "Clients",
                type: "datetime",
                nullable: false,
                defaultValueSql: "getdate()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "CURRENT_TIMESTAMP");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Categories",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Photo",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true,
                oldDefaultValue: "iVBORw0KGgoAAAANSUhEUgAAAEAAAABACAYAAACqaXHeAAAABHNCSVQICAgIfAhkiAAAAAlwSFlzAAABuwAAAbsBOuzj4gAAABl0RVh0U29mdHdhcmUAd3d3Lmlua3NjYXBlLm9yZ5vuPBoAAAUbSURBVHic5ZvBa1RHHMc/s2EloEmhmpKkbSKFmmColBQJiJemh9KaUBqv6UEUPAhe/At6iEdPHhSvvXmQYEnx0IaCIIgtiUVtDg3bdpUa6qGmQWUlvx7eLC5vf7P7dt689zb1C8PCvPd+v+/vOzNvZn5v1ogIecAYsxeYBT4B3gGGbQF4ZEsV+B64LiJPciEmIpkVoATMA8vAS0ASlpf2mXmglCnHDIM/BtztIGhXuQsc2zECAH3AYoDA42UR6OtqAYDRQK3eqjeMhuRsLPHUMMZMAD8Ab7W47Z5tyWXgT6IXH0Qvw3eBj4EvgIkWNjaAaRG5l5YzEKYHAAPAOu6WWwYOd2DvsH3GZW8dGOiKIQDsAm46iD4Fjqewfdza0GzfBHZ1gwDnHQR/AyYC2J+wtjQf5wsVABgCthRij4GREF3U+hmxNuN+toChIgW4pJB6DhwJFXyDryPWdtzfpUIEAAaBmkJoIXTwDT4XFH81YLAIAU4rZDaA/gwF6Lc+4n5P+9os4Y8vlbqLIvI0hc2WsLYvJuSSCF4LIWNMH/AEKMcuHRKRX3zJJPT9AdGKsBE1YK+IbHZqz7cHvE9z8JWsgwewPiqx6rLl1DF8BRhW6sIsTZNB86VxaouQAjxS6rKC5itXAd5U6v72tOUDzZfGqS18BfhLqdvnacsHmi+NU1v4CvC7UufVBT2h+dI4tYWvABWlrtUePjQ0XxUfQ74CVIHtWN1+O0dnCutjf6x623LqGF4CiEgNuK1c8l6RdQDNx23LqXOkWJefpHv2AieL2AztATYVMnnvBjeBPbkLYAldUQjlnQ+4kspuSlLjwDOFVF4ZoWfAeGECWHJnFWJ55QTPprYfgKABbjgIZpkVvoHdzhcqgCU65Hg718syYb8LbJAyGVovIb8MjQPf0bxIaUSIL0MV4DMR+TUdY4sQKja03CBwB3fLpS13SJEAzbQH1GGM2U301ebDoIZhBTgqIlshjaZJijbBGPMpsET44LE2l6yPcAjQ7Q0wR7ZdXxsKcxQ5C9jAvwLu5xh4vNy3HLyF8E2LvwF8A8wkfKRKNDTWgYdEb//6L0SzwNsNv+8BnxMdpkqCb4F5Efkn4f2v4NHyB4E12rfOCvA1MJmil01aGysJ/K0BBzMdAkTjTtsBNparwFjasan4HrO2W/neBOaCC0A0WywQZV5czn8EpkIHrnCZsr5cPLYt10TH65I47AGutXBYAWazDlzhNWt9u3hdA3pCCHChTasHOavjKcJAm95wIZUAwIkWxi8D5aKCb+BYtlxcPE94CQAcBV4oBmvAmaIDV/ieQT+w8YJoCZ1cAKIDj1oGRrox+JgIGufHOA5YugzdcnX7ooNMIIJrONxKJADRXO964RU+5hMIUG7xYmxaI8Qf7gEeKA9Winzbe4gwgD5FPiA2NcYfPOVQLvd5PoAIs45YTqkCAL1Em5amrl90MClE0IZCFejVBDjnUCzz5W2GAkw5YjqnCbCq3Hi16CACiKBtoFbr142IYIwZQT9gMC4ia0r9joExZgzQMsijIvJHPSeoJTZWd3rwADaGVeXSDLxKimoCLGZFqgBoscxAlNfbTXTqqjd2w0ci8nPGxHKBMWYS+ClW/RzYVwKmaQ6++n8JHsDGEj9C0wtMl4ADyjNLmbPKH1pMB0roR87WMyZTBLSYhktEX3bjeJgxmSKgxTTk6gF5nvvNC+r54te+BxjsKavYhX7x+PNBN8P+ySP+b5Z//wOqogHhayKfiQAAAABJRU5ErkJggg==");
        }
    }
}
