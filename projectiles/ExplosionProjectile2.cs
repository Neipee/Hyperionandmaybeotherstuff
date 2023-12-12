using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace Hyperionandmaybeotherstuff.projectiles
{
    public class ExplosionProjectile2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Explosion Projectile");
            Main.projFrames[Projectile.type] = 16;
        }
        public override void SetDefaults()
        {
            Projectile.light = 1f;
            Projectile.width = 411;
            Projectile.height = 423;
            Projectile.aiStyle = 6; // Don't use any AI style
            Projectile.timeLeft = 50; // Only exist for 1 tick
            Projectile.friendly = true;
            Projectile.penetrate = 1000;
			Projectile.hostile = false;
            Projectile.tileCollide = false; // Doesn't collide with tiles
            Projectile.ignoreWater = true; // Ignores water
        }
        public override void AI()
        {
            // Get the player instance
            Player player = Main.player[Projectile.owner];

            // Set the projectile's position to the player's position
            Projectile.position = player.Center - new Vector2(Projectile.width / 2 + 25 , Projectile.height / 2 + 25);

			if (++Projectile.frameCounter >= 3) {
				Projectile.frameCounter = 0;
				// Or more compactly Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
				if (++Projectile.frame >= Main.projFrames[Projectile.type])
					Projectile.frame = 0;
			}
            
            for (int i = 0; i < 5; i++)
            {
	    		int dust = Dust.NewDust(Projectile.Center- new Vector2(5, 5), 150, 150, DustID.Snow, 5f, 5f, 0, default(Color), 1f);
	    		Main.dust[dust].velocity *= 0.9f;
	    		Main.dust[dust].scale = (float)Main.rand.Next(1, 115) * 0.013f;
	    		Main.dust[dust].noGravity = true;

	    		int dust2 = Dust.NewDust(Projectile.Center - new Vector2(0, 145), 150, 150, DustID.Snow, 5f, -5f, 10, default(Color), 1f);
	    		Main.dust[dust2].velocity *= 0.3f;
	    		Main.dust[dust2].scale = (float)Main.rand.Next(1, 115) * 0.013f;
	    		Main.dust[dust2].noGravity = true;

                int dust3 = Dust.NewDust(Projectile.Center - new Vector2(145, 0), 150, 150, DustID.Snow, -5f, 5f, 0, default(Color), 1f);
			    Main.dust[dust3].velocity *= 0.3f;
		    	Main.dust[dust3].scale = (float)Main.rand.Next(20, 115) * 0.013f;
	    		Main.dust[dust3].noGravity = true;

                int dust4 = Dust.NewDust(Projectile.Center - new Vector2(145, 145), 150, 150, DustID.Snow, -5f, -5f, 0, default(Color), 1f);
			    Main.dust[dust4].velocity *= 0.3f;
			    Main.dust[dust4].scale = (float)Main.rand.Next(20, 115) * 0.013f;
			    Main.dust[dust4].noGravity = true;

                int dust5 = Dust.NewDust(Projectile.Center + new Vector2(30, 0), 10, 20, DustID.MartianHit, 5f, 0f, 0, default(Color), 1f);
			    Main.dust[dust5].velocity *= 0.3f;
		    	Main.dust[dust5].scale = (float)Main.rand.Next(20, 115) * 0.025f;
	    		Main.dust[dust5].noGravity = true;
            }
		}
        
        

        /*public override void Kill(int timeLeft)
        {
            // Spawn an explosion in a 5-tile radius
            Projectile.NewProjectile(projectile.Center, Vector2.Zero, ProjectileID.Explosives, projectile.damage, projectile.knockBack, Main.myPlayer, 0, 0);
            Main.PlaySound(SoundID.Item14, projectile.Center); // Play the explosion sound effect
        }*/
    }
}
