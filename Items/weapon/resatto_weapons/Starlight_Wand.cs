using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Security.Cryptography.X509Certificates;
using Terraria.Audio;
using System.Collections.Generic;

namespace Hyperionandmaybeotherstuff.Items.weapon.resatto_weapons
{
    public class Starlight_Wand : ModItem
    {
        private string[] son = { "Thunder_0", "Thunder_5", "Thunder_6" }; // Add more shop names as needed
        public override void SetStaticDefaults()
        {

        }

        public override void SetDefaults()
        {
            Item.damage = 15;
            Item.DamageType = DamageClass.Magic;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 30;
            Item.useAnimation = 15;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(gold: 1);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("Starlightproj").Type;
            Item.shootSpeed = 10f;
            Item.mana = 8;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int nbdetile = (int)Math.Round((player.Center.X - Main.MouseWorld.X) / 16);
            Vector2 spawnPosition = Main.MouseWorld;

            if (-21 < nbdetile && nbdetile < 21)
            {
                for (int i = 0; i < 20; i++)
                {
                    spawnPosition.X = Main.MouseWorld.X + Main.rand.NextFloat(-32f, 32f);
                    Vector2 direction = new Vector2(0, 1);
                    direction.Normalize();
                    Vector2 provelocity = direction * 3f;

                    Projectile.NewProjectileDirect(source, spawnPosition, provelocity, type, damage, knockback, player.whoAmI, i);
                }
            }
            else
            {
                if (nbdetile < -20)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        spawnPosition.X = player.Center.X + Main.rand.NextFloat(-32f, 32f)+(20*16);
                        Vector2 direction = new Vector2(0, 1); // La composante Y positive indique la direction vers le bas
                        direction.Normalize();
                        Vector2 provelocity = direction * 3f; // Set initial velocity towards player's cursor
                        Projectile.NewProjectileDirect(source, spawnPosition, provelocity, type, damage, knockback, player.whoAmI, i);
                    }
                }
                else
                {
                    for (int i = 0; i < 20; i++)
                    {
                        spawnPosition.X = player.Center.X + Main.rand.NextFloat(-32f, 32f)-(20*16);
                        Vector2 direction = new Vector2(0, 1); // La composante Y positive indique la direction vers le bas
                        direction.Normalize();
                        Vector2 provelocity = direction * 3f; // Set initial velocity towards player's cursor
                        Projectile.NewProjectileDirect(source, spawnPosition, provelocity, type, damage, knockback, player.whoAmI, i);
                    }
                }
            }

            return false;
        }
    }
}
