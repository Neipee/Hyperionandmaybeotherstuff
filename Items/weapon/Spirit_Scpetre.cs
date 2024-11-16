using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Threading;
using System.Windows.Forms;
using System.Collections.Generic;
using Terraria.IO;
using Terraria.Localization;
using Terraria.WorldBuilding;



namespace Hyperionandmaybeotherstuff.Items.weapon
{
    public class Spirit_Scpetre : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gold Wave");
            // Tooltip.SetDefault("Creates a wave of gold projectiles");
        }

        public override void SetDefaults()
        {
            Item.damage = 200;
            Item.DamageType = DamageClass.Magic;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("Bat").Type;
            Item.shootSpeed = 0f;
            Item.mana = 20;
        }

        /*public override void AddRecipes()
        {
            Mod CalamityMod = ModLoader.GetMod("CalamityMod");
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.GoldCoin, 100);
            recipe.AddIngredient(ItemID.Sapphire, 1);
            recipe.AddIngredient(ItemID.GoldBroadsword, 1);
            recipe.AddIngredient(ItemID.GoldBar, 420);

            if (CalamityMod != null && CalamityMod.TryFind<ModItem>("LifeAlloy", out ModItem LifeAlloy))
            {
                recipe.AddIngredient(LifeAlloy.Type, 6);
            }
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }*/
    }
}
