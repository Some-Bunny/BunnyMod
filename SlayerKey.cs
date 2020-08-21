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



namespace BunnyMod
{
    public class SlayerKey : PlayerItem
    {
        private float random;

        public float Random { get; private set; }
        public static void Init()
        {
            string itemName = "Gunslayer Key";
            string resourceName = "ExampleMod/Resources/slayerkey";
            GameObject obj = new GameObject(itemName);
            SlayerKey slayerKey = obj.AddComponent<SlayerKey>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Clip and Bear";
            string longDesc = "A key made of bodies of powerful gundead. It is said that this key once belonged to the Gunslayer, who used it to combat great beasts for fun. To taunt them, he'd permanantly leave behind a piece of his arsenal.\n\n Noone knows where the Gunslayer is now, as he disappeared without a trace.";
            slayerKey.SetupItem(shortDesc, longDesc, "bny");
            slayerKey.SetCooldownType(ItemBuilder.CooldownType.Damage, 1200f);
            slayerKey.consumable = false;
            slayerKey.quality = PickupObject.ItemQuality.A;
            slayerKey.AddToSubShop(ItemBuilder.ShopType.Flynt, 1f);
        }
        public override void Pickup(PlayerController owner)
        {
            AkSoundEngine.PostEvent("Play_OBJ_goldkey_pickup_01", base.gameObject);
            base.Pickup(owner);
        }
        protected override void DoEffect(PlayerController user)
        {
            this.random = UnityEngine.Random.Range(0.0f, 1.0f);
            if (random <= 0.833f)
            {
                AkSoundEngine.PostEvent("Play_OBJ_goldenlock_open_01", base.gameObject);
                this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                if (random <= 0.33f)
                {
                    string guid;
                    guid = "cd4a4b7f612a4ba9a720b9f97c52f38c";
                    PlayerController owner = base.LastOwner;
                    AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                    IntVector2? intVector = new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                    AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                    aiactor.CanTargetEnemies = false;
                    aiactor.CanTargetPlayers = true;
                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                    aiactor.IsHarmlessEnemy = false;
                    aiactor.IgnoreForRoomClear = false;
                    aiactor.HandleReinforcementFallIntoRoom(0f);
                }
                else
                {
                    this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                    if (random <= 0.33f)
                    {
                        string guid;
                        guid = "98ea2fe181ab4323ab6e9981955a9bca";
                        PlayerController owner = base.LastOwner;
                        AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                        IntVector2? intVector = new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                        AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                        aiactor.CanTargetEnemies = false;
                        aiactor.CanTargetPlayers = true;
                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                        aiactor.IsHarmlessEnemy = false;
                        aiactor.IgnoreForRoomClear = false;
                        aiactor.HandleReinforcementFallIntoRoom(0f);

                    }
                    else
                    {
                        this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                        if (random <= 0.33f)
                        {
                            string guid;
                            guid = "383175a55879441d90933b5c4e60cf6f";
                            PlayerController owner = base.LastOwner;
                            AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                            IntVector2? intVector = new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                            AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                            aiactor.CanTargetEnemies = false;
                            aiactor.CanTargetPlayers = true;
                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                            aiactor.IsHarmlessEnemy = false;
                            aiactor.IgnoreForRoomClear = false;
                            aiactor.HandleReinforcementFallIntoRoom(0f);

                        }
                        else
                        {
                            this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                            if (random <= 0.33f)
                            {
                                string guid;
                                guid = "d5a7b95774cd41f080e517bea07bf495";
                                PlayerController owner = base.LastOwner;
                                AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                IntVector2? intVector = new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                                aiactor.CanTargetEnemies = false;
                                aiactor.CanTargetPlayers = true;
                                PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                aiactor.IsHarmlessEnemy = false;
                                aiactor.IgnoreForRoomClear = false;
                                aiactor.HandleReinforcementFallIntoRoom(0f);

                            }
                            else
                            {
                                this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                if (random <= 0.33f)
                                {
                                    string guid;
                                    guid = "1bc2a07ef87741be90c37096910843ab";
                                    PlayerController owner = base.LastOwner;
                                    AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                    IntVector2? intVector = new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                    AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                                    aiactor.CanTargetEnemies = false;
                                    aiactor.CanTargetPlayers = true;
                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                    aiactor.IsHarmlessEnemy = false;
                                    aiactor.IgnoreForRoomClear = false;
                                    aiactor.HandleReinforcementFallIntoRoom(0f);

                                }
                                else
                                {
                                    string guid;
                                    guid = "21dd14e5ca2a4a388adab5b11b69a1e1";
                                    PlayerController owner = base.LastOwner;
                                    AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                    IntVector2? intVector = new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                    AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                                    aiactor.CanTargetEnemies = false;
                                    aiactor.CanTargetPlayers = true;
                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                    aiactor.IsHarmlessEnemy = false;
                                    aiactor.IgnoreForRoomClear = false;
                                    aiactor.HandleReinforcementFallIntoRoom(0f);
                                }
                            }
                        }
                    }
                }
                this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                if (random <= 0.33f)
                {
                    string guid;
                    guid = "cd4a4b7f612a4ba9a720b9f97c52f38c";
                    PlayerController owner = base.LastOwner;
                    AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                    IntVector2? intVector = new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                    AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                    aiactor.CanTargetEnemies = false;
                    aiactor.CanTargetPlayers = true;
                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                    aiactor.IsHarmlessEnemy = false;
                    aiactor.IgnoreForRoomClear = false;
                    aiactor.HandleReinforcementFallIntoRoom(0f);
                }
                else
                {
                    this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                    if (random <= 0.33f)
                    {
                        string guid;
                        guid = "98ea2fe181ab4323ab6e9981955a9bca";
                        PlayerController owner = base.LastOwner;
                        AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                        IntVector2? intVector = new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                        AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                        aiactor.CanTargetEnemies = false;
                        aiactor.CanTargetPlayers = true;
                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                        aiactor.IsHarmlessEnemy = false;
                        aiactor.IgnoreForRoomClear = false;
                        aiactor.HandleReinforcementFallIntoRoom(0f);

                    }
                    else
                    {
                        this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                        if (random <= 0.33f)
                        {
                            string guid;
                            guid = "383175a55879441d90933b5c4e60cf6f";
                            PlayerController owner = base.LastOwner;
                            AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                            IntVector2? intVector = new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                            AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                            aiactor.CanTargetEnemies = false;
                            aiactor.CanTargetPlayers = true;
                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                            aiactor.IsHarmlessEnemy = false;
                            aiactor.IgnoreForRoomClear = false;
                            aiactor.HandleReinforcementFallIntoRoom(0f);

                        }
                        else
                        {
                            this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                            if (random <= 0.33f)
                            {
                                string guid;
                                guid = "d5a7b95774cd41f080e517bea07bf495";
                                PlayerController owner = base.LastOwner;
                                AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                IntVector2? intVector = new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                                aiactor.CanTargetEnemies = false;
                                aiactor.CanTargetPlayers = true;
                                PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                aiactor.IsHarmlessEnemy = false;
                                aiactor.IgnoreForRoomClear = false;
                                aiactor.HandleReinforcementFallIntoRoom(0f);

                            }
                            else
                            {
                                this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                if (random <= 0.33f)
                                {
                                    string guid;
                                    guid = "1bc2a07ef87741be90c37096910843ab";
                                    PlayerController owner = base.LastOwner;
                                    AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                    IntVector2? intVector = new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                    AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                                    aiactor.CanTargetEnemies = false;
                                    aiactor.CanTargetPlayers = true;
                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                    aiactor.IsHarmlessEnemy = false;
                                    aiactor.IgnoreForRoomClear = false;
                                    aiactor.HandleReinforcementFallIntoRoom(0f);

                                }
                                else
                                {
                                    string guid;
                                    guid = "21dd14e5ca2a4a388adab5b11b69a1e1";
                                    PlayerController owner = base.LastOwner;
                                    AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                    IntVector2? intVector = new IntVector2?(base.LastOwner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                    AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                                    aiactor.CanTargetEnemies = false;
                                    aiactor.CanTargetPlayers = true;
                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                    aiactor.IsHarmlessEnemy = false;
                                    aiactor.IgnoreForRoomClear = false;
                                    aiactor.HandleReinforcementFallIntoRoom(0f);
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                IntVector2 randomVisibleClearSpot6 = user.CurrentRoom.GetRandomVisibleClearSpot(1, 1);
                GameManager.Instance.RewardManager.SpawnRewardChestAt(randomVisibleClearSpot6, -1f, PickupObject.ItemQuality.EXCLUDED);
                LootEngine.GivePrefabToPlayer(PickupObjectDatabase.GetById(67).gameObject, user);
            }
        }
    }
}
