using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Hyperionandmaybeotherstuff.Items.armor.Starlight_Set;
using Terraria.DataStructures;


namespace Hyperionandmaybeotherstuff.projectiles.resattoproj
{
	// Token: 0x02000A3F RID: 2623
	public class starrain : ModProjectile, ILocalizedModType, IModType
	{
		// Token: 0x17001084 RID: 4228
		// (get) Token: 0x060052E9 RID: 21225 RVA: 0x0020DCBE File Offset: 0x0020BEBE
		// Token: 0x060052EB RID: 21227 RVA: 0x00287398 File Offset: 0x00285598
		public override void SetDefaults()
		{            
			base.Projectile.width = 8;
			base.Projectile.height = 8;
			base.Projectile.tileCollide = false;
			base.Projectile.ignoreWater = true;
			base.Projectile.penetrate = -1;
			Projectile.timeLeft = 600;

        }
private int timer=300;
		// Token: 0x060052EC RID: 21228 RVA: 0x002873F4 File Offset: 0x002855F4
		public override void AI()
		{
            Player player = Main.player[base.Projectile.owner];
            bool hasStarlightSet = player.armor[0].type == ModContent.ItemType<Starlight_Helmet>() &&
                                   player.armor[1].type == ModContent.ItemType<Starlight_Breastplate>() &&
                                   player.armor[2].type == ModContent.ItemType<Starlight_Leggings>();
            if (hasStarlightSet)
            {
            }
            else
            {
				if (timer > 0)
				{
					timer --;
				}
				else
				{
					Projectile.Kill();
				}
            }
            
            	
			base.Projectile.ai[1] += 1f;
			if (base.Projectile.ai[1] >= 6700f)
			{
				base.Projectile.alpha += 5;
				if (base.Projectile.alpha > 255)
				{
					base.Projectile.alpha = 255;
					base.Projectile.Kill();
				}
			}
			else
			{
				base.Projectile.ai[0] += 1f;
				if (base.Projectile.ai[0] > 2f)
				{
					base.Projectile.ai[0] = 0f;
					if (base.Projectile.owner == Main.myPlayer)
					{
                        int num = (int)(base.Projectile.position.X + (float)Main.rand.Next(-100, 100)); // Ajustez les valeurs min et max selon vos besoins
						int num2 = (int)(base.Projectile.position.Y + (float)base.Projectile.height + 4f);
						Projectile.NewProjectile(base.Projectile.GetSource_FromThis(null), (float)num, (float)num2, 0f, 5f, ModContent.ProjectileType<whiterain>(), base.Projectile.damage, 0f, base.Projectile.owner, 0f, 0f, 0f);
					}
				}
                for (int d = -110; d < 110; d+=8)
                {
                    if (-50 < d && d < 50)
                    {
                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = Main.LocalPlayer.Center;
                        dust = Main.dust[Terraria.Dust.NewDust(new Vector2(base.Projectile.Center.X+d, base.Projectile.Center.Y-37), 0, Main.rand.Next(20,85), DustID.Cloud, 0f, Main.rand.NextFloat(-1f,1f), 35, new Color(255,255,255), 1.4534883f)];
                        dust.noGravity = true;
                        dust.fadeIn = 0.69767445f;
                    }
                    else
                    {
                        Dust dust;
                        // You need to set position depending on what you are doing. You may need to subtract width/2 and height/2 as well to center the spawn rectangle.
                        Vector2 position = Main.LocalPlayer.Center;
                        dust = Main.dust[Terraria.Dust.NewDust(new Vector2(base.Projectile.Center.X+d, base.Projectile.Center.Y-20), 0, Main.rand.Next(0,65), DustID.Cloud, 0f, Main.rand.NextFloat(-1f,1f), 35, new Color(255,255,255), 1.4534883f)];
                        dust.noGravity = true;
                        dust.fadeIn = 0.69767445f;
                    }
                }
			}
			base.Projectile.localAI[0] += 1f;
			if (base.Projectile.localAI[0] >= 10f)
			{
				base.Projectile.localAI[0] = 0f;
				int num3 = 0;
				int num4 = 0;
				float num5 = 0f;    
				int type = base.Projectile.type;
				for (int i = 0; i < 1000; i++)
				{
					if (Main.projectile[i].active && Main.projectile[i].owner == base.Projectile.owner && Main.projectile[i].type == type && Main.projectile[i].ai[1] < 3600f)
					{
						num3++;
						if (Main.projectile[i].ai[1] > num5)
						{
							num4 = i;
							num5 = Main.projectile[i].ai[1];
						}
					}
				}
				if (num3 > 1)
				{
					Main.projectile[num4].netUpdate = true;
					Main.projectile[num4].ai[1] = 36000f;
				}
			}
		}
	}
}
