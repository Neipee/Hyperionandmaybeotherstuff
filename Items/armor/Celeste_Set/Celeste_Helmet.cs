using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hyperionandmaybeotherstuff.Items.armor.Celeste_Set
{
	[AutoloadEquip(EquipType.Head)]
	public class Celeste_Helmet : ModItem
	{
		public override void SetStaticDefaults() {
			// ticksperframe, frameCount
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 2;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ModContent.ItemType<Celeste_Breastplate>() && legs.type == ModContent.ItemType<Celeste_Leggings>();
		}
		public override void UpdateArmorSet(Player player) 
		{
			player.setBonus = "[c/FFA500:Mana]\n"
			+"Gave you plus[c/55FFFF: 20 ✎]";

			player.statManaMax2 += 20;
		}
	}
}