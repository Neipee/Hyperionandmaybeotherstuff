using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Hyperionandmaybeotherstuff.Modplayerfold;

namespace Hyperionandmaybeotherstuff.Items.armor.Mercenary_armor
{
	[AutoloadEquip(EquipType.Head)]
	public class Mercenary_Helmet : ModItem
	{
		public override void SetStaticDefaults() {
			//
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 1;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ModContent.ItemType<Mercenary_Breastplate>() && legs.type == ModContent.ItemType<Mercenary_Leggings>();
		}
		public override void UpdateArmorSet(Player player) 
		{
			player.setBonus = "[c/FFA500:Death Tax]\n"
			+" heal [c/FF5555:1❤] each kill";	
			//si un ennémie est tué alors donné 5pièces de cuivres, et redonner 1pv	
			player.GetModPlayer<Modplayer_hyp>().mercenarySet = true;
		}
	}
}