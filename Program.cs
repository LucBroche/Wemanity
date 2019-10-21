using System;
using System.Collections.Generic;

namespace csharp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("OMGHAI!");

            IList<Item> Items = new List<Item>{
                new Item {Name = ItemNames.DexterityVest, SellIn = 10, Quality = 20},
                new Item {Name = ItemNames.AgedBrie, SellIn = 2, Quality = 0},
                new Item {Name = ItemNames.ElixirMongoose, SellIn = 5, Quality = 7},
                new Item {Name = ItemNames.Sulfuras, SellIn = 0, Quality = 80},
                new Item {Name = ItemNames.Sulfuras, SellIn = -1, Quality = 80},
                new Item {Name = ItemNames.BackPassTAFKAL80ETC, SellIn = 15, Quality = 20},
                new Item {Name = ItemNames.BackPassTAFKAL80ETC, SellIn = 10, Quality = 49},
                new Item {Name = ItemNames.BackPassTAFKAL80ETC, SellIn = 5, Quality = 49},
                new Item {Name = ItemNames.ConjuredManaCake, SellIn = 3, Quality = 6}
            };

            var app = new GildedRose(Items);

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    System.Console.WriteLine(Items[j]);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
