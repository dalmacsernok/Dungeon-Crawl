using Assets.Source.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Spider : Monster
    {
        protected override void SetHealth()
        {
            if (PlayerData.PlayMode == "Hard")
            {
                Health = 60;
            }
            else
            {
                Health = 40;
            }
            
        }

        public Spider()
        {
            SetHealth();
            if (PlayerData.PlayMode == "Hard")
            {
                Damage = 12;
            }
            else
            {
                Damage = 6;
            }
            
        }

        public override bool OnCollision(Actor anotherActor)
        {
            return false;
        }

        protected override void OnDeath()
        {
            var player = ActorManager.Singleton.GetPlayer();
            player.RemoveSword(player.Inventory);
            Debug.Log("Well, I'm sorry that I'm dead...");
        }

        public override int DefaultSpriteId => 267;
        public override string DefaultName => "Spider";

        public override int Damage { get; set; }
    }
}
