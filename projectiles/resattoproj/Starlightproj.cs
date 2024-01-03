using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System;
using Terraria.Graphics.Shaders;
using Terraria.Audio;


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



		public override void AI()
		{
			this.whiteLightTimer--;
			if (this.whiteLightTimer == 0)
			{
				float num = 3.132f;
				double num2 = Math.Atan2((double)base.Projectile.velocity.X, (double)base.Projectile.velocity.Y) - (double)(num / 2f);
				double num3 = (double)(num / 8f);
				if (base.Projectile.owner == Main.myPlayer)
				{
					for (int i = 0; i < 1; i++)
					{
						double num4 = num2 + num3 * (double)(i + i * i) / 2.0 + (double)(32f * (float)i);
						int num5 = Projectile.NewProjectile(base.Projectile.GetSource_FromThis(null), base.Projectile.Center.X, base.Projectile.Center.Y, (float)(Math.Sin(num4) * 5.0), (float)(Math.Cos(num4)*5.0), ModContent.ProjectileType<etoile>(), base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f, 0f);
						int num6 = Projectile.NewProjectile(base.Projectile.GetSource_FromThis(null), base.Projectile.Center.X, base.Projectile.Center.Y, (float)(-(float)Math.Sin(num4) * 5.0), (float)(-(float)Math.Cos(num4) * 5.0), ModContent.ProjectileType<etoile>(), base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f, 0f);
						Projectile projectile = Main.projectile[num5];
						projectile.velocity.X = projectile.velocity.X * 0.1f;
						Projectile projectile2 = Main.projectile[num5];
						projectile2.velocity.Y = projectile2.velocity.Y * 0.1f;
						Projectile projectile3 = Main.projectile[num6];
						projectile3.velocity.X = projectile3.velocity.X * 0.1f;
						Projectile projectile4 = Main.projectile[num6];
						projectile4.velocity.Y = projectile4.velocity.Y * 0.1f;
					}
				}
				this.whiteLightTimer = 5;
			}
			Lighting.AddLight(base.Projectile.Center, (float)(255 - base.Projectile.alpha) * 0.5f / 255f, (float)(255 - base.Projectile.alpha) * 0.5f / 255f, (float)(255 - base.Projectile.alpha) * 0.5f / 255f);
			for (int j = 0; j < 2; j++)
			{
				int num7 = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, DustID.GemDiamond, 0f, 0f, 100, default(Color), 1.25f);
				Main.dust[num7].noGravity = true;
				Main.dust[num7].velocity *= 0.5f;
				Main.dust[num7].velocity += base.Projectile.velocity * 0.1f;
			}
		}

		// Token: 0x06004C89 RID: 19593 RVA: 0x0024D170 File Offset: 0x0024B370
		public override void OnKill(int timeLeft)
		{
			//SoundEngine.PlaySound(ref SoundID.Item122, new Vector2?(base.Projectile.position), null);
			if (base.Projectile.owner == Main.myPlayer)
			{
				Projectile.NewProjectile(base.Projectile.GetSource_FromThis(null), base.Projectile.Center.X, base.Projectile.Center.Y - 100f, 0f, 0f, ModContent.ProjectileType<starrain>(), base.Projectile.damage, base.Projectile.knockBack, base.Projectile.owner, 0f, 0f, 0f);
			}
		}

		// Token: 0x04000B59 RID: 2905
		private int whiteLightTimer = 5;





        /*private float timer = 0;

        public override void AI()
        {
            timer += 1f;
            if (timer % 20 == 0)
            {
                Projectile.rotation = Main.rand.NextFloat(1.2f, 1.9f);
            }

                //Projectile.velocity.Y=50f;
            if (timer % 10 == 0)
            {

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
        }*/
    }
}
