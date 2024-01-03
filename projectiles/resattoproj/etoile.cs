using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Hyperionandmaybeotherstuff.projectiles.resattoproj
{
	// Token: 0x02000A40 RID: 2624
	public class etoile : ModProjectile, ILocalizedModType, IModType
	{
		// Token: 0x17001086 RID: 4230
		// (get) Token: 0x060052EE RID: 21230 RVA: 0x0020DCBE File Offset: 0x0020BEBE

		// Token: 0x17001087 RID: 4231
		// (get) Token: 0x060052EF RID: 21231 RVA: 0x0018E6A2 File Offset: 0x0018C8A2

		// Token: 0x060052F0 RID: 21232 RVA: 0x0028768C File Offset: 0x0028588C
		public override void SetDefaults()
		{
			base.Projectile.width = 8;
			base.Projectile.height = 8;
			base.Projectile.friendly = true;
			base.Projectile.extraUpdates = 1;
			base.Projectile.penetrate = 1;
			base.Projectile.ignoreWater = true;
			base.Projectile.timeLeft = 60;
			base.Projectile.DamageType = DamageClass.Melee;
		}

		// Token: 0x060052F1 RID: 21233 RVA: 0x00287700 File Offset: 0x00285900
		public override void AI()
		{
			Lighting.AddLight(base.Projectile.Center, 0.2f, 0.2f, 0.2f);
			for (int i = 0; i < 2; i++)
			{
				int num = Dust.NewDust(new Vector2(base.Projectile.position.X, base.Projectile.position.Y), base.Projectile.width, base.Projectile.height, DustID.GemDiamond, 0f, 0f, 100, default(Color), 1.25f);
				Main.dust[num].noGravity = true;
				Main.dust[num].velocity *= 0.5f;
				Main.dust[num].velocity += base.Projectile.velocity * 0.1f;
			}
		}
	}
}
