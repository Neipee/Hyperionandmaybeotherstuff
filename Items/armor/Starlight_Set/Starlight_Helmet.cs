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
			Item.defense = 1;
		}
	}
}