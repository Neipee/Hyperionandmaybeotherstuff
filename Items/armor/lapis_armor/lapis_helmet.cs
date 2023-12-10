using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hyperionandmaybeotherstuff.Items.armor.lapis_armor
{
	[AutoloadEquip(EquipType.Head)]
	public class lapis_helmet : ModItem
	{
		public override void SetStaticDefaults() {
			// ticksperframe, frameCount
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 6));
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 3;
		}

	public override bool IsArmorSet(Item head, Item body, Item legs) {
		return body.type == ModContent.ItemType<lapis_chestplate>() && legs.type == ModContent.ItemType<lapis_leggings>();
	}
	public override void UpdateArmorSet(Player player) 
	{
			player.setBonus = " [c/FFA500:Health]\n"
			+"Increases the wearer's maximum [c/FF5555:❤ Health] by [c/55FF55:60]";		
			player.statLifeMax2 += 20;
			/* Here are the individual weapon class bonuses.
			player.meleeDamage -= 0.2f;
			player.thrownDamage -= 0.2f;
			player.rangedDamage -= 0.2f;
			player.magicDamage -= 0.2f;
			player.minionDamage -= 0.2f;
			*/
		}
		/*public override void AddRecipes() {
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<EquipMaterial>(), 60);
			recipe.AddTile(ModContent.TileType<ExampleWorkbench>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}*/
	}
}