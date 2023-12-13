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
            Projectile.timeLeft = 1200;
            Projectile.tileCollide = true;
        }
        private float timer = 0;

        public override void AI()
        {
            timer += 1f;
            if (Projectile.ai[0] == 0f) // If AI flag is 0, set initial position and velocity
            {
                Projectile.position.Y = Main.screenPosition.Y - Projectile.height; // Spawn projectile at top of screen
                Projectile.position.X = Main.MouseWorld.X; // Set X position to player's cursor position
                Vector2 direction = Main.MouseWorld - Projectile.Center; // Calculate direction towards player's cursor
                direction.Normalize();
                Projectile.velocity = direction * 3f; // Set initial velocity towards player's cursor
                Projectile.rotation = 1.6f;
                Projectile.ai[0] = 1f; // Set AI flag to 1 to prevent this code from running again
            }
            // Rotate projectile based on its velocity

            // Spawn dust effect
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Electric, 0f, 0f, 0, default(Color), 1.2f);
            Main.dust[dust].velocity = Projectile.velocity * 0f;
            Main.dust[dust].noGravity = true;
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
