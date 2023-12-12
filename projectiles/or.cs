using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;



namespace Hyperionandmaybeotherstuff.projectiles
{
    public class or : ModProjectile
    {
     
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sword Projectile");
        }

        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.aiStyle = -1;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.timeLeft = 700;
            Projectile.penetrate = 900;
            //Projectile.tileCollide = false; // Désactiver la collision avec les tuiles
            Projectile.ignoreWater = true;
        }


        private float timer = 0;
        public override void AI()
        {


            Projectile.alpha = 255;
            Projectile.damage = 0;
            Projectile.velocity.Y = 0f;
            timer += 1f;

            if (timer >= Projectile.ai[0]-8f) {
                Projectile.alpha = 0;
                Projectile.velocity.Y = -5f; 
            }
             if (timer >= Projectile.ai[0]-4f) {
                Projectile.velocity.Y = 2f; 
            }
			if (timer >= Projectile.ai[0]) 
            {
				// Fade out
                Projectile.damage = 200;
                Projectile.velocity.Y = 7f;
                Projectile.light = 1f;
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Honey2, Projectile.velocity.X , Projectile.velocity.Y , 0, default, 1f);
                Main.dust[dust].noGravity = true;
                Main.dust[dust].velocity *= Main.rand.NextFloat(1f ,2f);

                int dust2 = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X , Projectile.velocity.Y+1f , 0, default, 2f);
                Main.dust[dust2].noGravity = true;                
            }


            // Remettez le mouvement vertical si nécessaire
            
        }

        
    }
}

            /*Player player = Main.player[Projectile.owner]; // Récupérer le joueur propriétaire du projectile
            if (!projectileSpawned && Main.mouseLeft)
            {
                if (Projectile.ai[0] == 0) // S'assurer que le calcul n'est effectué qu'une fois
                {
                    Vector2 playerPos = player.Center;
                    Vector2 cursorPos = Main.MouseWorld;
                    int numberOfProjectiles = 10; // Nombre de projectiles à créer le long du segment

                    for (int i = 0; i < numberOfProjectiles; i++)
                    {
                        float segmentFraction = (float)i / (float)(numberOfProjectiles - 1); // Fraction de la distance
                        Vector2 spawnPosition = Vector2.Lerp(playerPos, cursorPos, segmentFraction);
                        Projectile.position.X = spawnPosition.X;
                        Projectile.position.Y = spawnPosition.Y;
                        Projectile.velocity.Y = 16f;
                        // Utiliser la méthode NewProjectile pour créer un nouveau projectile
                        //int newProjectileIndex = Projectile.NewProjectile(Projectile.GetSource_FromThis(), spawnPosition.X, spawnPosition.Y, 0f, 10f, ModContent.ProjectileType<or>(), Projectile.damage, 0f, player.whoAmI);

                        // Vous pouvez également définir d'autres paramètres du projectile ici si nécessaire
                        //Projectile newProjectile = Main.projectile[newProjectileIndex];
                        //newProjectile.velocity = Vector2.Zero;
                        Projectile.ai[0] = 1;
                    }

                     // Éviter de recalculer à chaque frame
                }
            }
            if (!Main.mouseLeft)
            {
                projectileSpawned = false;
            }*/
        
        /*public override void AI()
        {
            // Récupérer le joueur local
            Player player = Main.player[Projectile.owner];

            if (Projectile.ai[0] == 0f)
            {
                int projectileType = ModContent.ProjectileType<or>(); // Remplacez "or" par le nom du projectile que vous souhaitez créer
                Vector2 playerPos = player.Center;
                Vector2 cursorPos = Main.MouseWorld;
                Vector2 midPoint = playerPos + (cursorPos - playerPos) * 0.5f;
                Projectile.position = midPoint - new Vector2(Projectile.width / 2, Projectile.height / 2);
                Projectile.velocity.Y = 0f;
                //int newProjectile = Projectile.NewProjectile(Projectile.GetSource_FromThis(), midPointX, midPointY, 0.5f, 16f, projectileType, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);
                Projectile.ai[0] = 1f;
            }
        }*/
        /*public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Vector2 cursorPos = Main.MouseWorld;

            // Créer plusieurs projectiles
            int numberOfProjectiles = 2; // Vous pouvez ajuster le nombre de projectiles selon vos besoins

            for (int i = 0; i < numberOfProjectiles; i++)
            {
                int projectileType = ModContent.ProjectileType<or>();
                Vector2 playerPos = player.Center;
                Vector2 midPoint = playerPos + (cursorPos - playerPos) * 0.5f;
                float midPointX = midPoint.X;
                float midPointY = midPoint.Y;

                // Créer le projectile
                int newProjectile = Projectile.NewProjectile(Projectile.GetSource_FromThis(), midPointX, midPointY, 0f, 16f, projectileType, Projectile.damage, 0f, Main.myPlayer, 0f, 0f);

                // Ajuster la vitesse de chute du projectile si nécessaire
                Main.projectile[newProjectile].velocity.Y += Main.rand.NextFloat(1f, 3f); // Ajustez la vitesse de chute aléatoire
            }
        }*/

    

