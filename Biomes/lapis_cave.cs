using Hyperionandmaybeotherstuff.Commons.Systems;
using Hyperionandmaybeotherstuff.Backgrounds;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Hyperionandmaybeotherstuff.Biomes
{
	public class ExampleUndergroundBiome : ModBiome
	{
		// Select all the scenery
		public override ModUndergroundBackgroundStyle UndergroundBackgroundStyle => ModContent.GetInstance<ExampleUndergroundBackgroundStyle>();

		// Select Music
		public override int Music => MusicLoader.GetMusicSlot(Mod, "Assets/Music/MysteriousMystery");

		// Sets how the Scene Effect associated with this biome will be displayed with respect to vanilla Scene Effects. For more information see SceneEffectPriority & its values.
		public override SceneEffectPriority Priority => SceneEffectPriority.BiomeLow; // We have set the SceneEffectPriority to be BiomeLow for purpose of example, however default behavior is BiomeLow.

		// Populate the Bestiary Filter
		public override string BestiaryIcon => base.BestiaryIcon;
		public override string BackgroundPath => base.BackgroundPath;
		public override Color? BackgroundColor => base.BackgroundColor;

		// Calculate when the biome is active.
		public override bool IsBiomeActive(Player player) {
			// Vérifie si le joueur est à une certaine profondeur, par exemple sous la surface
			bool isUnderground = player.ZoneRockLayerHeight || player.ZoneDirtLayerHeight;

			// Vérifie s'il y a assez de blocs de Lapis autour du joueur
			bool hasLapisBlocks = ModContent.GetInstance<lapis_caveTileCount>().exampleBlockCount >= 40;

			// Vérifie que le biome est dans une zone centrale, si nécessaire
			bool isInCenterOfWorld = Math.Abs(player.position.ToTileCoordinates().X - Main.maxTilesX / 2) < Main.maxTilesX / 6;

			// Active le biome seulement si le joueur est dans une zone souterraine et a suffisamment de blocs de Lapis autour
			return isUnderground && hasLapisBlocks && isInCenterOfWorld;
		}





		// In the event that both our biome AND one or more modded SceneEffect layers are active with the same SceneEffect Priority, this can decide which one.
		// It's uncommon that need to assign a weight - you'd have to specifically believe that you don't need higher SceneEffectPriority, but do need to be the active SceneEffect within the priority you designated
		// In this case, we don't need it, so this inclusion is purely to demonstrate this is available.
		// See the GetWeight documentation for more information.
		/*
		public override float GetWeight(Player player) {
			int distanceToCenter = Math.Abs(player.position.ToTileCoordinates().X - Main.maxTilesX / 2);
			// We declare that our biome should have be more likely than not to be active if in center 1/6 of the world, and decreases in need to be active as player gets further away to the 1/3 mark.
			if (distanceToCenter <= Main.maxTilesX / 12) {
				return 1f;
			}
			else {
				return 1f - (distanceToCenter - Main.maxTilesX / 12) / (Main.maxTilesX / 12);
			}
		}
		*/
	}
}