using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using ItemAPI;
using Dungeonator;
using System.Reflection;
using Random = System.Random;
using FullSerializer;
using System.Collections;
using Gungeon;
using MonoMod.RuntimeDetour;
using MonoMod;



namespace BunnyMod
{

    public partial class Vengeance : CompanionItem
    {
        public static void Init()
        {
            string name = "vengeance";
            string resourcePath = "ExampleMod/Resources/PZeroAnims/Idle/P-Zero_idle_001";
            GameObject gameObject = new GameObject();
            Vengeance pointZero = gameObject.AddComponent<Vengeance>();
            ItemBuilder.AddSpriteToObject(name, resourcePath, gameObject, true);
            string shortDesc = "test";
            string longDesc = "VEngeancetest";
            pointZero.SetupItem(shortDesc, longDesc, "bny");
            pointZero.quality = PickupObject.ItemQuality.EXCLUDED;
            pointZero.CompanionGuid = Vengeance.guid;
            Vengeance.BuildPrefab();
        }
        public override void Pickup(PlayerController player)
        {

            base.Pickup(player);
        }

        public static void BuildPrefab()
        {

            bool flag = Vengeance.VengeancePrefab != null || CompanionBuilder.companionDictionary.ContainsKey(Vengeance.guid);
            bool flag2 = flag;
            if (!flag2)
            {
                Vengeance.VengeancePrefab = CompanionBuilder.BuildPrefab("Vengeance", Vengeance.guid, Vengeance.spritePaths[0], new IntVector2(3, 2), new IntVector2(8, 9));
                Vengeance.VengeanceBehavior vengeanceBehavior = Vengeance.VengeancePrefab.AddComponent<Vengeance.VengeanceBehavior>();
                AIAnimator aiAnimator = vengeanceBehavior.aiAnimator;
                aiAnimator.MoveAnimation = new DirectionalAnimation
                {
                    Type = DirectionalAnimation.DirectionType.TwoWayHorizontal,
                    Flipped = new DirectionalAnimation.FlipType[2],
                    AnimNames = new string[]
                    {
                        "run_right",
                        "run_left"
                    }
                };
                aiAnimator.IdleAnimation = new DirectionalAnimation
                {
                    Type = DirectionalAnimation.DirectionType.TwoWayHorizontal,
                    Flipped = new DirectionalAnimation.FlipType[2],
                    AnimNames = new string[]
                    {
                        "idle_right",
                        "idle_left"
                    }
                };
                aiAnimator.IdleAnimation = new DirectionalAnimation
                {
                    Type = DirectionalAnimation.DirectionType.TwoWayHorizontal,
                    Flipped = new DirectionalAnimation.FlipType[2],
                    AnimNames = new string[]
                    {
                        "attack_right",
                        "attack_left"
                    }
                };
                bool flag3 = Vengeance.pointzeroCollection == null;
                if (flag3)
                {
                    Vengeance.pointzeroCollection = SpriteBuilder.ConstructCollection(Vengeance.VengeancePrefab, "Penguin_Collection");
                    UnityEngine.Object.DontDestroyOnLoad(Vengeance.pointzeroCollection);
                    for (int i = 0; i < Vengeance.spritePaths.Length; i++)
                    {
                        SpriteBuilder.AddSpriteToCollection(Vengeance.spritePaths[i], Vengeance.pointzeroCollection);
                    }
                    SpriteBuilder.AddAnimation(vengeanceBehavior.spriteAnimator, Vengeance.pointzeroCollection, new List<int>
                    {
                        0,
                        1,
                        2,
                        3,
                        4,
                        5,
                        6,
                        7
                    }, "idle_left", tk2dSpriteAnimationClip.WrapMode.Loop).fps = 8f;
                    SpriteBuilder.AddAnimation(vengeanceBehavior.spriteAnimator, Vengeance.pointzeroCollection, new List<int>
                    {
                        0,
                        1,
                        2,
                        3,
                        4,
                        5,
                        6,
                        7
                    }, "idle_right", tk2dSpriteAnimationClip.WrapMode.Loop).fps = 8f;
                    SpriteBuilder.AddAnimation(vengeanceBehavior.spriteAnimator, Vengeance.pointzeroCollection, new List<int>
                    {
                        0,
                        1,
                        2,
                        3,
                        4,
                        5,
                        6,
                        7
                    }, "run_left", tk2dSpriteAnimationClip.WrapMode.Loop).fps = 8f;
                    SpriteBuilder.AddAnimation(vengeanceBehavior.spriteAnimator, Vengeance.pointzeroCollection, new List<int>
                    {
                        0,
                        1,
                        2,
                        3,
                        4,
                        5,
                        6,
                        7
                    }, "run_right", tk2dSpriteAnimationClip.WrapMode.Loop).fps = 8f;
                    SpriteBuilder.AddAnimation(vengeanceBehavior.spriteAnimator, Vengeance.pointzeroCollection, new List<int>
                    {
                        8,
                        9,
                        10,
                        11,
                        12,
                        13,
                        14,
                        15
                    }, "attack_right", tk2dSpriteAnimationClip.WrapMode.Loop).fps = 8f;
                    SpriteBuilder.AddAnimation(vengeanceBehavior.spriteAnimator, Vengeance.pointzeroCollection, new List<int>
                    {
                        8,
                        9,
                        10,
                        11,
                        12,
                        13,
                        14,
                        15
                    }, "attack_left", tk2dSpriteAnimationClip.WrapMode.Loop).fps = 8f;
                }
                vengeanceBehavior.aiActor.MovementSpeed = 5f;
                vengeanceBehavior.specRigidbody.Reinitialize();
                vengeanceBehavior.specRigidbody.CollideWithTileMap = false;
                vengeanceBehavior.aiActor.CanTargetEnemies = true;
                BehaviorSpeculator behaviorSpeculator = vengeanceBehavior.behaviorSpeculator;
                behaviorSpeculator.AttackBehaviors.Add(new Vengeance.vengeanceattackBehavior());
                //behaviorSpeculator.MovementBehaviors.Add(new Vengeance.BehaviorBase());
                behaviorSpeculator.MovementBehaviors.Add(new CompanionFollowPlayerBehavior
                {
                    IdleAnimations = new string[]
                    {
                        "idle"
                    }
                });
                UnityEngine.Object.DontDestroyOnLoad(Vengeance.VengeancePrefab);
                FakePrefab.MarkAsFakePrefab(Vengeance.VengeancePrefab);
                Vengeance.VengeancePrefab.SetActive(false);
            }
        }

        // Token: 0x04000016 RID: 22
        public static GameObject VengeancePrefab;

        // Token: 0x04000017 RID: 23
        public static readonly string guid = "VengeanceClone";

        private List<CompanionController> companionsSpawned = new List<CompanionController>();


        // Token: 0x04000018 RID: 24
        private static string[] spritePaths = new string[]
        {
            "ExampleMod/Resources/PZeroAnims/Idle/P-Zero_idle_001",
            "ExampleMod/Resources/PZeroAnims/Idle/P-Zero_idle_002",
            "ExampleMod/Resources/PZeroAnims/Idle/P-Zero_idle_003",
            "ExampleMod/Resources/PZeroAnims/Idle/P-Zero_idle_004",
            "ExampleMod/Resources/PZeroAnims/Idle/P-Zero_idle_005",
            "ExampleMod/Resources/PZeroAnims/Idle/P-Zero_idle_006",
            "ExampleMod/Resources/PZeroAnims/Idle/P-Zero_idle_007",
            "ExampleMod/Resources/PZeroAnims/Idle/P-Zero_idle_008",
            "ExampleMod/Resources/PZeroAnims/Attack/P-Zero_attack_001",
            "ExampleMod/Resources/PZeroAnims/Attack/P-Zero_attack_002",
            "ExampleMod/Resources/PZeroAnims/Attack/P-Zero_attack_003",
            "ExampleMod/Resources/PZeroAnims/Attack/P-Zero_attack_004",
            "ExampleMod/Resources/PZeroAnims/Attack/P-Zero_attack_005",
            "ExampleMod/Resources/PZeroAnims/Attack/P-Zero_attack_006",
            "ExampleMod/Resources/PZeroAnims/Attack/P-Zero_attack_007",
            "ExampleMod/Resources/PZeroAnims/Attack/P-Zero_attack_008",
        };

        // Token: 0x04000019 RID: 25
        private static tk2dSpriteCollectionData pointzeroCollection;

        // Token: 0x02000031 RID: 49
        public class VengeanceBehavior : CompanionController
        {
            // Token: 0x06000119 RID: 281 RVA: 0x0000A9D9 File Offset: 0x00008BD9
            private void Start()
            {
                base.spriteAnimator.Play("idle");
                this.Owner = this.m_owner;
            }

            // Token: 0x04000079 RID: 121
            public PlayerController Owner;
        }

        // Token: 0x02000032 RID: 50
        public class vengeanceattackBehavior : AttackBehaviorBase
        {
            public override void Destroy()
            {

                base.Destroy();
            }

            // Token: 0x0600011C RID: 284 RVA: 0x0000A9F9 File Offset: 0x00008BF9
            public void Init(GameObject gameObject, PlayerController Owner)
            {
                //base.Init(gameObject, Owner);
                this.Owner = this.m_aiActor.GetComponent<Vengeance.VengeanceBehavior>().Owner;
            }

            // Token: 0x0600011D RID: 285 RVA: 0x0000AA1C File Offset: 0x00008C1C
            public override BehaviorResult Update()
            {
                bool flag = this.attackTimer > 0f && this.isAttacking;
                if (flag)
                {
                    base.DecrementTimer(ref this.attackTimer, false);
                }
                else
                {

                    bool flag2 = this.attackCooldownTimer > 0f && !this.isAttacking;
                    if (flag2)
                    {

                        base.DecrementTimer(ref this.attackCooldownTimer, false);
                    }
                }
                bool flag3 = this.IsReady();
                bool flag4 = (!flag3 || this.attackCooldownTimer > 0f || this.attackTimer == 0f || Owner.specRigidbody == null) && this.isAttacking;
                BehaviorResult result;
                if (flag4)
                {

                    this.StopAttacking();
                    result = BehaviorResult.Continue;
                }
                else
                {

                    bool flag5 = flag3 && this.attackCooldownTimer == 0f && !this.isAttacking;
                    if (flag5)
                    {

                        this.attackTimer = this.attackDuration;
                        this.isAttacking = true;
                    }
                    bool flag6 = this.attackTimer > 0f && flag3;
                    if (flag6)
                    {

                        this.Attack();
                        result = BehaviorResult.SkipAllRemainingBehaviors;
                    }
                    else
                    {

                        result = BehaviorResult.Continue;
                    }
                }
                return result;
            }

            // Token: 0x0600011E RID: 286 RVA: 0x0000AB30 File Offset: 0x00008D30
            private void StopAttacking()
            {
                this.isAttacking = false;
                this.attackTimer = 0f;
                this.attackCooldownTimer = this.attackCooldown;
            }

            // Token: 0x0600011F RID: 287 RVA: 0x0000AB54 File Offset: 0x00008D54
            public PlayerController GetNearestEnemy(PlayerController Owner, Vector2 position, out float nearestDistance)
            {
                nearestDistance = float.MaxValue;
                {
                    PlayerController result;
                    {
                        float num = Vector2.Distance(position, Owner.sprite.WorldCenter);
                        bool flag13 = num < nearestDistance;
                        bool flag14 = flag13;
                        bool flag15 = flag14;
                        if (flag15)
                        {
                            nearestDistance = num;
                        }
                        result = Owner;
                    }
                    return result;
                }
            }

            // Token: 0x06000120 RID: 288 RVA: 0x0000AC74 File Offset: 0x00008E74
            private void Attack()
            {

                bool flag = this.Owner == null;
                if (flag)
                {
                    this.Owner = this.m_aiActor.GetComponent<Vengeance.VengeanceBehavior>().Owner;
                }
                //float num = -1f;
                {

                    Vector2 unitCenter = this.m_aiActor.specRigidbody.UnitCenter;
                    Vector2 unitCenter2 = Owner.specRigidbody.HitboxPixelCollider.UnitCenter;
                    float z = BraveMathCollege.Atan2Degrees((unitCenter2 - unitCenter).normalized);
                    Projectile projectile = ((Gun)ETGMod.Databases.Items[576]).DefaultModule.projectiles[0];
                    GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, this.m_aiActor.sprite.WorldCenter, Quaternion.Euler(0f, 0f, z + UnityEngine.Random.Range(-60, 60)), true);
                    Projectile component = gameObject.GetComponent<Projectile>();
                    HomingModifier homing = component.gameObject.AddComponent<HomingModifier>();
                    homing.HomingRadius = 300;
                    homing.AngularVelocity = 300;
                    PierceProjModifier spook = component.gameObject.AddComponent<PierceProjModifier>();
                    spook.penetration = 10;
                    BounceProjModifier bouncy = component.gameObject.AddComponent<BounceProjModifier>();
                    bouncy.numberOfBounces = 10;
                    bool flag6 = component != null;
                    bool flag7 = flag6;
                    if (flag7)
                    {

                        {
                            component.baseData.damage = 4f;
                        }

                        component.baseData.force = .5f;
                        component.collidesWithPlayer = false;
                    }
                }
            }

            // Token: 0x06000121 RID: 289 RVA: 0x0000AE80 File Offset: 0x00009080
            public override float GetMaxRange()
            {
                return 5f;
            }

            // Token: 0x06000122 RID: 290 RVA: 0x0000AE98 File Offset: 0x00009098
            public override float GetMinReadyRange()
            {
                return 15f;
            }

            // Token: 0x06000123 RID: 291 RVA: 0x0000AEB0 File Offset: 0x000090B0
            public override bool IsReady()
            {

                {
                    SpeculativeRigidbody targetRigidbody = Owner.specRigidbody;
                    Vector2? vector = (targetRigidbody != null) ? new Vector2?(targetRigidbody.UnitCenter) : null;
                }
                return Vector2.Distance(this.m_aiActor.specRigidbody.UnitCenter, this.m_aiActor.TargetRigidbody.UnitCenter) <= this.GetMinReadyRange();
            }

            // Token: 0x06000124 RID: 292 RVA: 0x0000AF30 File Offset: 0x00009130
            public bool IsInRange(PlayerController Owner)
            {

                {
                    SpeculativeRigidbody specRigidbody = Owner.specRigidbody;
                    Vector2? vector = (specRigidbody != null) ? new Vector2?(specRigidbody.UnitCenter) : null;
                }
                return Vector2.Distance(this.m_aiActor.specRigidbody.UnitCenter, Owner.specRigidbody.UnitCenter) <= this.GetMinReadyRange();
            }

            // Token: 0x0400007A RID: 122
            private bool isAttacking;

            // Token: 0x0400007B RID: 123
            private float attackCooldown = 3f;

            // Token: 0x0400007C RID: 124
            private float attackDuration = 0.5f;

            // Token: 0x0400007D RID: 125
            private float attackTimer;

            // Token: 0x0400007E RID: 126
            private float attackCooldownTimer;

            // Token: 0x0400007F RID: 127
            private PlayerController Owner;

            // Token: 0x04000080 RID: 128
        }
    }
}
