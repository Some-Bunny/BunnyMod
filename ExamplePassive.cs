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
    public class BookOfEconomics : PassiveItem
    {
        public static void Register()
        {
            string itemName = "Book Of Monetary Gain";
            string resourceName = "ExampleMod/Resources/bookofmonetarygain";
            GameObject obj = new GameObject(itemName);
            var item = obj.AddComponent<BookOfEconomics>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Get rich quick not guranteed";
            string longDesc = "Despite looking like its hundreds of pages, its acually one large cuboid block of paper with the text 'JUST GET MONEY' on the singular page.\n\n" +
                "The other page just has a block of cheese drawn crudely.";
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "bny");
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.MoneyMultiplierFromEnemies, .15f, StatModifier.ModifyMethod.ADDITIVE);
            item.quality = PickupObject.ItemQuality.D;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            Tools.Print($"Player picked up {this.DisplayName}");
        }
        public override DebrisObject Drop(PlayerController player)
        {
            Tools.Print($"Player dropped {this.DisplayName}");
            return base.Drop(player);
        }
    }
}


namespace BunnyMod
{
    public class LastResort : PlayerItem
    {
        public float Random { get; private set; }
        public static void Init()
        {
            string itemName = "The Last Resort";
            string resourceName = "ExampleMod/Resources/lastresort";
            GameObject obj = new GameObject(itemName);
            var item = obj.AddComponent<LastResort>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "When things go south";
            string longDesc = "A cursed revolver with one bullet, made for one purpose.\n\nTo send the user to hell.";
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "bny");
            ItemBuilder.SetCooldownType(item, ItemBuilder.CooldownType.Damage, 100f);
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.AdditionalItemCapacity, 1f, StatModifier.ModifyMethod.ADDITIVE);
            item.consumable = true;
            item.AddToSubShop(ItemBuilder.ShopType.Cursula, 1f);
            item.quality = PickupObject.ItemQuality.D;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }
        protected override void DoEffect(PlayerController user)
        {
            AkSoundEngine.PostEvent("Play_CHR_general_death_02", base.gameObject);
            new WaitForSeconds(2f);
            { 
                GameManager.Instance.LoadCustomLevel("tt_bullethell"); 
            }
        }
        private void ApplyStat(PlayerController player, PlayerStats.StatType statType, float amountToApply, StatModifier.ModifyMethod modifyMethod)
        {
            player.stats.RecalculateStats(player, false, false);
            StatModifier statModifier = new StatModifier()
            {
                statToBoost = statType,
                amount = amountToApply,
                modifyType = modifyMethod
            };
            player.ownerlessStatModifiers.Add(statModifier);
            player.stats.RecalculateStats(player, false, false);
        }
    }
}

namespace BunnyMod
{
    public class Coolrobes : PassiveItem
    {

        public static void Init()
        {
            string itemName = "Cool Robes";
            string resourceName = "ExampleMod/Resources/coolrobes";
            GameObject obj = new GameObject(itemName);
            var item = obj.AddComponent<Coolrobes>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Worn by cool Wardens";
            string longDesc = "A cool robe only worn by the coolest of people. Originally worn by a warden of a prison containing a god, these robes were passed down to the coolest in the family.\n\n" +
                "You WISH you were as cool as that. Hell, they're so cool, you don't even wanna take them off!";
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "bny");
            ItemBuilder.AddPassiveStatModifier(item, PlayerStats.StatType.Coolness, 3f, StatModifier.ModifyMethod.ADDITIVE);
            item.quality = PickupObject.ItemQuality.B;
            item.AddToSubShop(ItemBuilder.ShopType.Cursula, 1f);
            Coolrobes.CoolRobesID = item.PickupObjectId;
            List<string> mandatoryConsoleIDs2 = new List<string>
            {
                "bny:cool_robes",
                "bny:effigy_of_chaosgod"
            };
            CustomSynergies.Add("Relics Of The Past", mandatoryConsoleIDs2, null, true);
        }
        public static int CoolRobesID;

        public override void Pickup(PlayerController player)
        {
            this.CanBeDropped = false;
            base.Pickup(player);
            Tools.Print($"Player picked up {this.DisplayName}");
            PickupObject var = Gungeon.Game.Items["bny:cool_staff"];
            LootEngine.GivePrefabToPlayer(var.gameObject, player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            Tools.Print($"Player dropped {this.DisplayName}");
            return base.Drop(player);
        }
    }
}


namespace BunnyMod
{
    public class BulletRelic : PassiveItem
    {
        private float random;

        public static void Init()
        {
            string itemName = "Bullet Relic";

            string resourceName = "ExampleMod/Resources/bulletrelic";
            GameObject obj = new GameObject(itemName);
            BulletRelic bulletRelic = obj.AddComponent<BulletRelic>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Grave robbery";
            string longDesc = "An unusual relic from a lead-line of famous gundead from a past forgotten.\n\n" +
                "Despite them all being long-gone, they'll protect it as any cost, for whatever reason. You can't even use this thing as ammo!";
            bulletRelic.SetupItem(shortDesc, longDesc, "bny");
            bulletRelic.AddPassiveStatModifier(PlayerStats.StatType.Damage, .1f, StatModifier.ModifyMethod.ADDITIVE);
            bulletRelic.AddPassiveStatModifier(PlayerStats.StatType.Curse, .5f, StatModifier.ModifyMethod.ADDITIVE);
            bulletRelic.AddToSubShop(ItemBuilder.ShopType.Cursula, 1f);
            bulletRelic.quality = PickupObject.ItemQuality.D;
        }
        private void GuardTheTreasure()
        {
            this.random = UnityEngine.Random.Range(0.0f, 1.0f);
            if (random <= 0.1f)
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
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            Tools.Print($"Player picked up {this.DisplayName}");
            player.OnEnteredCombat += (Action)Delegate.Combine(player.OnEnteredCombat, new Action(this.GuardTheTreasure));
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.OnEnteredCombat -= (Action)Delegate.Combine(player.OnEnteredCombat, new Action(this.GuardTheTreasure));
            Tools.Print($"Player dropped {this.DisplayName}");
            return base.Drop(player);
        }
    }
}

namespace BunnyMod
{
    public class OnPlayerItemUsedItem : PassiveItem
    {

        public static void Init()
        {
            string itemName = "Broken Core";

            string resourceName = "ExampleMod/Resources/brokencore";
            GameObject obj = new GameObject(itemName);
            OnPlayerItemUsedItem brokenCore = obj.AddComponent<OnPlayerItemUsedItem>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Old Bio-Machinery";
            string longDesc = "An old core of a cyborg who died in the halls of the Gungeon, forgetting that there are no power outlets here.\n\n" +
                "Maybe if some power runs through it, it could do something.";
            brokenCore.SetupItem(shortDesc, longDesc, "bny");
            brokenCore.AddToSubShop(ItemBuilder.ShopType.Trorc, 1f);
            brokenCore.AddPassiveStatModifier(PlayerStats.StatType.MovementSpeed, 1.05f, StatModifier.ModifyMethod.MULTIPLICATIVE);
            brokenCore.quality = PickupObject.ItemQuality.D;
            List<string> mandatoryConsoleIDs = new List<string>
            {
                "bny:broken_core"
            };
            List<string> optionalConsoleIDs = new List<string>
            {
                "shock_rounds",
                "battery_bullets",
                "shock_rifle",
                "thunderclap"
            };
            CustomSynergies.Add("Overload", mandatoryConsoleIDs, optionalConsoleIDs, true);
        }
        public OnPlayerItemUsedItem()
        {
            this.ActivationChance = 1f;
            this.InternalCooldown = 5f;
            this.m_lastUsedTime = -1000f;
        }

        // Token: 0x06007611 RID: 30225 RVA: 0x002E0AE1 File Offset: 0x002DECE1
        public override void Pickup(PlayerController player)
        {
            if (this.m_pickedUp)
            {
                return;
            }
            base.Pickup(player);
            player.OnUsedPlayerItem += this.DoEffect;
        }

        private void DoEffect(PlayerController usingPlayer, PlayerItem usedItem)
        {
            if (Time.realtimeSinceStartup - this.m_lastUsedTime < this.InternalCooldown)
            {
                return;
            }
            this.m_lastUsedTime = Time.realtimeSinceStartup;
            if (UnityEngine.Random.value < this.ActivationChance)
            {
                bool synergy = base.Owner.PlayerHasActiveSynergy("Overload");
                if (synergy)
                {
                    this.DoTheZzapp(usingPlayer);
                }
                else
                {
                    for (int counter = 0; counter < UnityEngine.Random.Range(2f, 8f); counter++)
                    {
                        Projectile projectile = ((Gun)ETGMod.Databases.Items[13]).DefaultModule.projectiles[0];
                        Vector3 vector = usingPlayer.unadjustedAimPoint - usingPlayer.LockedApproximateSpriteCenter;
                        Vector3 vector2 = usingPlayer.specRigidbody.UnitCenter;
                        GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, usingPlayer.sprite.WorldCenter, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0, 359)));
                        Projectile component = gameObject.GetComponent<Projectile>();
                        HomingModifier homing = component.gameObject.AddComponent<HomingModifier>();
                        homing.HomingRadius = 100;
                        homing.AngularVelocity = 100;
                        BounceProjModifier bouncy = component.gameObject.AddComponent<BounceProjModifier>();
                        bouncy.numberOfBounces = 2;
                        {
                            component.Owner = usingPlayer;
                            component.Shooter = usingPlayer.specRigidbody;
                        }

                    }
                }
                
            }
        }

        private void DoTheZzapp(PlayerController usingPlayer)
        {
            for (int counter = 0; counter < 8; counter++)
            {
                Projectile projectile = ((Gun)ETGMod.Databases.Items[13]).DefaultModule.projectiles[0];
                Vector3 vector = usingPlayer.unadjustedAimPoint - usingPlayer.LockedApproximateSpriteCenter;
                Vector3 vector2 = usingPlayer.specRigidbody.UnitCenter;
                GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, usingPlayer.sprite.WorldCenter, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0, 359)));
                Projectile component = gameObject.GetComponent<Projectile>();
                HomingModifier homing = component.gameObject.AddComponent<HomingModifier>();
                homing.HomingRadius = 120;
                homing.AngularVelocity = 120;
                BounceProjModifier bouncy = component.gameObject.AddComponent<BounceProjModifier>();
                bouncy.numberOfBounces = 3;
                {
                    component.Owner = usingPlayer;
                    component.Shooter = usingPlayer.specRigidbody;
                }

            }

        }

        public override DebrisObject Drop(PlayerController player)
        {
            DebrisObject debrisObject = base.Drop(player);
            OnPlayerItemUsedItem component = debrisObject.GetComponent<OnPlayerItemUsedItem>();
            player.OnUsedPlayerItem -= this.DoEffect;
            component.m_pickedUpThisRun = true;
            return debrisObject;
        }

        // Token: 0x06007614 RID: 30228 RVA: 0x00164985 File Offset: 0x00162B85
        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        // Token: 0x040077C1 RID: 30657
        public float ActivationChance;

        // Token: 0x040077C2 RID: 30658
        public bool TriggersBlank;

        // Token: 0x040077C3 RID: 30659
        public bool TriggersRadialBulletBurst;

        // Token: 0x040077C4 RID: 30660
        [ShowInInspectorIf("TriggersRadialBulletBurst", false)]
        public RadialBurstInterface RadialBurstSettings;

        // Token: 0x040077C5 RID: 30661
        public float InternalCooldown;

        // Token: 0x040077C6 RID: 30662
        private float m_lastUsedTime;
    }
}

namespace BunnyMod
{
    public class TestActiveItem : PlayerItem
    {
        public static void Init()
        {
            string itemName = "Test Active Item";
            string resourceName = "ExampleMod/Resources/speckofdust";
            GameObject obj = new GameObject(itemName);
            TestActiveItem testActive = obj.AddComponent<TestActiveItem>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Used for testing";
            string longDesc = "Test Active For Testing 'On Active' Items.";
            testActive.SetupItem(shortDesc, longDesc, "bny");
            testActive.SetCooldownType(ItemBuilder.CooldownType.Timed, 5f);
            testActive.consumable = false;
            testActive.quality = PickupObject.ItemQuality.EXCLUDED;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }

        protected override void DoEffect(PlayerController user)
        {

        }
    }
}




namespace BunnyMod
{
    public class FreezeLighter : PlayerItem
    {
        public float Random { get; private set; }
        public object FreezeModifierEffect { get; private set; }

        public static void Init()
        {
            string itemName = "Ibzans Lighter";
            string resourceName = "ExampleMod/Resources/ibzanslighter";
            GameObject obj = new GameObject(itemName);
            var item = obj.AddComponent<FreezeLighter>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Ashes to Ashes, to Ashes";
            string longDesc = "The lighter of Ibzan, the first employed by the Flames. The remainder of his life was cold and miserable, lacking companionship the Flames did not grant.";
            ItemBuilder.SetupItem(item, shortDesc, longDesc, "bny");
            ItemBuilder.SetCooldownType(item, ItemBuilder.CooldownType.Damage, 650);
            item.consumable = false;
            item.quality = PickupObject.ItemQuality.B;
            List<string> mandatoryConsoleIDs = new List<string>
            {
                "bny:ibzans_lighter"
            };
            List<string> optionalConsoleIDs = new List<string>
            {
                "hot_lead",
                "copper_ammolet",
                "flame_hand",
                "dragunfire",
                "pitchfork"
            };
            CustomSynergies.Add("The Flames' Embrace", mandatoryConsoleIDs, optionalConsoleIDs, true);
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }
        protected override void DoEffect(PlayerController user)
        {
            List<AIActor> activeEnemies = base.LastOwner.CurrentRoom.GetActiveEnemies(RoomHandler.ActiveEnemyType.All);
            if (activeEnemies != null)
            {
                AkSoundEngine.PostEvent("Play_OBJ_lock_unlock_01", base.gameObject);
                BulletStatusEffectItem Freezecomponent = PickupObjectDatabase.GetById(278).GetComponent<BulletStatusEffectItem>();
                GameActorFreezeEffect freezeModifierEffect = Freezecomponent.FreezeModifierEffect;
                int count = activeEnemies.Count;
                for (int i = 0; i < count; i++)
                {
                    if (activeEnemies[i] && activeEnemies[i].HasBeenEngaged && activeEnemies[i].healthHaver && activeEnemies[i].IsNormalEnemy && !activeEnemies[i].healthHaver.IsDead && !activeEnemies[i].healthHaver.IsBoss && !activeEnemies[i].IsTransmogrified)
                    {
                        activeEnemies[i].ApplyEffect(freezeModifierEffect, 10f, null);
                    }
                }
                bool synergy = user.PlayerHasActiveSynergy("The Flames' Embrace");
                if (synergy)
                {
                    BulletStatusEffectItem Firecomponent = PickupObjectDatabase.GetById(295).GetComponent<BulletStatusEffectItem>();
                    GameActorFireEffect gameActorFire = Firecomponent.FireModifierEffect;
                    int count1 = activeEnemies.Count;
                    for (int i = 0; i < count1; i++)
                    {
                        if (activeEnemies[i] && activeEnemies[i].HasBeenEngaged && activeEnemies[i].healthHaver && activeEnemies[i].IsNormalEnemy && !activeEnemies[i].healthHaver.IsDead && !activeEnemies[i].healthHaver.IsBoss && !activeEnemies[i].IsTransmogrified)
                        {
                            activeEnemies[i].ApplyEffect(gameActorFire, 10f, null);
                        }
                    }
                }
            }
        }
    }
}


namespace BunnyMod
{
    // Token: 0x02000016 RID: 22
    internal class MatrixPotion : PlayerItem
    {
        // Token: 0x06000085 RID: 133 RVA: 0x00005A10 File Offset: 0x00003C10
        public static void Init()
        {
            string name = "Potion of Projectile Slowness";
            string resourcePath = "ExampleMod/Resources/potionofmatrixstyle";
            GameObject gameObject = new GameObject(name);
            MatrixPotion matrixPotion = gameObject.AddComponent<MatrixPotion>();
            ItemBuilder.AddSpriteToObject(name, resourcePath, gameObject);
            string shortDesc = "SSllooww mmoottiioonn..";
            string longDesc = "This unique mix makes projectiles incredibly slow, for game mechanic reasons.";
            matrixPotion.SetupItem(shortDesc, longDesc, "bny");
            matrixPotion.SetCooldownType(ItemBuilder.CooldownType.Damage, 1200f);
            matrixPotion.consumable = false;
            matrixPotion.quality = PickupObject.ItemQuality.A;
        }

        // Token: 0x06000086 RID: 134 RVA: 0x00005A7A File Offset: 0x00003C7A
        protected override void DoEffect(PlayerController user)
        {
            AkSoundEngine.PostEvent("Play_OBJ_power_up_01", base.gameObject);
            this.StartEffect(user);
            base.StartCoroutine(ItemBuilder.HandleDuration(this, this.duration, user, new Action<PlayerController>(this.EndEffect)));
        }

        // Token: 0x06000087 RID: 135 RVA: 0x00005AB8 File Offset: 0x00003CB8
        private void StartEffect(PlayerController user)
        {
            float amount = .5f;
            this.slowmod = this.AddPassiveStatModifier(PlayerStats.StatType.EnemyProjectileSpeedMultiplier, amount, StatModifier.ModifyMethod.MULTIPLICATIVE);
            user.stats.RecalculateStats(user, true, true);
        }

        // Token: 0x06000088 RID: 136 RVA: 0x00005AEC File Offset: 0x00003CEC
        private void EndEffect(PlayerController user)
        {
            bool flag = this.slowmod == null;
            if (!flag)
            {
                this.RemovePassiveStatModifier(this.slowmod);
                user.stats.RecalculateStats(user, true, true);
            }
        }

        // Token: 0x06000089 RID: 137 RVA: 0x00005B25 File Offset: 0x00003D25
        protected override void OnPreDrop(PlayerController user)
        {
            base.OnPreDrop(user);
            this.EndEffect(user);
        }

        // Token: 0x0600008A RID: 138 RVA: 0x00005B38 File Offset: 0x00003D38
        public override bool CanBeUsed(PlayerController user)
        {
            return base.CanBeUsed(user);
        }

        // Token: 0x0400001A RID: 26
        private float duration = 15f;

        // Token: 0x0400001B RID: 27
        private StatModifier slowmod;
    }
}








