using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using Terraria.Graphics.Shaders;



namespace Hyperionandmaybeotherstuff.projectiles.resattoproj
{
    public class Starlightproj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //Main.RegisterItemAnimation(Projectile.type, new DrawAnimationVertical(6, 4));
            //Main.projFrames[Projectile.type] = 4;
        }

 public override void SetDefaults()
        {
            Projectile.width = 32;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.aiStyle = -1;
            Projectile.penetrate = 999;
            Projectile.timeLeft = 150;
            Projectile.tileCollide = true;
            Projectile.scale= 0.5f;
            Projectile.rotation = Main.rand.NextFloat(1.2f, 1.9f);
        }
        private float timer = 0;

        public override void AI()
        {

            /*if (++Projectile.frameCounter >= 4) 
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= Main.projFrames[Projectile.type])
                    Projectile.frame = 0;
            }*/
            timer += 1f;
            if (timer % 20 == 0)
            {
                Projectile.rotation = Main.rand.NextFloat(1.2f, 1.9f);
            }

                //Projectile.velocity.Y=50f;
            if (timer % 10 == 0)
            {
                /*int dust = Dust.NewDust(Projectile.position, Projectile.height, Projectile.width, DustID.GolfPaticle, 1f, 1f, 71, new Color(255,255,255), 1f);
                Main.dust[dust].velocity = Projectile.velocity * 0f;
                Main.dust[dust].noGravity = true;*/
                if (Main.rand.NextFloat() < 0.9302326f)
                {
                    Dust dust1;
                    // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                    Vector2 position = Projectile.position;
                    dust1 = Main.dust[Terraria.Dust.NewDust(position, 30, 30, DustID.Electric, 0f, 0f, 0, new Color(255,255,255), 0.8139535f)];
                    dust1.noGravity = true;
                    dust1.shader = GameShaders.Armor.GetSecondaryShader(32, Main.LocalPlayer);
                } 
            }
        }
    }
}
