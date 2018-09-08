namespace Bolt.Data.DatabaseConfiguration
{
    using System.Collections.Generic;
    using System.Linq;
    using Bolt.Data.Contexts.Bolt.Implementations;
    using Bolt.EntityFrameworkCore.Initializers.Interfaces;
    using Bolt.Models;

    public class BoltDatabaseConfiguration : IDatabaseConfiguration<BoltDbContext>
    {
        public void Seed(BoltDbContext boltDbContext)
        {
            if (boltDbContext.Menus.Any())
            {
                return;
            }

            BoltDatabaseConfiguration.SeedMenuData(boltDbContext);
        }

        private static void SeedMenuData(BoltDbContext boltDbContext)
        {
            var menu = new Menu
            {
                Products = new List<Product>
                {
                    new Product
                    {
                        Name = "Espresso (Short Black)",
                        Description =
                            "The espresso (aka “short black”) is the foundation and the most important part to every espresso based drink.",
                        Price = 1.5
                    },
                    new Product
                    {
                        Name = "Double Espresso (Doppio)",
                        Description = "A double espresso (aka “Doppio”) is just that, two espresso shots in one cup.",
                        Price = 2.0
                    },
                    new Product
                    {
                        Name = "Short Macchiato",
                        Description =
                            "A short macchiato is similar to an espresso but with a dollop of steamed milk and foam to mellow the harsh taste of an espresso. You will find that baristas in different countries make short macchiatos differently. ",
                        Price = 1.7
                    },
                    new Product
                    {
                        Name = "Long Macchiato",
                        Description =
                            "A long macchiato is the same as a short macchiato but with a double shot of espresso. The same rule of thirds applies in the traditionally made long macchiato.",
                        Price = 2.5
                    },
                    new Product
                    {
                        Name = "Ristretto",
                        Description =
                            "A ristretto is an espresso shot that is extracted with the same amount of coffee but half the amount of water. ",
                        Price = 2.0
                    },
                    new Product
                    {
                        Name = "Long Black (Americano)",
                        Description =
                            "A long black (aka “americano”) is hot water with an espresso shot extracted on top of the hot water.",
                        Price = 3
                    },
                    new Product
                    {
                        Name = "Café Latte",
                        Description =
                            "A café latte, or “latte” for short, is an espresso based drink with steamed milk and micro-foam added to the coffee. This coffee is much sweeter compared to an espresso due to the steamed milk.",
                        Price = 3.5
                    },
                    new Product
                    {
                        Name = "Cappuccino",
                        Description =
                            "A cappuccino is similar to a latte. However the key difference between a latte and cappuccino is that a cappuccino has more foam and chocolate placed on top of the drink. Further a cappuccino is made in a cup rather than a tumbler glass.",
                        Price = 3.5
                    },
                    new Product
                    {
                        Name = "Piccolo Latte",
                        Description =
                            "A piccolo latte is a café latte made in an espresso cup. This means it has a very strong but mellowed down espresso taste thanks to the steamed milk and micro foam within it.",
                        Price = 2.5
                    },
                    new Product
                    {
                        Name = "Flat White",
                        Description =
                            "A flat white is a coffee you’ll primarily find in Australia and New Zealand. It is made the same as a cappuccino expect it does not have any foam or chocolate on top.",
                        Price = 2.0
                    },
                    new Product
                    {
                        Name = "Mocha",
                        Description =
                            "A mocha is a mix between a cappuccino and a hot chocolate. It is made by putting mixing chocolate powder with an espresso shot and then adding steamed milk and micro-foam into the beverage.",
                        Price = 4.0
                    },
                    new Product
                    {
                        Name = "Affogato",
                        Description =
                            "An affogato is a simple dessert coffee that is treat during summer and after dinner. It is made by placing one big scoope of vanilla ice cream within a single or double shot of espresso.",
                        Price = 5.0
                    }
                }
            };

            boltDbContext.Menus.Add(menu);
            boltDbContext.SaveChanges();
        }
    }
}