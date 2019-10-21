namespace csharp
{
    public static class ItemRules
    {
        public static void Add1Day(this Item item)
        {
            bool AgingImproves = item.Name == ItemNames.AgedBrie || item.Name == ItemNames.BackPassTAFKAL80ETC;
            bool Legendary = item.Name == ItemNames.Sulfuras;
            bool Conjured = item.Name == ItemNames.ConjuredManaCake;

            if (!Legendary)
            {
                //impact on quality
                int qualityoffset = -1; 
                if (AgingImproves)
                {
                    qualityoffset = 1;
                    if(item.Name == ItemNames.BackPassTAFKAL80ETC)
                    {
                        if (item.SellIn <= 10 && item.SellIn > 5) qualityoffset = 2;
                        else if (item.SellIn <= 5 && item.SellIn > 0) qualityoffset = 3;
                        else if (item.SellIn <= 0) qualityoffset = -item.Quality;
                    }
                    else if (item.SellIn <= 0) qualityoffset = 2; // pour que ça donne les mêmes résultats qu'avant, mais correspond bof à l'énoncé 
                                                                  // énoncé = Once the sell by date has passed, Quality "degrades" twice as fast
                                                                  // => not for Aged Brie as quality never "degrades"
                }
                else
                {
                    if (item.SellIn <= 0) qualityoffset = -2;
                    if (Conjured) qualityoffset *= 2;
                }
                item.Quality += qualityoffset;

                // 0 <= Quality <= 50
                if (item.Quality < 0) item.Quality = 0;
                else if (item.Quality > 50) item.Quality = 50;

                //impact on sellin days
                item.SellIn --;
            }
        }
    }
}
