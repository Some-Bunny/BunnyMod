﻿using System;
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
    public class CrownOfBlood : PassiveItem
    {
        private float random;

        public bool WaitTillBolld { get; private set; }

        public static void Init()
        {
            string itemName = "Cystful Crown";
            string resourceName = "ExampleMod/Resources/crownofblood";
            GameObject obj = new GameObject(itemName);
            CrownOfBlood crownOfBlood = obj.AddComponent<CrownOfBlood>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Its the meta!";
            string longDesc = "A royal crown that has a large bloody cyst growing in it.\n\n" +
                "Everyone hates it, and stronger creatures will go out of their way to get rid of it, but it looks kinda cool.";
            crownOfBlood.SetupItem(shortDesc, longDesc, "bny");
            crownOfBlood.AddPassiveStatModifier(PlayerStats.StatType.Coolness, 3f, StatModifier.ModifyMethod.ADDITIVE);
            crownOfBlood.AddPassiveStatModifier(PlayerStats.StatType.Curse, 1f, StatModifier.ModifyMethod.ADDITIVE);
            crownOfBlood.AddPassiveStatModifier(PlayerStats.StatType.MovementSpeed, 1.2f, StatModifier.ModifyMethod.MULTIPLICATIVE);
            crownOfBlood.AddPassiveStatModifier(PlayerStats.StatType.Damage, .35f, StatModifier.ModifyMethod.ADDITIVE);
            crownOfBlood.quality = PickupObject.ItemQuality.A;
            crownOfBlood.AddToSubShop(ItemBuilder.ShopType.Cursula, 1f);
            crownOfBlood.AddToSubShop(ItemBuilder.ShopType.Goopton, 1f);
        }
        private void CrownCraze()
        {
            GameManager.Instance.StartCoroutine(AhShitWereGoGoAgain());

        }
        private IEnumerator AhShitWereGoGoAgain()
        {
            yield return new WaitForSeconds(3.5f);
            {
                for (int counter = 0; counter < 1; counter++)
                {
                    this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                    if (random <= 0.20f)
                    {
                        string guid;
                        guid = "ba657723b2904aa79f9e51bce7d23872";
                        PlayerController owner = base.Owner;
                        AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                        IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                        AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                        aiactor.CanTargetEnemies = false;
                        aiactor.CanTargetPlayers = true;
                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                        aiactor.gameObject.AddComponent<KillOnRoomClear>();
                        aiactor.IsHarmlessEnemy = false;
                        aiactor.IgnoreForRoomClear = true;
                        aiactor.HandleReinforcementFallIntoRoom(0f);
                    }
                    else
                    {
                        this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                        if (random <= 0.20f)
                        {
                            string guid;
                            guid = "19b420dec96d4e9ea4aebc3398c0ba7a";
                            PlayerController owner = base.Owner;
                            AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                            IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                            AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                            aiactor.CanTargetEnemies = false;
                            aiactor.CanTargetPlayers = true;
                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                            aiactor.gameObject.AddComponent<KillOnRoomClear>();
                            aiactor.IsHarmlessEnemy = false;
                            aiactor.IgnoreForRoomClear = true;
                            aiactor.HandleReinforcementFallIntoRoom(0f);
                        }
                        else
                        {
                            this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                            if (random <= 0.25f)
                            {
                                string guid;
                                guid = "c5b11bfc065d417b9c4d03a5e385fe2c";
                                PlayerController owner = base.Owner;
                                AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                aiactor.CanTargetEnemies = false;
                                aiactor.CanTargetPlayers = true;
                                PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                aiactor.IsHarmlessEnemy = false;
                                aiactor.IgnoreForRoomClear = true;
                                aiactor.HandleReinforcementFallIntoRoom(0f);
                            }
                            else
                            {
                                this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                if (random <= 0.25f)
                                {
                                    string guid;
                                    guid = "ffdc8680bdaa487f8f31995539f74265";
                                    PlayerController owner = base.Owner;
                                    AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                    IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                    AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                    aiactor.CanTargetEnemies = false;
                                    aiactor.CanTargetPlayers = true;
                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                    aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                    aiactor.IsHarmlessEnemy = false;
                                    aiactor.IgnoreForRoomClear = true;
                                    aiactor.HandleReinforcementFallIntoRoom(0f);
                                }
                                else
                                {
                                    this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                    if (random <= 0.25f)
                                    {
                                        string guid;
                                        guid = "844657ad68894a4facb1b8e1aef1abf9";
                                        PlayerController owner = base.Owner;
                                        AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                        IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                        AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                        aiactor.CanTargetEnemies = false;
                                        aiactor.CanTargetPlayers = true;
                                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                        aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                        aiactor.IsHarmlessEnemy = false;
                                        aiactor.IgnoreForRoomClear = true;
                                        aiactor.HandleReinforcementFallIntoRoom(0f);
                                    }
                                    else
                                    {
                                        this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                        if (random <= 0.25f)
                                        {
                                            string guid;
                                            guid = "2752019b770f473193b08b4005dc781f";
                                            PlayerController owner = base.Owner;
                                            AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                            IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                            AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                            aiactor.CanTargetEnemies = false;
                                            aiactor.CanTargetPlayers = true;
                                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                            aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                            aiactor.IsHarmlessEnemy = false;
                                            aiactor.IgnoreForRoomClear = true;
                                            aiactor.HandleReinforcementFallIntoRoom(0f);
                                        }
                                        else
                                        {
                                            this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                            if (random <= 0.25f)
                                            {
                                                string guid;
                                                guid = "1a4872dafdb34fd29fe8ac90bd2cea67";
                                                PlayerController owner = base.Owner;
                                                AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                                IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                                AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                                aiactor.CanTargetEnemies = false;
                                                aiactor.CanTargetPlayers = true;
                                                PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                                aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                                aiactor.IsHarmlessEnemy = false;
                                                aiactor.IgnoreForRoomClear = true;
                                                aiactor.HandleReinforcementFallIntoRoom(0f);
                                            }
                                            else
                                            {
                                                this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                                if (random <= 0.25f)
                                                {
                                                    string guid;
                                                    guid = "b1770e0f1c744d9d887cc16122882b4f";
                                                    PlayerController owner = base.Owner;
                                                    AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                                    IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                                    AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                                    aiactor.CanTargetEnemies = false;
                                                    aiactor.CanTargetPlayers = true;
                                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                                    aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                                    aiactor.IsHarmlessEnemy = false;
                                                    aiactor.IgnoreForRoomClear = true;
                                                    aiactor.HandleReinforcementFallIntoRoom(0f);
                                                }
                                                else
                                                {
                                                    this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                                    if (random <= 0.25f)
                                                    {
                                                        string guid;
                                                        guid = "4db03291a12144d69fe940d5a01de376";
                                                        PlayerController owner = base.Owner;
                                                        AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                                        IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                                        AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                                        aiactor.CanTargetEnemies = false;
                                                        aiactor.CanTargetPlayers = true;
                                                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                                        aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                                        aiactor.IsHarmlessEnemy = false;
                                                        aiactor.IgnoreForRoomClear = true;
                                                        aiactor.HandleReinforcementFallIntoRoom(0f);
                                                    }
                                                    else
                                                    {
                                                        this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                                        if (random <= 0.25f)
                                                        {
                                                            string guid;
                                                            guid = "116d09c26e624bca8cca09fc69c714b3";
                                                            PlayerController owner = base.Owner;
                                                            AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                                            IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                                            AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                                            aiactor.CanTargetEnemies = false;
                                                            aiactor.CanTargetPlayers = true;
                                                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                                            aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                                            aiactor.IsHarmlessEnemy = false;
                                                            aiactor.IgnoreForRoomClear = true;
                                                            aiactor.HandleReinforcementFallIntoRoom(0f);
                                                        }
                                                        else
                                                        {
                                                            string guid;
                                                            guid = "9b2cf2949a894599917d4d391a0b7394";
                                                            PlayerController owner = base.Owner;
                                                            AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                                            IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                                            AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                                            aiactor.CanTargetEnemies = false;
                                                            aiactor.CanTargetPlayers = true;
                                                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                                            aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                                            aiactor.IsHarmlessEnemy = false;
                                                            aiactor.IgnoreForRoomClear = true;
                                                            aiactor.HandleReinforcementFallIntoRoom(0f);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                {
                                    this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                    if (random <= 0.33f)
                                    {
                                        string guid;
                                        guid = "9b4fb8a2a60a457f90dcf285d34143ac";
                                        PlayerController owner = base.Owner;
                                        AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                        IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                        AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                        aiactor.CanTargetEnemies = false;
                                        aiactor.CanTargetPlayers = true;
                                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                        aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                        aiactor.IsHarmlessEnemy = false;
                                        aiactor.IgnoreForRoomClear = true;
                                        aiactor.HandleReinforcementFallIntoRoom(0f);
                                    }
                                    else
                                    {
                                        this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                        if (random <= 0.33f)
                                        {
                                            string guid;
                                            guid = "206405acad4d4c33aac6717d184dc8d4";
                                            PlayerController owner = base.Owner;
                                            AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                            IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                            AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                            aiactor.CanTargetEnemies = false;
                                            aiactor.CanTargetPlayers = true;
                                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                            aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                            aiactor.IsHarmlessEnemy = false;
                                            aiactor.IgnoreForRoomClear = true;
                                            aiactor.HandleReinforcementFallIntoRoom(0f);
                                        }
                                        else
                                        {
                                            this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                            if (random <= 0.2f)
                                            {
                                                string guid;
                                                guid = "43426a2e39584871b287ac31df04b544";
                                                PlayerController owner = base.Owner;
                                                AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                                IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                                AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                                aiactor.CanTargetEnemies = false;
                                                aiactor.CanTargetPlayers = true;
                                                PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                                aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                                aiactor.IsHarmlessEnemy = false;
                                                aiactor.IgnoreForRoomClear = true;
                                                aiactor.HandleReinforcementFallIntoRoom(0f);
                                            }
                                            else
                                            {
                                                this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                                if (random <= 0.33f)
                                                {
                                                    string guid;
                                                    guid = "b54d89f9e802455cbb2b8a96a31e8259";
                                                    PlayerController owner = base.Owner;
                                                    AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                                    IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                                    AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                                    aiactor.CanTargetEnemies = false;
                                                    aiactor.CanTargetPlayers = true;
                                                    PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                                    aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                                    aiactor.IsHarmlessEnemy = false;
                                                    aiactor.IgnoreForRoomClear = true;
                                                    aiactor.HandleReinforcementFallIntoRoom(0f);
                                                }
                                                else
                                                {
                                                    this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                                    if (random <= 0.33f)
                                                    {
                                                        string guid;
                                                        guid = "128db2f0781141bcb505d8f00f9e4d47";
                                                        PlayerController owner = base.Owner;
                                                        AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                                        IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                                        AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                                        aiactor.CanTargetEnemies = false;
                                                        aiactor.CanTargetPlayers = true;
                                                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                                        aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                                        aiactor.IsHarmlessEnemy = false;
                                                        aiactor.IgnoreForRoomClear = true;
                                                        aiactor.HandleReinforcementFallIntoRoom(0f);
                                                    }
                                                    else
                                                    {
                                                        this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                                        if (random <= 0.2f)
                                                        {
                                                            string guid;
                                                            guid = "249db525a9464e5282d02162c88e0357";
                                                            PlayerController owner = base.Owner;
                                                            AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                                            IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                                            AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                                            aiactor.CanTargetEnemies = false;
                                                            aiactor.CanTargetPlayers = true;
                                                            PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                                            aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                                            aiactor.IsHarmlessEnemy = false;
                                                            aiactor.IgnoreForRoomClear = true;
                                                            aiactor.HandleReinforcementFallIntoRoom(0f);
                                                        }
                                                        else
                                                        {
                                                            this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                                                            if (random <= 0.33f)
                                                            {
                                                                string guid;
                                                                guid = "c0ff3744760c4a2eb0bb52ac162056e6";
                                                                PlayerController owner = base.Owner;
                                                                AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                                                IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                                                AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                                                aiactor.CanTargetEnemies = false;
                                                                aiactor.CanTargetPlayers = true;
                                                                PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                                                aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                                                aiactor.IsHarmlessEnemy = false;
                                                                aiactor.IgnoreForRoomClear = true;
                                                                aiactor.HandleReinforcementFallIntoRoom(0f);
                                                            }
                                                            else
                                                            {
                                                                string guid;
                                                                guid = "b1540990a4f1480bbcb3bea70d67f60d";
                                                                PlayerController owner = base.Owner;
                                                                AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                                                                IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                                                                AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, 0, true);
                                                                aiactor.CanTargetEnemies = false;
                                                                aiactor.CanTargetPlayers = true;
                                                                PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                                                                aiactor.gameObject.AddComponent<KillOnRoomClear>();
                                                                aiactor.IsHarmlessEnemy = false;
                                                                aiactor.IgnoreForRoomClear = true;
                                                                aiactor.HandleReinforcementFallIntoRoom(0f);
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }      
            }
            yield break;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            Tools.Print($"Player picked up {this.DisplayName}");
            player.OnEnteredCombat += (Action)Delegate.Combine(player.OnEnteredCombat, new Action(this.CrownCraze));
        }
        public override DebrisObject Drop(PlayerController player)
        {
            player.OnEnteredCombat -= (Action)Delegate.Combine(player.OnEnteredCombat, new Action(this.CrownCraze));
            Tools.Print($"Player dropped {this.DisplayName}");
            return base.Drop(player);
        }
    }
}