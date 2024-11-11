using Hyperionandmaybeotherstuff.Tiles;
using System;
using Terraria.ModLoader;

namespace Hyperionandmaybeotherstuff.Commons.Systems
{
	public class lapis_caveTileCount : ModSystem
	{
		public int exampleBlockCount;

		public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts) {
			exampleBlockCount = tileCounts[ModContent.TileType<Lapis_ore>()];
		}
	}
}
