using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.WorldBuilding;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.IO;
using Terraria.GameContent.Generation;

namespace Hyperionandmaybeotherstuff.worldgen
{
    public class LapisBiomeGenerator : ModSystem
    {
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int genIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (genIndex != -1)
            {
                tasks.Insert(genIndex + 1, new PassLegacy("Generating Inverted Lapis Biome", GenerateLapisCavern));
            }
        }

        private void GenerateLapisCavern(GenerationProgress progress, GameConfiguration configuration)
        {
            progress.Message = "Generating Inverted Lapis Caverns";
            for (int i = 0; i < 3; i++) // Adjust to create more or fewer caverns
            {
                int x = WorldGen.genRand.Next(100, Main.maxTilesX - 100);
                int y = WorldGen.genRand.Next((int)Main.rockLayer, Main.maxTilesY - 200);
                GenerateLapisCluster(x, y, 150, 100); // Size can be adjusted
            }
        }

        private void GenerateLapisCluster(int startX, int startY, int width, int height)
        {
            int rowog = 60;
            int columnog = 125;
            char fillChar = '#';
            char fillCharno = '.';
            Random random = new Random();  // Single Random instance

            char[,] matrix = new char[rowog, columnog];

            // Initialize the matrix
            for (int i = 0; i < rowog; i++)
            {
                for (int j = 0; j < columnog; j++)
                {
                    matrix[i, j] = fillChar;
                }
            }
            int rows;
            // Populate matrix with random empty spaces
            for (int i = 0; i < 125; i += random.Next(2, 4))
            {
                if (i < 25 || i > 100)
                {
                    rows = random.Next(15, 20);
                }
                else if ( (i >25 && i<50) || (i<100 && i>75))
                {
                    rows = random.Next(10, 15);
                }
                else
                {
                    rows = random.Next(5, 10);
                }
                int columns = random.Next(3, 5);

                for (int x = i; x < Math.Min(i + columns, columnog); x++)
                {
                    for (int y = 0; y < Math.Min(rows, rowog); y++)
                    {
                        matrix[y, x] = fillCharno;
                    }
                }
            }

            // Place tiles based on matrix
            for (int x = startX; x < startX + columnog; x++)
            {
                for (int y = startY; y < startY + rowog; y++)
                {
                    if (matrix[y - startY, x - startX] == '#')
                    {
                        WorldGen.PlaceTile(x, y, ModContent.TileType<Tiles.Lapis_ore>(), true, true);
                        WorldGen.PlaceWall(x, y, WallID.GraniteUnsafe);
                    }
                }
            }



            /*bool[] caveMap = CellularAutomata.Generate(width, height, 5, 45); // Use cellular automata for inverted cave shapes
            for (int x = 0; x < 125; x++)
            {
                for (int y = 0; y < 60; y++)
                {
                    int worldX = startX + x - width / 2;
                    int worldY = startY + y - height / 2;
                    if (worldX > 0 && worldX < Main.maxTilesX && worldY > 0 && worldY < Main.maxTilesY)
                    {
                        if (caveMap[x + y * width])
                        {

                            // When the map has "false" (indicating an open area), we place Lapis ore
                            WorldGen.PlaceTile(worldX, worldY, ModContent.TileType<Tiles.Lapis_ore>(), true, true);
                            WorldGen.PlaceWall(worldX, worldY, WallID.GraniteUnsafe);
                        }
                        else
                        {
                            // When the map has "true" (indicating a wall), we place air
                            WorldGen.KillTile(worldX, worldY, false, false, true);
                            WorldGen.KillWall(worldX, worldY);
                        }
                    }
                }
            }*/
        }
    }

    public static class Myalgo
    {
        public static void applyexternpatch()
        {
            Random randr = new Random();
            Random randc = new Random();
            int rowog = 60;
            int columnog = 125;
            char fillChar = '#';
            
            char[,] matrix = new char[rowog, columnog];

            for (int i = 0; i < rowog; i++)
            {
                for (int j = 0; j < columnog; j++)
                {
                    matrix[i, j] = fillChar;
                }
            }
            char fillCharno = '.';
            Random randi = new Random();
            for (int i = 0; i < 125; i += randi.Next(4, 15))
            {
                int rows = randr.Next(5,15);
                int columns = randc.Next(5,20);
                for (int x = i; x<columns; x++)
                {
                    for (int y = 0; y<rows; y++)
                    {
                        matrix[i, x] = fillCharno;
                    }
                }
            }
        }
    }
    public static class CellularAutomata
    {
        public static bool[] Generate(int width, int height, int iterations = 4, int percentAreWalls = 40)
        {
            var map = new bool[width * height];
            RandomFill(map, width, height, percentAreWalls);

            for (var i = 0; i < iterations; i++)
                map = Step(map, width, height);

            return map;
        }

        private static void RandomFill(bool[] map, int width, int height, int percentAreWalls)
        {
            var randomColumn = Random.Shared.Next(4, width - 4);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                        map[x + y * width] = true;
                    else if (x != randomColumn && Random.Shared.Next(100) < percentAreWalls)
                        map[x + y * width] = true;
                }
            }
        }

        private static bool[] Step(bool[] map, int width, int height)
        {
            var newMap = new bool[width * height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x == 0 || y == 0 || x == width - 1 || y == height - 1)
                        newMap[x + y * width] = true;
                    else
                        newMap[x + y * width] = PlaceWallLogic(map, width, height, x, y);
                }
            }
            return newMap;
        }

        private static bool PlaceWallLogic(bool[] map, int width, int height, int x, int y)
        {
            return CountAdjacentWalls(map, width, height, x, y) >= 5 ||
                   CountNearbyWalls(map, width, height, x, y) <= 2;
        }

        private static int CountAdjacentWalls(bool[] map, int width, int height, int x, int y)
        {
            int walls = 0;
            for (int mapX = x - 1; mapX <= x + 1; mapX++)
            {
                for (int mapY = y - 1; mapY <= y + 1; mapY++)
                {
                    if (mapX >= 0 && mapY >= 0 && mapX < width && mapY < height && map[mapX + mapY * width])
                        walls++;
                }
            }
            return walls;
        }

        private static int CountNearbyWalls(bool[] map, int width, int height, int x, int y)
        {
            int walls = 0;
            for (int mapX = x - 2; mapX <= x + 2; mapX++)
            {
                for (int mapY = y - 2; mapY <= y + 2; mapY++)
                {
                    if (Math.Abs(mapX - x) == 2 && Math.Abs(mapY - y) == 2)
                        continue;
                    if (mapX < 0 || mapY < 0 || mapX >= width || mapY >= height)
                        continue;
                    if (map[mapX + mapY * width])
                        walls++;
                }
            }
            return walls;
        }
    }
}
