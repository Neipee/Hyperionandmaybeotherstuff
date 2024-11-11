using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using System.Threading;
using System.Windows.Forms;



namespace Hyperionandmaybeotherstuff.Items.weapon
{
    public class Pigman_sword : ModItem
    {
        
        public override void SetStaticDefaults()
        {
            Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(6, 26));
        }

        public override void SetDefaults()
        {
            Item.damage = 200;
            Item.DamageType = DamageClass.Melee;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 5;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = Mod.Find<ModProjectile>("or").Type;
            Item.shootSpeed = 0f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            
            Vector2 playerPos = player.Center;
            Vector2 cursorPos = Main.MouseWorld;
            float distance = Vector2.Distance(playerPos, cursorPos);
            int numProjectiles = (int)(distance / 35f);
            for (float i = 0; i < numProjectiles; i++)
            {
                
                float segmentFraction = (float)i / (float)(numProjectiles - 1);
                Vector2 spawnPosition = Vector2.Lerp(playerPos, cursorPos, segmentFraction);
                spawnPosition.Y -= 16f;
                Projectile.NewProjectileDirect(source, spawnPosition , velocity, type, damage, knockback, player.whoAmI, i*2f+10f);  

            }
            

            return false; // Retourne false car nous ne voulons pas que tModLoader génère de projectiles
        }
    }
}
