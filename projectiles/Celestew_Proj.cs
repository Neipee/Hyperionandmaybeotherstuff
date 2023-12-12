using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;

namespace Hyperionandmaybeotherstuff.projectiles
{
    public class Celestew_Proj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
        }

 public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 120;
        }

        public override void AI()
        {
         if (Projectile.ai[0] == 0f) // If AI flag is 0, set initial position and velocity
            {
                Projectile.position.Y = Main.screenPosition.Y - Projectile.height; // Spawn projectile at top of screen
                if(Main.MouseWorld.X > 10f*16f) 
                {
                    Projectile.position.X = Main.MouseWorld.X; // Set X position to player's cursor position
                    Main.NewText("mouse sup a 10tiles");
                    //Main.NewText($"position de la souris:{Main.MouseWorld.X - player.Center.X}");
                }
                else
                {
                    Projectile.position.X = 10f *16f; // Set X position to player's cursor position
                    Main.NewText("mouse inferieur a 10tiles ");

                }
                Vector2 direction = Main.MouseWorld - Projectile.Center; // Calculate direction towards player's cursor
                direction.Normalize();
                Projectile.velocity = direction * 50f; // Set initial velocity towards player's cursor
                Projectile.ai[0] = 1f; // Set AI flag to 1 to prevent this code from running again
            }

            // Rotate projectile based on its velocity
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            // Spawn dust effect
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 16, 0f, 0f, 0, default(Color), 1f);
            Main.dust[dust].velocity = Projectile.velocity * 0.1f;
        }

        /*private int Target()
        {
            int target = -1;
            float distance = 160f; // Maximum distance for lightning strike
            for (int k = 0; k < Main.maxNPCs; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    float currentDistance = Vector2.Distance(Projectile.Center, Main.npc[k].Center);
                    if (currentDistance < distance)
                    {
                        distance = currentDistance;
                        target = k;
                    }
                }
            }
            return target;
        }*/
            // Add logic for lightning strike effect here
            // You can use projectile.localAI[0] to track additional information
    }
}
