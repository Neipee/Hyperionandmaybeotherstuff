using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Security.Cryptography.X509Certificates;
using Terraria.Audio;
using System.Collections.Generic;
using Hyperionandmaybeotherstuff.Items.armor.Starlight_Set;
using System.Threading;

namespace Hyperionandmaybeotherstuff.Items.weapon.resatto_weapons
{
    public class Starlight_Wand : ModItem
    {
        private string[] son = { "Thunder_0", "Thunder_5", "Thunder_6" }; // Add more shop names as needed
        private int shootTimer=0;
        private int Timer =120;
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
            Item.shoot = Mod.Find<ModProjectile>("starrain").Type;
            Item.shootSpeed = 10f;
            Item.mana = 12;
        }

        private int baseRange = 21; // Portée de base de l'arme
       public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            int range = baseRange; // Portée par défaut de l'arme
            Starlight_Helmet helmet = player.armor[0].ModItem as Starlight_Helmet;
            Starlight_Breastplate breastplate = player.armor[1].ModItem as Starlight_Breastplate;
            Starlight_Leggings leggings = player.armor[2].ModItem as Starlight_Leggings;

            // Ajouter une temporisation de 2 secondes
            if (shootTimer <= 0) // 60 mises à jour par seconde, donc 120 mises à jour équivalent à 2 secondes
            {
                if (helmet != null && breastplate != null && leggings != null)
                {
                    // Si l'ensemble est équipé, augmenter la portée de l'arme
                    range = 24; // Nouvelle portée de l'arme
                    int nbdetile = (int)Math.Round((player.Center.X - Main.MouseWorld.X) / 16);
                    Vector2 spawnPosition = Main.MouseWorld;

                    if (-range < nbdetile && nbdetile < range)
                    {
                        Vector2 zeroVelocity = Vector2.Zero;
                        Projectile.NewProjectileDirect(source, spawnPosition, zeroVelocity, type, damage, knockback, player.whoAmI);
                    }
                    else
                    {
                        if (nbdetile < -range-1)
                        {
                            spawnPosition.X = player.Center.X + (23 * 16);
                            Vector2 zeroVelocity = Vector2.Zero;
                            Projectile.NewProjectileDirect(source, spawnPosition, zeroVelocity, type, damage, knockback, player.whoAmI);
                        }
                        else
                        {
                            spawnPosition.X = player.Center.X - (23 * 16);
                            Vector2 zeroVelocity = Vector2.Zero;
                            Projectile.NewProjectileDirect(source, spawnPosition, zeroVelocity, type, damage, knockback, player.whoAmI);
                        }
                    }
                }
                else
                {
                    int nbdetile = (int)Math.Round((player.Center.X - Main.MouseWorld.X) / 16);
                    Vector2 spawnPosition = Main.MouseWorld;

                    if (-21 < nbdetile && nbdetile < 21)
                    {
                        Vector2 zeroVelocity = Vector2.Zero;
                        Projectile.NewProjectileDirect(source, spawnPosition, zeroVelocity, type, damage, knockback, player.whoAmI);
                    }
                    else
                    {
                        if (nbdetile < -20)
                        {
                            spawnPosition.X = player.Center.X + (20 * 16);
                            Vector2 zeroVelocity = Vector2.Zero;
                            Projectile.NewProjectileDirect(source, spawnPosition, zeroVelocity, type, damage, knockback, player.whoAmI);
                        }
                        else
                        {
                            spawnPosition.X = player.Center.X - (20 * 16);
                            Vector2 zeroVelocity = Vector2.Zero;
                            Projectile.NewProjectileDirect(source, spawnPosition, zeroVelocity, type, damage, knockback, player.whoAmI);
                        }
                    }
                }
                shootTimer = Timer; // Réinitialiser le compteur de temporisation
            }

            return false;
        }

        public override void UpdateInventory(Player player)
        {
            if (shootTimer > 0)
            {
                // Mettre à jour le compteur de temporisation chaque frame lorsque l'objet est tenu
                shootTimer--;
            }
        }
    }
}
