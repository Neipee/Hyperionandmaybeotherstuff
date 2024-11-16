using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace Hyperionandmaybeotherstuff.Items.weapon
{
    public class emerald_blade : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sword");
            // Tooltip.SetDefault("Throws a projectile");
        }

        public override void SetDefaults()
        {
            Item.damage = 100;
            Item.DamageType = DamageClass.Melee;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(silver: 50);
            Item.rare = ItemRarityID.Blue;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
			Item.shoot = Mod.Find<ModProjectile>("emerald_blade_swing").Type;
            Item.shootSpeed = 12f;
            Item.noMelee = true;
			Item.shootsEveryUse = true;

        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback) {
			float adjustedItemScale = player.GetAdjustedItemScale(Item); // Get the melee scale of the player and item.
			Projectile.NewProjectile(source, player.MountedCenter, new Vector2(player.direction, 0f), type, damage, knockback, player.whoAmI, player.direction * player.gravDir, player.itemAnimationMax, adjustedItemScale);
			NetMessage.SendData(MessageID.PlayerControls, -1, -1, null, player.whoAmI); // Sync the changes in multiplayer.

			return base.Shoot(player, source, position, velocity, type, damage, knockback);
		}

        public override void UpdateInventory(Player player)
        {
            long purseValue = PlayerPurseHelper.GetPlayerPurse(player);
            int bonusDamage = (int)(purseValue / 100000);
            Item.damage = 100 + bonusDamage;
            base.UpdateInventory(player);
        }
        public class PlayerPurseHelper
        {
            /// <summary>
            /// Calculates the total coin value in the player's inventory (purse).
            /// </summary>
            /// <param name="player">The player to check.</param>
            /// <returns>The total coin value in copper.</returns>
            public static long GetPlayerPurse(Player player)
            {
                long totalCopper = 0;

                // Iterate through the player's inventory to sum up coin values
                foreach (var item in player.inventory)
                {
                    if (item != null && item.stack > 0)
                    {
                        switch (item.type)
                        {
                            case ItemID.CopperCoin:
                                totalCopper += item.stack;
                                break;
                            case ItemID.SilverCoin:
                                totalCopper += item.stack * 100; // 1 Silver = 100 Copper
                                break;
                            case ItemID.GoldCoin:
                                totalCopper += item.stack * 10000; // 1 Gold = 10,000 Copper
                                break;
                            case ItemID.PlatinumCoin:
                                totalCopper += item.stack * 1000000; // 1 Platinum = 1,000,000 Copper
                                break;
                        }
                    }
                }

                return totalCopper;
            }
        }
    }
}
