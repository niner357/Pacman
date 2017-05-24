using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pacman.Map
{
    public class LevelDecoder
    {
        /* (?) = Fruits
         * (+) = Player Spawn
         * (b) = KI Spawn (Blinky)
         * (i) = KI Spawn (Inky)
         * (p) = KI Spawn (Pinky)
         * (c) = KI Spawn (Clyde)
         * (:) = Wall
         * (_) = Way
         * (*) = Power
         */

        public string Path { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public LevelDecoder(string path, int width, int height)
        {
            Path = path;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Transforms the LevelFile in a Tile Array
        /// </summary>
        /// <returns>Tile Array with all Tiles in the Level</returns>
        public Tile[] DecodeLevel()
        {
            List<Tile> tiles = new List<Tile>();
            int tileWidth = Width / 32;
            int tileHeight = Height / 32;
            string contents = File.ReadAllText(Path);
            string inputStr = "";
            foreach (string str in contents.Split(';'))
            {
                char[] ca = str.ToCharArray();
                char id = ca[ca.Length - 1];
                ca[ca.Length - 1] = ' ';
                string strCount = new string(ca);
                int count = int.Parse(strCount);
                for (int i_ = 0; i_ < count; i_++)
                {
                    inputStr += id.ToString();
                }
            }
            int i = 0;
            for (int y = 0; y < Width; y += tileWidth)
            {
                for (int x = 0; x < Height; x += tileHeight)
                {
                    char c = inputStr.ToCharArray()[i];
                    i++;
                    switch (c)
                    {
                        case '+':
                            Tile tile = new Tile(x, y, tileWidth, tileHeight, TileType.Way);
                            Tile childTile = new Tile(x, y, tileWidth, tileHeight, TileType.PlayerSpawn);
                            tile.Child = childTile;
                            tiles.Add(tile);
                            continue;
                        case '?':
                            Tile tile1 = new Tile(x, y, tileWidth, tileHeight, TileType.Way);
                            Tile childTile1 = new Tile(x, y, tileWidth, tileHeight, TileType.Fruit);
                            tile1.Child = childTile1;
                            tiles.Add(tile1);
                            continue;
                        case 'b':
                            Tile tile2 = new Tile(x, y, tileWidth, tileHeight, TileType.Way);
                            Tile childTile2 = new Tile(x, y, tileWidth, tileHeight, TileType.BlinkySpawn);
                            tile2.Child = childTile2;
                            tiles.Add(tile2);
                            continue;
                        case 'i':
                            Tile tile3 = new Tile(x, y, tileWidth, tileHeight, TileType.Way);
                            Tile childTile3 = new Tile(x, y, tileWidth, tileHeight, TileType.InkySpawn);
                            tile3.Child = childTile3;
                            tiles.Add(tile3);
                            continue;
                        case 'p':
                            Tile tile4 = new Tile(x, y, tileWidth, tileHeight, TileType.Way);
                            Tile childTile4 = new Tile(x, y, tileWidth, tileHeight, TileType.PinkySpawn);
                            tile4.Child = childTile4;
                            tiles.Add(tile4);
                            continue;
                        case 'c':
                            Tile tile5 = new Tile(x, y, tileWidth, tileHeight, TileType.Way);
                            Tile childTile5 = new Tile(x, y, tileWidth, tileHeight, TileType.ClydeSpawn);
                            tile5.Child = childTile5;
                            tiles.Add(tile5);
                            continue;
                        case ':':
                            Tile tile6 = new Tile(x, y, tileWidth, tileHeight, TileType.Wall);
                            tiles.Add(tile6);
                            continue;
                        case '_':
                            Tile tile7 = new Tile(x, y, tileWidth, tileHeight, TileType.Way);
                            tiles.Add(tile7);
                            continue;
                        case '*':
                            Tile tile8 = new Tile(x, y, tileWidth, tileHeight, TileType.Way);
                            Tile childTile6 = new Tile(x, y, tileWidth, tileHeight, TileType.Power);
                            tile8.Child = childTile6;
                            tiles.Add(tile8);
                            continue;
                    }
                }
            }
            return tiles.ToArray<Tile>();
        }
    }
}
