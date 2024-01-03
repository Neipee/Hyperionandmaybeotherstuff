using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hyperionandmaybeotherstuff.Items.armor.Mercenary_armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class Mercenary_Leggings : ModItem
	{
		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.value = 10000;
			Item.rare = ItemRarityID.Green;
			Item.defense = 6;
		}
		public override void UpdateEquip(Player player)
		{
			player.GetCritChance<MeleeDamageClass>() += 2f;
			player.moveSpeed += 0.05f;
			player.GetDamage<MeleeDamageClass>() += 0.05f;
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