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
			Item.defense = 7;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ModContent.ItemType<Mercenary_Breastplate>() && legs.type == ModContent.ItemType<Mercenary_Leggings>();
		}
		public override void UpdateArmorSet(Player player) 
		{
			player.setBonus = "[c/FFA500:Death Tax]\n"
			+" heal [c/FF5555:1❤] each kill\n"
			+"ennemies are more likely to target you.\n"
			+"[c/FF5555:+5%] more move speed and melee critical strike chance.";	
			//si un ennémie est tué alors donné 5pièces de cuivres, et redonner 1pv	
			player.GetModPlayer<Modplayer_hyp>().mercenarySet = true;
			player.moveSpeed += 0.05f;
			player.GetCritChance<MeleeDamageClass>() += 5f;
			player.aggro += 300;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage<MeleeDamageClass>() += 0.05f;
		}
	}
}