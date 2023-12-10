using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hyperionandmaybeotherstuff.Items.weapon
{
    public class rodlike : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rod of Discord-Like");
            // Tooltip.SetDefault("Teleports the player to the cursor position\nHas a limited number of uses");
        }

        public override void SetDefaults()
        {
            Item.width = 24;
            Item.height = 24;
            Item.useTime = 60;
            Item.useAnimation = 60;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.value = Item.sellPrice(gold: 1);
            Item.rare = ItemRarityID.LightRed;
            Item.UseSound = SoundID.Item43;
            Item.autoReuse = false;
            Item.useTurn = true;
            Item.maxStack = 1;
            Item.consumable = false;
            Item.noUseGraphic = true;
            Item.noMelee = true;
        }

        public override bool CanUseItem(Player player)
        {
            return player.ownedProjectileCounts[Item.shoot] < 1;
        }

        public override bool? UseItem(Player player)
        {
            if (player.whoAmI == Main.myPlayer)
            {
                Vector2 mousePosition = Main.MouseWorld;

                // Calculate the target position for the player's feet
                int tileX = (int)mousePosition.X / 16;
                int tileY = (int)mousePosition.Y / 16;
                Vector2 targetPosition = new Vector2(tileX * 16 + 8 - player.width / 2, tileY * 16 - player.height + 1);

                // Check if the target position is a valid tile and not solid
                bool canTeleport = WorldGen.InWorld(tileX, tileY) && !WorldGen.SolidTile(tileX, tileY);

                if (canTeleport)
                {
                    player.Teleport(targetPosition, 1);
                    NetMessage.SendData(MessageID.TeleportEntity, -1, -1, null, 0, player.whoAmI, targetPosition.X, targetPosition.Y, 1);
                }
                else
                {
                    // Optionally, you can display a message or play a sound to indicate that teleportation is blocked.
                    Main.NewText("Cannot teleport to that location!");
                    Item.UseSound = SoundID.Item122;
                }
            }
            return true;
        }
    }
}
