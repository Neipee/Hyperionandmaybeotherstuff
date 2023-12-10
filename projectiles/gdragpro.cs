using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hyperionandmaybeotherstuff.projectiles
{
	public class gdragpro : ModProjectile
	{
        public override void SetStaticDefaults() {
            Main.projPet[Projectile.type] = true;
        }

        public override void SetDefaults() {
            Projectile.light = 1f;
            Projectile.CloneDefaults(ProjectileID.Wisp); // Copy the stats of the Zephyr Fish

            AIType = ProjectileID.ZephyrFish; // Copy the AI of the Zephyr Fish.
        }

        public override bool PreAI() {
            Player player = Main.player[Projectile.owner];

            player.zephyrfish = false; // Relic from aiType

            return true;
        }

        public override void AI() {
            Player player = Main.player[Projectile.owner];

            // Keep the projectile from disappearing as long as the player isn't dead and has the pet buff.
            if (!player.dead && player.HasBuff(ModContent.BuffType<buffs.gdragbuff>())) {
                Projectile.timeLeft = 2;
            }

	    }
	}
}