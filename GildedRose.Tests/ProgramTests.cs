namespace GildedRose.Tests;

public class ProgramTests
{
    IList<Item> items;

    [Fact]
    public void Quality_and_SellIn_Should_Decrease_by_1_PerDay()
    {
        items = new List<Item>{
            new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
            //new AgedBrie { Name = "Aged Brie", SellIn = 2, Quality = 0 }
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(19);
        items[0].SellIn.Should().Be(9);

    }

    [Fact]
    public void Quality_Should_Decrease_by_2_PerDay_after_SellIn()
    {
        items = new List<Item>{
            new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 20 }
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(18);

    }

    [Fact]
    public void Quality_never_neg()
    {
        items = new List<Item>{
            new Item { Name = "+5 Dexterity Vest", SellIn = 0, Quality = 1 } //quality 'should' decrease by 2 bc sellin = 0
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(0);
    }

    [Fact]
    public void Quality_never_over_50()
    {
        items = new List<Item>{
            new AgedBrie (name: "Aged Brie", sellIn: 0, quality: 49),
            new BackStagepass(name: "Backstage passes to a TAFKAL80ETC concert",
                            sellIn: 8, 
                            quality: 49)
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(50);
        items[1].Quality.Should().Be(50);
        
    }

    [Fact]
    public void Brie_Quality_Should_Increase_2_after_SellIn()
    {
        items = new List<Item>{
            new AgedBrie (name: "Aged Brie", sellIn: 0, quality: 10)
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(12);

    }

    [Fact]
    public void Backstagepass_value_increase_2_When9DaysTillConcert()
    {
        items = new List<Item>{
            new BackStagepass(name: "Backstage passes to a TAFKAL80ETC concert",
                            sellIn: 9, 
                            quality: 22)
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(24);

    }

    [Fact]
    public void Backstagepass_value_increase_3_When4DaysTillConcert()
    {
        items = new List<Item>{
            new BackStagepass(name: "Backstage passes to a TAFKAL80ETC concert",
                            sellIn: 4, 
                            quality: 22)
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(25);

    }

    [Fact]
    public void Backstagepass_value_dropTo_0_WhenConcertDone()
    {
        items = new List<Item>{
            new BackStagepass(name: "Backstage passes to a TAFKAL80ETC concert",
                            sellIn: 0, 
                            quality: 22)
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(0);

    }

    [Fact]
    public void Sulfura_never_changes()
    {
        items = new List<Item>{
            new Sulfura (name: "Sulfuras, Hand of Ragnaros", sellIn: 0, quality: 80)
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(80);
        items[0].SellIn.Should().Be(0);
    }


    [Fact]
    public void Conjured_Quality_Decrease_2_perday()
    {
        items = new List<Item>{
            new Conjured(name: "Conjured Mana Cake", sellIn: 3, quality: 6)
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(4);
        items[0].SellIn.Should().Be(2);
    }

    [Fact]
    public void Conjured_Quality_Decrease_4_after_sellIn()
    {
        items = new List<Item>{
            new Conjured(name: "Conjured Mana Cake", sellIn: 0, quality: 6)
            };

        Program.UpdateQuality(items);
        items[0].Quality.Should().Be(2);
        items[0].SellIn.Should().Be(-1);
    }

}