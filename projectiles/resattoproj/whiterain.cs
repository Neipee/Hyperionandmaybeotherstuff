using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hyperionandmaybeotherstuff.projectiles.resattoproj
{
	// Token: 0x02000A41 RID: 2625
	public class whiterain : ModProjectile, ILocalizedModType, IModType
	{
		// Token: 0x17001088 RID: 4232
		// (get) Token: 0x060052F3 RID: 21235 RVA: 0x0020DCBE File Offset: 0x0020BEBE

		// Token: 0x060052F5 RID: 21237 RVA: 0x002877F0 File Offset: 0x002859F0
		public override void SetDefaults()
		{
			base.Projectile.width = 4;
			base.Projectile.height = 4;
			base.Projectile.friendly = true;
			base.Projectile.extraUpdates = 1;
			base.Projectile.penetrate = 2;
			base.Projectile.ignoreWater = true;
			base.Projectile.tileCollide = false;
			base.Projectile.timeLeft = 150;
			base.Projectile.DamageType = DamageClass.Melee;
		}

		// Token: 0x060052F6 RID: 21238 RVA: 0x00287870 File Offset: 0x00285A70
		public override void AI()
		{
			if (base.Projectile.ai[1] == 0f)
			{
				base.Projectile.ai[1] = 1f;
			}
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
