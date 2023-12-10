using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Hyperionandmaybeotherstuff.Tiles
{
    public class Lapis_tile : ModTile
    {
        public static int exampleBlockCount; // Add this line to define the exampleBlockCount property

        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;

            // Ajoutez d'autres propriétés selon vos besoins
            AddMapEntry(new Color(0, 0, 255));
        }
    }
}
