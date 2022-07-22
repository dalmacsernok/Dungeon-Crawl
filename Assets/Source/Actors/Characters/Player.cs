using Assets.Source.Actors.Static;
using Assets.Source.Core;
using DungeonCrawl.Core;
using System;
using System.Collections.Generic;
using System.Net.Mime;
using Assets.Source.Actors.Characters;
using UnityEngine;
using DungeonCrawl.Actors.Static;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using System.Threading;

namespace DungeonCrawl.Actors.Characters
{
    public class Player : Character
    {

        public List<Actor> Inventory { get; private set; } = new List<Actor>();
        public string Name;
        protected override void SetHealth()
        {
            Health = 100;
        }

        public Player()
        {
            SetHealth();
            Damage = 15;
            if (PlayerData.PlayerName == "")
            {
                Name = "Dobby";
            }
            else
            {
                Name = PlayerData.PlayerName;
            }
        }

        public void AddToInventory(Actor item)
        {
            Inventory.Add(item);
        }


        protected override void OnUpdate(float deltaTime)
        {
            Direction direction = Direction.Up;
            UserInterface.Singleton.SetText($"Player Health: {Health}\nPlayer damage: {Damage}", UserInterface.TextPosition.BottomLeft);
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                // Move up
                Utilities.PlaySound("Footsteps");
                TryMove(Direction.Up);
            }

            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                // Move down
                Utilities.PlaySound("Footsteps");
                TryMove(Direction.Down);
                direction = Direction.Down;
            }

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                // Move left
                Utilities.PlaySound("Footsteps");
                TryMove(Direction.Left);
                direction = Direction.Left;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                // Move right
                Utilities.PlaySound("Footsteps");
                TryMove(Direction.Right);
                direction = Direction.Right;
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                Application.Quit();
            }

            Item item = ActorManager.Singleton.GetActorAt<Item>(Position);

            PickUpItem(item);

            OpenDoor(direction);
            if (MapLoader.MapNumber == 8)
            {
                Teleport();
            }
            

            if (Inventory.Count > 0)
            {
                UserInterface.Singleton.SetText(ToString(), UserInterface.TextPosition.TopRight);
            }

            CameraController.Singleton.Position = (Position.x, Position.y);
            EnterNextLevel();
            HasWonTheGame();
        }

        public void Teleport()
        {
            List<Floo> floos = ActorManager.Singleton.GetFloos();
            Floo floo = ActorManager.Singleton.GetActorAt<Floo>(Position);
            if (floo != null)
            {
                SpriteRenderer spriteRenderer = floo.GetComponent<SpriteRenderer>();
                spriteRenderer.color = Color.green;
                UserInterface.Singleton.SetText("Press Enter to teleport", UserInterface.TextPosition.BottomRight);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    Position = floos[0].Position == Position ? floos[1].Position : floos[0].Position;
                    spriteRenderer.color = Color.red;

                }
            } else
            {
                for (int i = 0; i < floos.Count; i++)
                {
                    if (floos[i].GetComponent<SpriteRenderer>().color == Color.green)
                    {
                        floos[i].GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
            }

        }

        public void HasWonTheGame()
        {
            if (MapLoader.MapNumber == 8)
            {
                if (ActorManager.Singleton.GetVoldemort() == null)
                {
                    ActorManager.Singleton.DestroyAllActors();
                    UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.TopRight);
                    SceneManager.LoadScene("Endgame");
                }

            }
        }

        public void EnterNextLevel()
        {
            StairsDown nextLevel = ActorManager.Singleton.GetActorAt<StairsDown>(Position);

            if (nextLevel != null)
            {
                UserInterface.Singleton.SetText("Press Enter to enter the next level", UserInterface.TextPosition.BottomRight);
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    if (MapLoader.MapNumber == 2)
                    {
                        if (HasRing(Inventory))
                        {
                            ActorManager.Singleton.DestroyAllActors();
                            UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.TopRight);
                            MapLoader.LoadMap(MapLoader.MapNumber);
                        }
                    }
                    if (MapLoader.MapNumber == 3)
                    {
                        if (HasCrown(Inventory))
                        {
                            ActorManager.Singleton.DestroyAllActors();
                            UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.TopRight);
                            MapLoader.LoadMap(MapLoader.MapNumber);
                        }
                    }
                    if (MapLoader.MapNumber == 4)
                    {
                        if (HasNecklace(Inventory))
                        {
                            ActorManager.Singleton.DestroyAllActors();
                            UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.TopRight);
                            MapLoader.LoadMap(MapLoader.MapNumber);
                        }
                    }

                    if (MapLoader.MapNumber == 5)
                    {
                        if (HasGoldenCup(Inventory))
                        {
                            ActorManager.Singleton.DestroyAllActors();
                            UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.TopRight);
                            MapLoader.LoadMap(MapLoader.MapNumber);
                        }
                    }
                    if (MapLoader.MapNumber == 6)
                    {
                        if (HasMoney(Inventory))
                        {
                            ActorManager.Singleton.DestroyAllActors();
                            UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.TopRight);
                            MapLoader.LoadMap(MapLoader.MapNumber);
                        }
                    }

                    if (MapLoader.MapNumber == 7)
                    {
                        ActorManager.Singleton.DestroyAllActors();
                        UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.TopRight);
                        MapLoader.LoadMap(MapLoader.MapNumber);
                    }
                }
            }
            if (Health <= 0)
            {
                ActorManager.Singleton.DestroyAllActors();
                UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.TopRight);
                SceneManager.LoadScene("Gameover");
            }
        }

        public void OpenDoor(Direction direction)
        {
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt<ClosedDoor>(targetPosition);
            if (actorAtTargetPosition != null && HasKey(Inventory))
            {
                ActorManager.Singleton.DestroyActor(actorAtTargetPosition);
                ActorManager.Singleton.Spawn<OpenedDoor>(targetPosition);
                RemoveKey(Inventory);

            }
        }

        public bool HasKey(List<Actor> inventory)
        {
            foreach (Actor item in inventory)
            {
                if (item is Key)
                {
                    return true;
                }
            }
            return false;
        }


        public bool HasCrown(List<Actor> inventory)
        {
            foreach (Actor item in inventory)
            {
                if (item is Crown)
                {
                    return true;
                }
            }
            return false;
        }


        public bool HasRing(List<Actor> inventory)
        {
            foreach (Actor item in inventory)
            {
                if (item is Ring)
                {
                    return true;
                }
            }
            return false;
        }


        public bool HasNecklace(List<Actor> inventory)
        {
            foreach (Actor item in inventory)
            {
                if (item is Necklace)
                {
                    return true;
                }
            }
            return false;
        }


        public bool HasGoldenCup(List<Actor> inventory)
        {
            foreach (Actor item in inventory)
            {
                if (item is GoldenCup)
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasMoney(List<Actor> inventory)
        {
            foreach (Actor item in inventory)
            {
                if (item is Money)
                {
                    return true;
                }
            }
            return false;
        }


        public void RemoveKey(List<Actor> inventory)
        {
            foreach (Actor item in inventory)
            {
                if (item is Key)
                {
                    inventory.Remove(item);
                    break;
                }
            }
        }
        public void RemoveSword(List<Actor> inventory)
        {
            foreach (Actor item in inventory)
            {
                if (item is Wand)
                {
                    inventory.Remove(item);
                    Damage -= 10;
                    break;
                }
            }
        }

        public void PickUpItem(Item item)
        {
            if (item != null)
            {
                UserInterface.Singleton.SetText("Press E to pick up", UserInterface.TextPosition.BottomRight);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (item is Key)
                    {
                        var key = ActorManager.Singleton.GetActorAt<Key>(Position);
                        AddToInventory(key);
                        ActorManager.Singleton.DestroyActor(key);
                    }
                    if (item is Wand)
                    {
                        var sword = ActorManager.Singleton.GetActorAt<Wand>(Position);
                        AddToInventory(sword);
                        IncreaseDamage(sword.Damage);
                        ActorManager.Singleton.DestroyActor(sword);
                    }
                    if (item is Potion || item is Apple)
                    {
                        if (item is Potion)
                        {
                            var food = (Potion)item;
                            IncreaseHealth(food.Health);
                            ActorManager.Singleton.DestroyActor(food);
                        }
                        if (item is Apple)
                        {
                            var food = (Apple)item;
                            IncreaseHealth(food.Health);
                            ActorManager.Singleton.DestroyActor(food);
                        }
                    }
                    if (item is Danger)
                    {
                        var trap = (Danger)item;
                        IncreaseHealth(-trap.Damage);
                        ActorManager.Singleton.DestroyActor(trap);
                    }
                    if (item is Ring)
                    {
                        var ring = ActorManager.Singleton.GetActorAt<Ring>(Position);
                        AddToInventory(ring);
                        ActorManager.Singleton.DestroyActor(ring);
                    }
                    if (item is Crown)
                    {
                        var crown = ActorManager.Singleton.GetActorAt<Crown>(Position);
                        AddToInventory(crown);
                        ActorManager.Singleton.DestroyActor(crown);
                    }
                    if (item is Necklace)
                    {
                        var necklace = ActorManager.Singleton.GetActorAt<Necklace>(Position);
                        AddToInventory(necklace);
                        ActorManager.Singleton.DestroyActor(necklace);
                    }
                    if (item is GoldenCup)
                    {
                        var goldenCup = ActorManager.Singleton.GetActorAt<GoldenCup>(Position);
                        AddToInventory(goldenCup);
                        ActorManager.Singleton.DestroyActor(goldenCup);
                    }
                    if (item is Money)
                    {
                        var money = ActorManager.Singleton.GetActorAt<Money>(Position);
                        AddToInventory(money);
                        ActorManager.Singleton.DestroyActor(money);
                    }

                }
            }
            else
            {
                UserInterface.Singleton.SetText(String.Empty, UserInterface.TextPosition.BottomRight);
            }
        }

        public override string ToString()
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < Inventory.Count; i++)
            {
                if (dict.ContainsKey(Inventory[i].DefaultName))
                {
                    int oldValue = dict[Inventory[i].DefaultName];
                    dict[Inventory[i].DefaultName] = oldValue + 1;
                }
                else
                {
                    dict[Inventory[i].DefaultName] = 1;
                }
            }
            string toPrint = @"Your inventory:
                              ";
            foreach (KeyValuePair<string, int> kvp in dict)
            {
                toPrint += $"{kvp.Key}: {kvp.Value}\n";
            }
            return toPrint;
        }
        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        public void IncreaseDamage(int damage)
        {
            if (Damage < 50)
            {
                Damage += damage;
                if (Damage > 50)
                {
                    Damage = 50;
                }
            }

        }
        public void IncreaseHealth(int health)
        {
            if (Health < 150)
            {
                Health += health;
                if (Health > 150)
                {
                    Health = 150;
                }
            }

        }

        protected override void OnDeath()
        {
            EnterNextLevel();
            Debug.Log("Oh no, I'm dead!");
        }

        public override int DefaultSpriteId
        {
            get
            {
                if (PlayerData.Character == "Hermione")
                {
                    return 1;
                }

                if (PlayerData.Character == "Ron")
                {
                    return 5;
                }

                return 0;
            }
        }
        public override string DefaultName => "Player";

        public override int Damage { get; set; }
    }
}
