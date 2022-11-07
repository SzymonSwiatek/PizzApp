using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzApp.Data.Migrations
{
    public partial class FillDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           migrationBuilder.Sql("INSERT INTO dbo.Pizza(Name, Description, Price, Source) VALUES ('Pepperoni', 'Pepperoni sausage, mozzarella cheese, herb tomato sauce', 50.99, 'pepperoni.jpg')");
           migrationBuilder.Sql("INSERT INTO dbo.Pizza(Name, Description, Price, Source) VALUES ('Chicken', 'Grilled chicken, corn, mozzarella, herb tomato sauce', 50.99, 'chicken.jpg')");
           migrationBuilder.Sql("INSERT INTO dbo.Pizza(Name, Description, Price, Source) VALUES ('Margherita', 'Mozzarella cheese, herb tomato sauce', 40.99, 'margherita.jpg')");
           migrationBuilder.Sql("INSERT INTO dbo.Pizza(Name, Description, Price, Source) VALUES ('Cottage', 'Sausage, mushrooms, corn, red onion, mozzarella, garlic sauce', 56.99, 'cottage.jpg')");
           migrationBuilder.Sql("INSERT INTO dbo.Pizza(Name, Description, Price, Source) VALUES ('Cheesy', 'Cheddar, mozzarella, fresh mozzarella, corregio, garlic sauce', 56.99, 'cheesy.jpg')");
           migrationBuilder.Sql("INSERT INTO dbo.Pizza(Name, Description, Price, Source) VALUES ('Hawaiian', 'Ham, pineapple, mozzarella cheese, herb tomato sauce', 56.99, 'hawaiian.jpg')");
           migrationBuilder.Sql("INSERT INTO dbo.Pizza(Name, Description, Price, Source) VALUES ('Hot Pepperoni', 'Pepperoni sausage, mozzarella cheese, jalapeño, red onion, hot tomato sauce', 56.99, 'hotpepperoni.jpg')");
           migrationBuilder.Sql("INSERT INTO dbo.Pizza(Name, Description, Price, Source) VALUES ('Capricciosa', 'Ham, mushrooms, cherry tomatoes, olives, mozzarella cheese, herb tomato sauce', 56.99, 'capricciosa.jpg')");
           migrationBuilder.Sql("INSERT INTO dbo.Pizza(Name, Description, Price, Source) VALUES ('Carbonara', 'Bacon, tomatoes, mushrooms, onion, corregio cheese, mozzarella, White sauce, Red onion', 62.99, 'carbonara.jpg')");
           migrationBuilder.Sql("INSERT INTO dbo.Pizza(Name, Description, Price, Source) VALUES ('Prosciutto e Rucola', 'Matured ham, corregio cheese, cherry tomatoes, rocket, mozzarella cheese,', 62.99, 'prosciuttoerucola.jpg')");
           migrationBuilder.Sql("INSERT INTO dbo.Pizza(Name, Description, Price, Source) VALUES ('Vege Mania', 'Mushrooms, fresh spinach, pepper mix, cherry tomatoes, red onion, Mozzarella', 62.99, 'vegemania.jpg')");



        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
