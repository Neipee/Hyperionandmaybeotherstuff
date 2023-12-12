using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Security.Cryptography.X509Certificates;

namespace Hyperionandmaybeotherstuff.Items.weapon.resatto_weapons
{
    public class Celeste_wand : ModItem
    {
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.damage = 40;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("Celestew_Proj").Type;
            Item.shootSpeed = 10f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int nbdetile = (int)Math.Round((player.Center.X - Main.MouseWorld.X)/16);
            Main.NewText($"Position de la souris : {Math.Round((player.Center.X - Main.MouseWorld.X) / 16)} testeste");
            if (nbdetile < 20 || nbdetile > -20)
            {

                Vector2 spawnPosition = player.Center - Main.MouseWorld;
                Projectile.NewProjectileDirect(source, spawnPosition , velocity, type, damage, knockback, player.whoAmI);  
            }
            return false;
        }
    }
}
