using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Chibogers_TheFoodpocalyse_1._0._0
{
    class Inventory : Form {
        public Inventory()
        {
            int i = 0;
            for (; i < Item.inventory.Count; i++) {
                Console.WriteLine("Making Block...");
                Item.Block block = new Item.Block(i, Item.inventory[i], this);
            }
            if (i > 15) i = 15;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            MaximizeBox = false;
            Text = "Inventory";
            Size = new Size(335, (i + 2) * 20);
        }
    }

    class Item {

        // Ingredients
        static Item eggs =              new Item("Eggs");
        static Item salt =              new Item("Salt");
        static Item fish =              new Item("Fish");
        static Item rice =              new Item("Rice");
        static Item wheat =             new Item("Wheat");
        static Item broth =             new Item("Broth");
        static Item pepper =            new Item("Pepper");
        static Item potato =            new Item("Potato");
        static Item salami =            new Item("Salami");
        static Item hotdog =            new Item("Hotdog");
        static Item cheese =            new Item("Cheese");
        static Item tomato =            new Item("Tomato");
        static Item carrot =            new Item("Carrot");
        static Item ketshup =           new Item("Ketshup");
        static Item mustard =           new Item("Mustard");
        static Item lettuce =           new Item("Lettuce");
        static Item raddish =           new Item("Raddish");
        static Item seaWeed =           new Item("Sea Weed");
        static Item soySauce =          new Item("Soy Sauce");
        static Item uncookedSteak =     new Item("Uncooked Steak");
        static Item bottleOfWater =     new Item("Bottle of Water");
        static Item uncookedChicken =   new Item("Uncooked Chicken");

        // Craftable Items and their Recipes
        static Item bread =             new Item("Bread",           new Dictionary<Item, int>() { { wheat, 3 } },                                                                       () => { Game.here.playerHP.Damage(-45); });
        static Item cookedEggs =        new Item("Cooked Eggs",     new Dictionary<Item, int>() { { eggs, 2 }, { salt, 2 } },                                                           () => { Game.here.playerHP.Damage(-50); });
        static Item frenchFries =       new Item("French Fries",    new Dictionary<Item, int>() { { potato, 5 }, { salt, 3 } },                                                         () => { Game.here.playerHP.Damage(-75); });
        static Item cookedSteak =       new Item("Cooked Steak",    new Dictionary<Item, int>() { { uncookedSteak, 1 }, { salt, 3 }, { pepper, 3 } },                                   () => { Game.here.playerHP.Damage(-125); });
        static Item cookedChicken =     new Item("Cooked Chicken",  new Dictionary<Item, int>() { { uncookedChicken, 1 }, { salt, 3 }, { pepper, 3 } },                                 () => { Game.here.playerHP.Damage(-100); });
        static Item sushi =             new Item("Sushi",           new Dictionary<Item, int>() { { fish, 2 }, { rice, 2 }, { seaWeed, 3 }, { soySauce, 1 } },                          () => { Game.here.playerMultiplier += .25f; Game.here.playerDef += 15; });
        static Item pizza =             new Item("Pizza",           new Dictionary<Item, int>() { { bread, 5 }, { salami, 3 }, { cheese, 3 }, { tomato, 3 } },                          () => { Game.here.playerHP.Damage(-150); });
        static Item hotdogs =           new Item("Hotdogs",         new Dictionary<Item, int>() { { hotdog, 1 }, { bread, 1 }, { ketshup, 1 }, { mustard, 1 } },                        () => { Game.here.playerMultiplier += .45f; });
        static Item burger =            new Item("Burger",          new Dictionary<Item, int>() { { uncookedSteak, 1 }, { bread, 1 }, { lettuce, 2 }, { tomato, 2 } },                  () => { Game.here.playerDef += 35; });
        static Item potOfSoup =         new Item("Pot of Soup",     new Dictionary<Item, int>() { { carrot, 3 }, { raddish, 3 }, { broth, 1 }, { potato, 3 }, { bottleOfWater, 3 } },   () => { Game.here.playerHP.Damage(-250); Game.here.playerMultiplier += .75f; Game.here.playerDef += 50; });

        // Storage for all Items
        public static List<Item> inventory = new List<Item>()
        {
            cookedChicken, cookedSteak, cookedEggs, frenchFries, potOfSoup, hotdogs, burger, sushi, pizza, bread,
            eggs, salt, fish, rice, wheat, broth, pepper, potato, salami, hotdog, cheese, tomato, carrot, ketshup,
            mustard, lettuce, raddish, seaWeed, soySauce, bottleOfWater, uncookedSteak, uncookedChicken
        };

        public bool craftable;
        private int quantity;
        public string name;
        public delegate void EffectAction();
        public EffectAction effect;
        public Dictionary<Item, int> recipe;

        public Item(string name) {
            this.name = name;
            recipe = new Dictionary<Item, int>();
            craftable = false;
        }
        public Item(string name, Dictionary<Item, int> recipe, EffectAction effect) {
            this.effect = effect;
            this.name = name;
            this.recipe = recipe;
            craftable = true;
        }
        public class Block
        {
            public Item item;
            public Panel panel = new Panel();
            public Button use = new Button();
            public Button craft = new Button();
            public Label text = new Label();

            public Block(int index, Item item, Form where)
            {
                pizza.quantity = 1;     //
                potOfSoup.quantity = 1; // Debugging stuff
                burger.quantity = 1;    //
                where.AutoScroll = true;
                this.item = item;
                text.Text = $"{item.quantity} {item.name}";
                text.Size = new Size(130, 20);

                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Size = new Size(300, 20);
                panel.Location = new Point(0, index * 20);

                if (item.craftable) {
                    use.Text = "Use";
                    use.Dock = DockStyle.Right;
                    use.FlatStyle = FlatStyle.Popup;
                    use.MouseLeave += (s, e) => use.BackColor = Color.WhiteSmoke;
                    use.MouseHover += (s, e) => use.BackColor = Color.YellowGreen;

                    craft.Text = "Craft";
                    craft.Dock = DockStyle.Right;
                    craft.FlatStyle = FlatStyle.Popup;
                    craft.MouseLeave += (s, e) => craft.BackColor = Color.WhiteSmoke;
                    craft.MouseHover += (s, e) => craft.BackColor = Color.YellowGreen;

                    use.Click += (sender, e) => {
                        if (item.quantity != 0) {
                            item.quantity--;
                            this.item.effect();
                            MessageBox.Show($"Used item {item.name}");
                            where.Close();
                        }
                        else MessageBox.Show($"You have 0 {item.name}");
                    };

                    craft.Click += (sender, e) => {
                        CraftItem(item);
                        where.Close();
                    };

                    panel.Controls.Add(use);
                    panel.Controls.Add(craft);
                }

                panel.Controls.Add(text);
                where.Controls.Add(panel);
                panel.Show();
            }
        }

        public static void LootItems()
        {
            string loot = "You have defeated the enemy!";
            List<Item> nonCraftables = new List<Item>(); // List of all ingredients
            foreach (Item item in inventory) if (!item.craftable) nonCraftables.Add(item);

            Random random = new Random();
            int numberOfItems = random.Next(3, 10);
            loot += $"\nYou gained {numberOfItems} items\n";

            for (int i = 0; i < numberOfItems; i++)
            {
                Item randomItem = nonCraftables[random.Next(0, nonCraftables.Count)];
                int amount = random.Next(1, 10);

                randomItem.quantity += amount;

                loot += $"\t{randomItem.name} - {randomItem.quantity}\n";
            }
            MessageBox.Show(loot);
        }

        public static void CraftItem(Item item)
        {
            List<string> missingIngredients = new List<string>();

            foreach (KeyValuePair<Item, int> requirement in item.recipe)
            {
                int requiredQuantity = requirement.Value;
                if (requirement.Key.quantity < requiredQuantity)
                { missingIngredients.Add($"{requiredQuantity - requirement.Key.quantity} {requirement.Key.name}"); }

                else if (item.quantity > requirement.Key.quantity)
                {
                    MessageBox.Show($"Not enough {requirement.Key.name} to craft {item.name}. Available: {requirement.Key.quantity}");
                    return;
                }
            }

            if (missingIngredients.Any())
            {
                // Concatenate missing ingredients into a single string
                string neededingredients = $"Not enough resources to craft {item.name}. Missing ingredients:\n";

                //Stores all Missing Ingredients in missingIngredients
                foreach (string ingredient in missingIngredients) neededingredients += $"- {ingredient}\n";

                // Displays a MessageBox with all missing ingredients
                MessageBox.Show(neededingredients);
            }

            else
            {
                // Deduct the required resources from the inventory
                foreach (KeyValuePair<Item, int> requirement in item.recipe) requirement.Key.quantity -= requirement.Value;

                // Add the crafted item to the inventory
                item.quantity++;
                MessageBox.Show($"{item.name} has been crafted successfully!");
            }
        }
    }
}
