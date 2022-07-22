using System;
using UnityEngine;

namespace DungeonCrawl
{
    public enum Direction : byte
    {
        Up,
        Down,
        Left,
        Right
    }

    public static class Utilities
    {
        private static System.Random _random = new System.Random();
        public static (int x, int y) ToVector(this Direction dir)
        {
            switch (dir)
            {
                case Direction.Up:
                    return (0, 1);
                case Direction.Down:
                    return (0, -1);
                case Direction.Left:
                    return (-1, 0);
                case Direction.Right:
                    return (1, 0);
                default:
                    throw new ArgumentOutOfRangeException(nameof(dir), dir, null);
            }
        }

        public static Direction RandomDir()
        {
            Array values = Enum.GetValues(typeof(Direction));
            Direction randomDir = (Direction)values.GetValue(_random.Next(values.Length));
            return randomDir;
        }

        public static void PlaySound(string tag)
        {
            GameObject gameObject = GameObject.FindGameObjectWithTag(tag);
            gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
