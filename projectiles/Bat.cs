using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;



namespace Hyperionandmaybeotherstuff.projectiles
{
    public class Bat : ModProjectile
    {
     
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sword Projectile");
            Main.projFrames[Projectile.type] = 25;
        }

        public override void SetDefaults()
        {
            Projectile.width = 11;
            Projectile.height = 10;
            DrawOffsetX = -17;
            DrawOriginOffsetY = -15; 
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.timeLeft = 700;
            Projectile.penetrate = 900;
            Projectile.ignoreWater = true;
            Projectile.damage = 200;
        }


        public override void AI()
        {
            if (++Projectile.frameCounter >= 1)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }

            Vector2 cursorPosition = Main.MouseWorld;
            Vector2 direction = cursorPosition - Projectile.BottomRight;
            direction.Normalize();
            float speed = 7f;
            Projectile.velocity.Y = direction.Y * speed;

            Player player = Main.player[Projectile.owner];
            if (cursorPosition.X < player.Center.X)
            {
                Projectile.spriteDirection = 1;
                Projectile.velocity.X = -Math.Abs(speed); 
            }
            else
            {
                Projectile.spriteDirection = -1;
                Projectile.velocity.X = Math.Abs(speed); 
            }
            Projectile.light = 0.1f;
        }
       
    }
}

/*            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Honey2, Projectile.velocity.X , Projectile.velocity.Y , 0, default, 1f);
            Main.dust[dust].noGravity = true;
            Main.dust[dust].velocity *= Main.rand.NextFloat(1f ,2f);

            int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X , Projectile.velocity.Y+1f , 0, default, 2f);
            Main.dust[dust2].noGravity = true;  */