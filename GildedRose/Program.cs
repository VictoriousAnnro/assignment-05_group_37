using System;
using System.Collections.Generic;

namespace GildedRose
{
    public class Program
    {
        static IList<Item> Items;
        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            Items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new AgedBrie ("Aged Brie", 2, 0),
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Sulfura("Sulfuras, Hand of Ragnaros", 0, 80),
                new Sulfura("Sulfuras, Hand of Ragnaros", -1, 80),
                new BackStagepass(
                    name: "Backstage passes to a TAFKAL80ETC concert",
                    sellIn: 15,
                    quality: 20
                ),
                new BackStagepass(
                    name: "Backstage passes to a TAFKAL80ETC concert",
                    sellIn: 10,
                    quality: 49
                ),
                new BackStagepass(
                    name: "Backstage passes to a TAFKAL80ETC concert",
                    sellIn: 5,
                    quality: 49
                ),
				// conjured item
				new Conjured("Conjured Mana Cake", 3, 6)
                                          };

            for (var i = 0; i < 31; i++)
            {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < Items.Count; j++)
                {
                    Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
                }
                Console.WriteLine("");
                UpdateQuality(Items);
            }

        }


        public static void UpdateQuality(IList<Item> Items)
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Items[i].UpdateQuality();
            }

        }
    }

    public class Item 
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }

        public virtual void UpdateQuality(){
            if(Quality > 0) Quality = Quality - 1;
                
            SellIn = SellIn - 1;
                
            if (SellIn < 0)
            {
                if (Quality > 0) Quality = Quality - 1;
            }
        }
    }
    

    public class AgedBrie : Item {

        public AgedBrie(string name, int sellIn, int quality) : base(){
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public override void UpdateQuality(){
            if (Quality < 50) Quality = Quality + 1;
        
            SellIn = SellIn - 1;
                
            if (SellIn < 0 && Quality < 50) Quality = Quality + 1;   
        }
    }

    public class Sulfura : Item {

        public Sulfura(string name, int sellIn, int quality) : base(){
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public override void UpdateQuality(){
            //nothing changes - its legendary mate
        }
    }

    public class BackStagepass : Item {

        public BackStagepass(string name, int sellIn, int quality) : base(){
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public override void UpdateQuality(){
            if (Quality < 50) Quality = Quality + 1;

            if (SellIn < 11 && Quality < 50) Quality = Quality + 1;
            
            if (SellIn < 6 && Quality < 50) Quality = Quality + 1;
                                
            SellIn = SellIn - 1;
                
            if (SellIn < 0) Quality = Quality - Quality;
                
        }
    }

    public class Conjured : Item {

        public Conjured(string name, int sellIn, int quality) : base(){
            Name = name;
            SellIn = sellIn;
            Quality = quality;
        }

        public override void UpdateQuality(){
            if(Quality > 0) Quality = Quality - 2; //degrade 2
                
            SellIn = SellIn - 1;
                
            if (SellIn < 0)
            {
                if (Quality > 0) Quality = Quality - 2; //degrade 4 total, bc degrades twice as fast as normal item
            } 
        }
    }
}