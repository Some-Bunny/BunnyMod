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
    public class ChaosChamber : PassiveItem
    {
        private float random;

        public PlayerStats.StatType Damage { get; private set; }

        public static void Init()
        {
            string itemName = "Chaos Chamber";
            string resourceName = "ExampleMod/Resources/chaoschamber";
            GameObject obj = new GameObject(itemName);
            ChaosChamber chaosChamber = obj.AddComponent<ChaosChamber>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Unpredictable Clips";
            string longDesc = "The legendary chamber of a gun that was made by accident when a material forged with the concepts of reality was accidentally added to a custom design revolver. Legends say that while the gun was hidden, the chamber escaped.\n\n" + "Taking it out lets it whisper ancient secrets long enough for you to physically change.";
            chaosChamber.SetupItem(shortDesc, longDesc, "bny");
            chaosChamber.AddPassiveStatModifier(PlayerStats.StatType.Damage, .3f, StatModifier.ModifyMethod.ADDITIVE);
            chaosChamber.AddPassiveStatModifier(PlayerStats.StatType.RateOfFire, .2f, StatModifier.ModifyMethod.ADDITIVE);
            chaosChamber.AddPassiveStatModifier(PlayerStats.StatType.ReloadSpeed, -0.2f, StatModifier.ModifyMethod.ADDITIVE);
            chaosChamber.AddPassiveStatModifier(PlayerStats.StatType.Accuracy, .9f, StatModifier.ModifyMethod.MULTIPLICATIVE);
            chaosChamber.quality = PickupObject.ItemQuality.A;
            chaosChamber.AddToSubShop(ItemBuilder.ShopType.Trorc, 1f);
            chaosChamber.AddToSubShop(ItemBuilder.ShopType.Cursula, 1f);
        }

        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            Tools.Print($"Player picked up {this.DisplayName}");
            ChaosChamber.fleeData = new FleePlayerData();
            ChaosChamber.fleeData.Player = player;
            ChaosChamber.fleeData.StartDistance = 100f;
            player.OnReloadedGun += (Action<PlayerController, Gun>)Delegate.Combine(player.OnReloadedGun, new Action<PlayerController, Gun>(this.HandleGunReloaded));
            player.OnDealtDamageContext += this.OnDealtDamage;
        }
        public override DebrisObject Drop(PlayerController player)
        {
            DebrisObject result = base.Drop(player);
            player.OnDealtDamageContext -= this.OnDealtDamage;
            player.OnReloadedGun -= (Action<PlayerController, Gun>)Delegate.Remove(player.OnReloadedGun, new Action<PlayerController, Gun>(this.HandleGunReloaded));
            return result;
        }
        private void OnDealtDamage(PlayerController usingPlayer, float amount, bool fatal, HealthHaver targetr)
        {
            bool flag1 = usingPlayer.HasPickupID(Game.Items["bny:chaos_revolver"].PickupObjectId);
            if (flag1)
            {
                int num3 = UnityEngine.Random.Range(0, 2);
                bool flag3 = num3 == 0;
                if (flag3)
                {
                    Vector3 position = base.Owner.sprite.WorldCenter;
                    this.Boom(position);
                }
                bool flag4 = num3 == 0;
                if (flag4)
                {

                }
                bool flag5 = num3 == 0;
                if (flag5)
                {

                }
            }
        }
        private void HandleGunReloaded(PlayerController player, Gun playerGun)
        {
            bool flag = playerGun.ClipShotsRemaining == 0;
            {
                bool flag1 = player.HasPickupID(Game.Items["bny:chaos_revolver"].PickupObjectId);
                if (flag1)
                {
                    AkSoundEngine.PostEvent("Play_VO_lichA_chuckle_01", base.gameObject);
                    int num3 = UnityEngine.Random.Range(0, 5);
                    bool flag3 = num3 == 0;
                    if (flag3)
                    {
                        for (int counter = 0; counter < UnityEngine.Random.Range(1f, 4f); counter++)
                        {
                            Projectile projectile = ((Gun)ETGMod.Databases.Items[19]).DefaultModule.projectiles[0];
                            GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, base.Owner.sprite.WorldCenter, Quaternion.Euler(0f, 0f, (base.Owner.CurrentGun == null) ? 0f : UnityEngine.Random.Range(0, 359)), true);
                            Projectile component = gameObject.GetComponent<Projectile>();
                            bool flagA = component != null;
                            bool flagB = flagA;
                            if (flagB)
                            {
                                BounceProjModifier bouncy = component.gameObject.AddComponent<BounceProjModifier>();
                                bouncy.numberOfBounces = 2;
                                component.Owner = base.Owner;
                                component.Shooter = base.Owner.specRigidbody;
                                component.baseData.speed = 3f;
                                component.baseData.range = UnityEngine.Random.Range(2f, 8f);
                                component.OnDestruction += this.HellaFire;
                            }
                        }  
                    }
                    bool flag4 = num3 == 1;
                    if (flag4)
                    {
                        Vector3 position = base.Owner.sprite.WorldCenter;
                        this.Boom(position);
                    }
                    bool flag5 = num3 == 2;
                    if (flag5)
                    {
                        for (int counter = 0; counter < UnityEngine.Random.Range(20f, 40f); counter++)
                        {
                            Projectile projectile = ((Gun)ETGMod.Databases.Items[178]).DefaultModule.projectiles[0];
                            GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, base.Owner.sprite.WorldCenter, Quaternion.Euler(0f, 0f, (base.Owner.CurrentGun == null) ? 0f : UnityEngine.Random.Range(0, 359)), true);
                            Projectile component = gameObject.GetComponent<Projectile>();
                            bool flagA = component != null;
                            bool flagB = flagA;
                            if (flagB)
                            {
                                BounceProjModifier bouncy = component.gameObject.AddComponent<BounceProjModifier>();
                                bouncy.numberOfBounces = 2;
                                component.Owner = base.Owner;
                                component.Shooter = base.Owner.specRigidbody;
                                component.baseData.speed = 15f;
                                component.baseData.range = 20f;
                            }
                        }
                    }
                    bool flag6 = num3 == 3;
                    if (flag6)
                    {
                        string guid;
                        guid = "e21ac9492110493baef6df02a2682a0d";
                        PlayerController owner = base.Owner;
                        AIActor orLoadByGuid = EnemyDatabase.GetOrLoadByGuid(guid);
                        IntVector2? intVector = new IntVector2?(base.Owner.CurrentRoom.GetRandomVisibleClearSpot(2, 2));
                        AIActor aiactor = AIActor.Spawn(orLoadByGuid.aiActor, intVector.Value, GameManager.Instance.Dungeon.data.GetAbsoluteRoomFromPosition(intVector.Value), true, AIActor.AwakenAnimationType.Default, true);
                        aiactor.CanTargetEnemies = true;
                        aiactor.CanTargetPlayers = false;
                        PhysicsEngine.Instance.RegisterOverlappingGhostCollisionExceptions(aiactor.specRigidbody, null, false);
                        aiactor.gameObject.AddComponent<KillOnRoomClear>();
                        aiactor.IsHarmlessEnemy = true;
                        aiactor.IgnoreForRoomClear = true;
                        aiactor.HandleReinforcementFallIntoRoom(0f);
                    }
                    bool flag7 = num3 == 4;
                    if (flag7)
                    {
                        RoomHandler currentRoom = Owner.CurrentRoom;
                        bool flag2 = currentRoom.HasActiveEnemies(RoomHandler.ActiveEnemyType.All);
                        if (flag2)
                        {
                            foreach (AIActor aiactor in currentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All))
                            {
                                bool flagC = aiactor.behaviorSpeculator != null;
                                if (flagC)
                                {
                                    aiactor.behaviorSpeculator.FleePlayerData = ChaosChamber.fleeData;
                                    FleePlayerData fleePlayerData = new FleePlayerData();
                                    GameManager.Instance.StartCoroutine(ChaosChamber.yaddayaddareuseoldshit(aiactor));
                                }
                            }

                        }
                    }
                    bool flag8 = num3 == 5;
                    if (flag8)
                    {
                        for (int counter = 0; counter < 8; counter++)
                        {
                            Projectile projectile = ((Gun)ETGMod.Databases.Items[17]).DefaultModule.projectiles[0];
                            GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, base.Owner.sprite.WorldCenter, Quaternion.Euler(0f, 0f, (base.Owner.CurrentGun == null) ? 0f : base.Owner.CurrentGun.CurrentAngle), true);
                            Projectile component = gameObject.GetComponent<Projectile>();
                            bool flagD = component != null;
                            bool flag2 = flagD;
                            if (flag2)
                            {
                                component.Owner = base.Owner;
                                component.Shooter = base.Owner.specRigidbody;
                                component.baseData.speed = 20f;
                                component.baseData.damage = 0.1f;
                            }

                        }
                    }
                }
                else
                {
                    {
                        this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                    }
                    if (random <= 0.5f)
                    {
                        this.AddStat(PlayerStats.StatType.Damage, -0.05f, StatModifier.ModifyMethod.ADDITIVE);
                        player.stats.RecalculateStats(player, true, true);
                    }
                    else
                    {
                        this.AddStat(PlayerStats.StatType.Damage, 0.05f, StatModifier.ModifyMethod.ADDITIVE);
                        player.stats.RecalculateStats(player, true, true);
                    }
                    {
                        this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                    }
                    if (random <= 0.5f)
                    {
                        this.AddStat(PlayerStats.StatType.RateOfFire, .05f, StatModifier.ModifyMethod.ADDITIVE);
                        player.stats.RecalculateStats(player, true, true);
                    }
                    else
                    {
                        this.AddStat(PlayerStats.StatType.RateOfFire, -0.05f, StatModifier.ModifyMethod.ADDITIVE);
                        player.stats.RecalculateStats(player, true, true);
                    }
                    {
                        this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                    }
                    if (random <= 0.5f)
                    {
                        this.AddStat(PlayerStats.StatType.ReloadSpeed, 0.05f, StatModifier.ModifyMethod.ADDITIVE);
                        player.stats.RecalculateStats(player, true, true);
                    }
                    else
                    {
                        this.AddStat(PlayerStats.StatType.ReloadSpeed, -0.05f, StatModifier.ModifyMethod.ADDITIVE);
                        player.stats.RecalculateStats(player, true, true);
                    }
                    {
                        this.random = UnityEngine.Random.Range(0.0f, 1.0f);
                    }
                    if (random <= 0.5f)
                    {
                        this.AddStat(PlayerStats.StatType.Accuracy, 0.05f, StatModifier.ModifyMethod.ADDITIVE);
                        player.stats.RecalculateStats(player, true, true);
                    }
                    else
                    {
                        this.AddStat(PlayerStats.StatType.Accuracy, -0.05f, StatModifier.ModifyMethod.ADDITIVE);
                        player.stats.RecalculateStats(player, true, true);
                    }
                }
            }
        }

        private void AddStat(PlayerStats.StatType statType, float amount, StatModifier.ModifyMethod method = StatModifier.ModifyMethod.ADDITIVE)
        {
            StatModifier statModifier = new StatModifier
            {
                amount = amount,
                statToBoost = statType,
                modifyType = method
            };
            bool flag = this.passiveStatModifiers == null;
            if (flag)
            {
                this.passiveStatModifiers = new StatModifier[]
                {
                    statModifier
                };
            }
            else
            {
                this.passiveStatModifiers = this.passiveStatModifiers.Concat(new StatModifier[]
                {
                    statModifier
                }).ToArray<StatModifier>();
            }
        }
        private void HellaFire(Projectile obj)
		{
            AssetBundle assetBundle = ResourceManager.LoadAssetBundle("shared_auto_001");
            GoopDefinition goopDef = assetBundle.LoadAsset<GoopDefinition>("assets/data/goops/napalmgoopquickignite.asset");
            DeadlyDeadlyGoopManager.GetGoopManagerForGoopType(goopDef).TimedAddGoopCircle(obj.sprite.WorldBottomCenter, 2.5f, 1f, false);
        }

        public void Boom(Vector3 position)
        {
            ExplosionData defaultSmallExplosionData = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData;
            this.smallPlayerSafeExplosion.effect = defaultSmallExplosionData.effect;
            this.smallPlayerSafeExplosion.ignoreList = defaultSmallExplosionData.ignoreList;
            this.smallPlayerSafeExplosion.ss = defaultSmallExplosionData.ss;
            Exploder.Explode(position, this.smallPlayerSafeExplosion, Vector2.zero, null, false, CoreDamageTypes.None, false);
        }
        private ExplosionData smallPlayerSafeExplosion = new ExplosionData
        {
            damageRadius = 4.5f,
            damageToPlayer = 0f,
            doDamage = true,
            damage = 0f,
            doExplosionRing = false,
            doDestroyProjectiles = false,
            doForce = true,
            debrisForce = 20f,
            preventPlayerForce = false,
            explosionDelay = 0f,
            usesComprehensiveDelay = false,
            doScreenShake = false,
            playDefaultSFX = true
        };
        private static IEnumerator yaddayaddareuseoldshit(AIActor aiactor)
        {
            yield return new WaitForSeconds(3f);
            aiactor.behaviorSpeculator.FleePlayerData = null;
            yield break;
        }


        protected override void OnDestroy()
        {
            PlayerController owner = base.Owner;
            owner.OnReloadedGun = (Action<PlayerController, Gun>)Delegate.Remove(owner.OnReloadedGun, new Action<PlayerController, Gun>(this.HandleGunReloaded));
            base.OnDestroy();
        }
        private static FleePlayerData fleeData;

    }
}



