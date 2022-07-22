using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Actors.Static;
using System;
using System.Text.RegularExpressions;
using Assets.Source.Actors.Static;
using UnityEngine;

namespace DungeonCrawl.Core
{
    /// <summary>
    ///     MapLoader is used for constructing maps from txt files
    /// </summary>
    public static class MapLoader
    {
        public static int MapNumber = 7;

        /// <summary>
        ///     Constructs map from txt file and spawns actors at appropriate positions
        /// </summary>
        /// <param name="id"></param>
        public static void LoadMap(int id)
        {
            var lines = Regex.Split(Resources.Load<TextAsset>($"map_{id}").text, "\r\n|\r|\n");

            // Read map size from the first line
            var split = lines[0].Split(' ');
            var width = int.Parse(split[0]);
            var height = int.Parse(split[1]);

            // Create actors
            for (var y = 0; y < height; y++)
            {
                var line = lines[y + 1];
                for (var x = 0; x < width; x++)
                {
                    var character = line[x];

                    SpawnActor(character, (x, -y));
                }
            }

            // Set default camera size and position
            CameraController.Singleton.Size = 3;
            CameraController.Singleton.Position = (width / 2, -height / 2);
            MapNumber++;
        }

        private static void SpawnActor(char c, (int x, int y) position)
        {
            switch (c)
            {
                case '#':
                    ActorManager.Singleton.Spawn<Wall>(position);
                    break;
                case '.':
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'p':
                    ActorManager.Singleton.Spawn<Player>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'r':
                    ActorManager.Singleton.Spawn<Ring>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'N':
                    ActorManager.Singleton.Spawn<Necklace>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'C':
                    ActorManager.Singleton.Spawn<Crown>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'F':
                    ActorManager.Singleton.Spawn<Floo>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'G':
                    ActorManager.Singleton.Spawn<GoldenCup>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 's':
                    ActorManager.Singleton.Spawn<Skeleton>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'v':
                    ActorManager.Singleton.Spawn<Water>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'c':
                    ActorManager.Singleton.Spawn<Potion>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'a':
                    ActorManager.Singleton.Spawn<Apple>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 't':
                    ActorManager.Singleton.Spawn<Trees>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'd':
                    ActorManager.Singleton.Spawn<Danger>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'k':
                    ActorManager.Singleton.Spawn<Key>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'j':
                    ActorManager.Singleton.Spawn<Wand>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'f':
                    ActorManager.Singleton.Spawn<Spider>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'w':
                    ActorManager.Singleton.Spawn<Dementor>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'g':
                    ActorManager.Singleton.Spawn<Ghost>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'l':
                    ActorManager.Singleton.Spawn<ClosedDoor>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'o':
                    ActorManager.Singleton.Spawn<OpenedDoor>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'n':
                    ActorManager.Singleton.Spawn<StairsDown>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'b':
                    ActorManager.Singleton.Spawn<Bridge>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'm':
                    ActorManager.Singleton.Spawn<Money>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case 'V':
                    ActorManager.Singleton.Spawn<Voldemort>(position);
                    ActorManager.Singleton.Spawn<Floor>(position);
                    break;
                case ' ':
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
