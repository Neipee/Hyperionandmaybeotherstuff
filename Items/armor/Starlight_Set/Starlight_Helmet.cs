using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hyperionandmaybeotherstuff.Items.armor.Starlight_Set
{
	[AutoloadEquip(EquipType.Head)]
	public class Starlight_Helmet : ModItem
	{
		public override void SetStaticDefaults() {
			// ticksperframe, frameCount
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 6;
		}
		public override bool IsArmorSet(Item head, Item body, Item legs) 
		{
			return body.type == ModContent.ItemType<Starlight_Breastplate>() && legs.type == ModContent.ItemType<Starlight_Leggings>();
		}
		public override void UpdateArmorSet(Player player) 
		{
			player.setBonus = "[c/FFA500:Starpower]\n"
			+"Gave you plus[c/55FFFF: 30 ✎]\n"
			+"Increases the duration of\n"
			+"[c/FFAA00:Starfall] by [c/55FF55:2x] and\n"
			+"its range by [c/55FF55:+5] tiles.\n"
			+"[c/FF5555:5%] increased magic damage and move speed.";
			player.statManaMax2 += 30;
			player.moveSpeed += 0.05f;
			player.GetCritChance<MagicDamageClass>() += 5f;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetDamage<MagicDamageClass>() += 0.08f;
		}
	}
}