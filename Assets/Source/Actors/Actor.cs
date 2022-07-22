using System;
using Assets.Source.Actors.Characters;
using Assets.Source.Core;
using DungeonCrawl.Actors.Characters;
using DungeonCrawl.Core;
using UnityEngine;

namespace DungeonCrawl.Actors
{
    public abstract class Actor : MonoBehaviour
    {
        public (int x, int y) Position
        {
            get => _position;
            set
            {
                _position = value;
                transform.position = new Vector3(value.x, value.y, Z);
            }
        }

        private (int x, int y) _position;
        private SpriteRenderer _spriteRenderer;



        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

            SetSprite(DefaultSpriteId);
            if (this is Dementor || this is Player || this is Voldemort)
            {
                SetSprite(DefaultSpriteId, true);
            }
        }

        private void Update()
        {
            OnUpdate(Time.deltaTime);
        }

        public void SetSprite(int id)
        {
            _spriteRenderer.sprite = ActorManager.Singleton.GetSprite(id);
        }

        public void SetSprite(int id, bool isHarrySheet)
        {
            _spriteRenderer.sprite = ActorManager.Singleton.GetSprite(id, isHarrySheet);
        }

        public void TryMove(Direction direction)
        {
            var vector = direction.ToVector();
            (int x, int y) targetPosition = (Position.x + vector.x, Position.y + vector.y);

            var actorAtTargetPosition = ActorManager.Singleton.GetActorAt(targetPosition);

            if (actorAtTargetPosition == null)
            {
                // No obstacle found, just move
               
                Position = targetPosition;
            }
            else
            {
                if (actorAtTargetPosition.OnCollision(this))
                {
                    // Allowed to move
                    
                    Position = targetPosition;
                }
                else if (!actorAtTargetPosition.OnCollision(this) && actorAtTargetPosition is Monster && this is Player)
                {
                    if (actorAtTargetPosition is Spider)
                    {
                        var enemy = (Spider)actorAtTargetPosition;
                        MonsterAttack(enemy);
                    }
                    if (actorAtTargetPosition is Dementor)
                    {
                        var enemy = (Dementor)actorAtTargetPosition;
                        MonsterAttack(enemy);
                    }
                    if (actorAtTargetPosition is Skeleton)
                    {
                        var enemy = (Skeleton)actorAtTargetPosition;
                        MonsterAttack(enemy);
                    }
                    if (actorAtTargetPosition is Ghost)
                    {
                        var enemy = (Ghost)actorAtTargetPosition;
                        MonsterAttack(enemy);
                    }
                    if (actorAtTargetPosition is Voldemort)
                    {
                        var enemy = (Voldemort)actorAtTargetPosition;
                        MonsterAttack(enemy);
                    }


                }
            }
        }

        public void MonsterAttack(Monster enemy)
        {
            var player = (Player)this;
            UserInterface.Singleton.SetText($"Enemy Health: {enemy.Health}", UserInterface.TextPosition.MiddleLeft);
            enemy.ApplyDamage(player.Damage);
            if (enemy.Health > 0)
            {
                player.ApplyDamage(enemy.Damage);
            }
        }
        /// <summary>
        ///     Invoked whenever another actor attempts to walk on the same position
        ///     this actor is placed.
        /// </summary>
        /// <param name="anotherActor"></param>
        /// <returns>true if actor can walk on this position, false if not</returns>
        public virtual bool OnCollision(Actor anotherActor)
        {
            // All actors are passable by default
            return true;
        }

        /// <summary>
        ///     Invoked every animation frame, can be used for movement, character logic, etc
        /// </summary>
        /// <param name="deltaTime">Time (in seconds) since the last animation frame</param>
        protected virtual void OnUpdate(float deltaTime)
        {
        }

        /// <summary>
        ///     Can this actor be detected with ActorManager.GetActorAt()? Should be false for purely cosmetic actors
        /// </summary>
        public virtual bool Detectable => true;

        /// <summary>
        ///     Z position of this Actor (0 by default)
        /// </summary>
        public virtual int Z => 0;

        /// <summary>
        ///     Id of the default sprite of this actor type
        /// </summary>
        public abstract int DefaultSpriteId { get; }

        /// <summary>
        ///     Default name assigned to this actor type
        /// </summary>
        public abstract string DefaultName { get; }


    }
}