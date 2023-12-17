using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hyperionandmaybeotherstuff.Items.armor.Celeste_Set
{
	[AutoloadEquip(EquipType.Body)]
	public class Celeste_Breastplate : ModItem
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

	}
}