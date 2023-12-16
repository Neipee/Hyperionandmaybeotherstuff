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
    public class midas_staff : ModItem
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
            Item.shoot = Mod.Find<ModProjectile>("or").Type;
            Item.shootSpeed = 0f;
            Item.mana = 20;
        }


        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            
            // Position du joueur et du curseur
            Vector2 playerPos = player.Center;
            Vector2 cursorPos = Main.MouseWorld;

            // Calcul de la distance entre le joueur et le curseur
            float distance = Vector2.Distance(playerPos, cursorPos);

            // Calculez le nombre de projectiles en fonction de la distance (ajustez ces valeurs selon vos besoins)
            int numProjectiles = (int)(distance / 35f); // Vous pouvez ajuster 20f selon vos préférences

            // Limitez le nombre de projectiles générés pour éviter la surcharge
            //numProjectiles = MathHelper.Clamp(numProjectiles, 1, 20); // Limitez entre 1 et 20 projectiles (ajustez selon vos préférences)
          

            for (float i = 0; i < numProjectiles; i++)
            {
                
                float segmentFraction = (float)i / (float)(numProjectiles - 1);
                Vector2 spawnPosition = Vector2.Lerp(playerPos, cursorPos, segmentFraction);
                spawnPosition.Y -= 16f;
                Projectile.NewProjectileDirect(source, spawnPosition , velocity, type, damage, knockback, player.whoAmI, i*2f+10f);  

            }
            

            return false; // Retourne false car nous ne voulons pas que tModLoader génère de projectiles
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








        

        
		/*public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			// The humber of projectiles that this gun will shoot.
            Vector2 playerPos = player.Center;
            Vector2 cursorPos = Main.MouseWorld;

            const int NumProjectiles = 8; 
			for (int i = 0; i < NumProjectiles; i++) {
				// Rotate the velocity randomly by 30 degrees at max.
				//Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));
                float segmentFraction = (float)i / (float)(NumProjectiles - 1); // Fraction de la distance
                Vector2 spawnPosition = Vector2.Lerp(playerPos, cursorPos, segmentFraction);
				// Decrease velocity randomly for nicer visuals.
				//newVelocity *= 1f - Main.rand.NextFloat(0.3f);

				// Create a projectile.
				Projectile.NewProjectileDirect(source, spawnPosition, velocity, type, damage, knockback, player.whoAmI);
			}

			return false; // Return false because we don't want tModLoader to shoot projectile
		}*/
        /*public bool Shoot(Player player, EntitySource_ItemUse source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) 
        {
            Vector2 playerPos = player.Center;
            Vector2 cursorPos = Main.MouseWorld;
            int numberOfProjectiles = 10;
            for (int i = 0; i < numberOfProjectiles; i++)
            {
                float segmentFraction = (float)i / (float)(numberOfProjectiles - 1); // Fraction de la distance
                Vector2 spawnPosition = Vector2.Lerp(playerPos, cursorPos, segmentFraction);
                Projectile.NewProjectile(source, spawnPosition, velocity, type, damage, knockback, Main.myPlayer);

            }
            return false;
        }*/
    }
}
