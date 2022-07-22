using Assets.Source.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors.Characters
{
    public class Ghost : Monster
    {
        private const float SPEED = 10.0f;
        private float counter;
        protected override void SetHealth()
        {
            if (PlayerData.PlayMode == "Hard")
            {
                Health = 50;
            }
            else
            {
                Health = 30;
            }
            
        }

        public Ghost()
        {
            SetHealth();
            if (PlayerData.PlayMode == "Hard")
            {
                Damage = 14;
            }
            else
            {
                Damage = 7;
            }
            counter = SPEED;
        }

        protected override void OnUpdate(float deltaTime)
        {
            counter -= deltaTime;
            if (counter <= 0.0f)
            {

                Utilities.PlaySound("Ghost");
                counter = SPEED;
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
            Debug.Log("Hoouuuuuu...");
        }

        public override int DefaultSpriteId => 314;
        public override string DefaultName => "Ghost";

        public override int Damage { get; set; }
    }
}
