
using Terraria;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
namespace Hyperionandmaybeotherstuff.pets
{
	public class goldendragon : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Golden Dragon");
			// Tooltip.SetDefault("Gdrag is cool");


			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.damage = 0;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.shoot = ModContent.ProjectileType<projectiles.gdragpro>();
			//Item.width = 16;
			//Item.height = 30;
			Item.shootSpeed = 5f;
			Item.UseSound = SoundID.Item2;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.rare = ItemRarityID.Yellow;
			Item.noMelee = true;
			Item.value = Item.sellPrice(0, 5, 50);
			Item.buffType = ModContent.BuffType<buffs.gdragbuff>();
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.

		public override void UseStyle(Player player, Rectangle heldItemFrame) {
			if (player.whoAmI == Main.myPlayer && player.itemTime == 0) {
				player.AddBuff(Item.buffType, 3600);
			}
		}
	}
}