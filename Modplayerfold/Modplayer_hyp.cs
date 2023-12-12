using System.Reflection.Metadata.Ecma335;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Hyperionandmaybeotherstuff.Modplayerfold
{
    public class Modplayer_hyp : ModPlayer
    {
        public bool mercenaryHelmetEquipped;
        public bool mercenarySet;
        public int copperCoinStack = 5;

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {

            if (mercenarySet && target.life < 0 && !target.friendly)
            {
                Player.statLife += 1; // Régénère 1 point de vie à chaque kill
                Main.NewText("le truc est mort");
            }
        }

            /*if (mercenarySet && target.life < 0 && !target.friendly)
            {
                int copperCoinStack = 5;
                Player.statLife += 1; // Régénère 1 point de vie à chaque kill
                Player.GetModPlayer<Modplayer_hyp>().QuickSpawnItem(Player, ItemID.CopperCoin, copperCoinStack);

                Main.NewText("Le truc est mort");
                //Player.QuickSpawnItem(target, ItemID.SolarBrick, 5);
                // Ajouter 5 pièces de cuivre au joueur
            }
        public void QuickSpawnItem(Player player, int itemId, int stack = 1)
        {
            int copperCoinStack = 5;
            Item.NewItem((IEntitySource)player, (int)Player.position.X, (int)Player.position.Y, Player.width, Player.height, ItemID.CopperCoin, copperCoinStack);
        }*/

    }
}
