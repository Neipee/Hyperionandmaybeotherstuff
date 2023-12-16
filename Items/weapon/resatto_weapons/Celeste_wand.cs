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
    public class Celeste_wand : ModItem
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
            Item.shoot = Mod.Find<ModProjectile>("Celestew_Proj").Type;
            Item.shootSpeed = 10f;
            Item.mana = 8;
        }
    public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
    {
        int nbdetile = (int)Math.Round((player.Center.X - Main.MouseWorld.X) / 16);
        Main.NewText($"Position de la souris en X : {Math.Round((player.Center.X - Main.MouseWorld.X) / 16)} testeste");
        /*Main.NewText($"Position de la souris en Y : {Main.MouseWorld.Y} testeste");
        Main.NewText($"Position du projectile en Y : {Main.screenPosition.Y - Main.projectile[Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI)].height} testeste");*/
        float distopscreenmouse = (int)Math.Round((Main.MouseWorld.Y - (Main.screenPosition.Y - Main.projectile[Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI)].height))/16);
        //Main.NewText($"testestest {distopscreenmouse}");
        string sonale = son[Main.rand.Next(0, 3)];
        Vector2 spawnPosition = Main.MouseWorld;
        spawnPosition.Y = Main.screenPosition.Y - Main.projectile[Projectile.NewProjectile(source, position, velocity, type, damage, knockback, player.whoAmI)].height;
        Main.NewText($"pos de position ??{position}");

        if (-21 < nbdetile && nbdetile < 21)
        {
            spawnPosition.X = Main.MouseWorld.X;
            for (int i = 0; i < distopscreenmouse / 1.8; i++)
            {
                // Créer un nouveau projectile
                Projectile.NewProjectileDirect(source, spawnPosition, velocity, type, damage, knockback, player.whoAmI, i+1f);
                Main.NewText($"pos joueur{player.position}");
                // Jouer le son sélectionné
                SoundStyle style = new SoundStyle("Terraria/Sounds/" + sonale) with { Volume = .41f,  PitchVariance = .61f,};
                SoundEngine.PlaySound(style);

                // Augmenter la position Y pour le prochain projectile
                spawnPosition.Y += 30f;
            }
        }
        else
        {
            if (nbdetile < -20)
            {
                spawnPosition.X = player.Center.X + 20*16;
                for (int i = 0; i < distopscreenmouse/1.8; i++)
                {
                    Projectile.NewProjectileDirect(source, spawnPosition, velocity, type, damage, knockback, player.whoAmI, i+1f);
                    SoundStyle style = new SoundStyle("Terraria/Sounds/" + sonale) with { Volume = .41f,  PitchVariance = .61f, };
                    SoundEngine.PlaySound(style);
                    spawnPosition.Y += 30f;
                }
            }
            else
            {
                spawnPosition.X = player.Center.X - 20*16;
                for (int i = 0; i < distopscreenmouse/1.8; i++)
                {
                    Projectile.NewProjectileDirect(source, spawnPosition, velocity, type, damage, knockback, player.whoAmI, i+1f);
                    SoundStyle style = new SoundStyle("Terraria/Sounds/" + sonale) with { Volume = .41f,  PitchVariance = .61f, };
                    SoundEngine.PlaySound(style);
                    spawnPosition.Y += 30f;
                }
            }
        }

        return false;
    }
    }
}
