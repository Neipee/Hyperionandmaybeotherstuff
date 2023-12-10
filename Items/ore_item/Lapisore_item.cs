using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Hyperionandmaybeotherstuff.Tiles;

namespace Hyperionandmaybeotherstuff.Items.ore_item
{
    public class Lapisore_item : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 100;
			ItemID.Sets.SortingPriorityMaterials[Item.type] = 58;
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(silver: 10);
            Item.rare = ItemRarityID.Blue;
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.Lapis_ore>());
        }
    }
}