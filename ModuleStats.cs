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
    public class ModuleDamage : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Damage Module";
            string resourceName = "ExampleMod/Resources/WeaponModules/weaponmodulardamage.png";
            GameObject obj = new GameObject(itemName);
            ModuleDamage Module = obj.AddComponent<ModuleDamage>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Damage Up.";
            string longDesc = "Increases damage by 50%";
            Module.SetupItem(shortDesc, longDesc, "bny");
            Module.quality = PickupObject.ItemQuality.EXCLUDED;
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.Damage, .50f, StatModifier.ModifyMethod.ADDITIVE);
        }
        public override void Pickup(PlayerController player)
        {
            this.CanBeDropped = false;
            base.Pickup(player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }
    }
}
namespace BunnyMod
{
    public class ModuleClipSize : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Clip Size Module";
            string resourceName = "ExampleMod/Resources/WeaponModules/weaponmodularclipsize.png";
            GameObject obj = new GameObject(itemName);
            ModuleClipSize Module = obj.AddComponent<ModuleClipSize>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Clip Size Up.";
            string longDesc = "Increases clip size by 25%";
            Module.SetupItem(shortDesc, longDesc, "bny");
            Module.quality = PickupObject.ItemQuality.EXCLUDED;
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.AdditionalClipCapacityMultiplier, .25f, StatModifier.ModifyMethod.ADDITIVE);
        }
        public override void Pickup(PlayerController player)
        {
            this.CanBeDropped = false;
            base.Pickup(player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }
    }
}
namespace BunnyMod
{
    public class ModuleFireRate : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Fire Rate Module";
            string resourceName = "ExampleMod/Resources/WeaponModules/weaponmodularfirerate.png";
            GameObject obj = new GameObject(itemName);
            ModuleFireRate Module = obj.AddComponent<ModuleFireRate>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Fire Rate Up.";
            string longDesc = "Increases fire rate by 40%";
            Module.SetupItem(shortDesc, longDesc, "bny");
            Module.quality = PickupObject.ItemQuality.EXCLUDED;
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.RateOfFire, .40f, StatModifier.ModifyMethod.ADDITIVE);
        }
        public override void Pickup(PlayerController player)
        {
            this.CanBeDropped = false;
            base.Pickup(player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }
    }
}
namespace BunnyMod
{
    public class ModuleReload : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Reload Module";
            string resourceName = "ExampleMod/Resources/WeaponModules/weaponmodularreload.png";
            GameObject obj = new GameObject(itemName);
            ModuleReload Module = obj.AddComponent<ModuleReload>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Reload Time Down.";
            string longDesc = "Reduces reload time by 20%";
            Module.SetupItem(shortDesc, longDesc, "bny");
            Module.quality = PickupObject.ItemQuality.EXCLUDED;
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.ReloadSpeed, .80f, StatModifier.ModifyMethod.MULTIPLICATIVE);
        }
        public override void Pickup(PlayerController player)
        {
            this.CanBeDropped = false;
            base.Pickup(player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }
    }
}

namespace BunnyMod
{
    public class T2ModuleYV : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Splitter Module";
            string resourceName = "ExampleMod/Resources/WeaponModules/t2weaponmodularyv.png";
            GameObject obj = new GameObject(itemName);
            T2ModuleYV Module = obj.AddComponent<T2ModuleYV>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Chance for extra.";
            string longDesc = "Gives a chance to fire extra bullets.";
            Module.SetupItem(shortDesc, longDesc, "bny");
            Module.quality = PickupObject.ItemQuality.EXCLUDED;
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.ShadowBulletChance, 5f, StatModifier.ModifyMethod.ADDITIVE);
        }
        public override void Pickup(PlayerController player)
        {
            this.CanBeDropped = false;
            base.Pickup(player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }
    }
}
namespace BunnyMod
{
    public class T2ModulePierce : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Piercer Module";
            string resourceName = "ExampleMod/Resources/WeaponModules/t2weaponmodularpierce.png";
            GameObject obj = new GameObject(itemName);
            T2ModulePierce Module = obj.AddComponent<T2ModulePierce>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Piercing.";
            string longDesc = "Makes projectiles pierce.";
            Module.SetupItem(shortDesc, longDesc, "bny");
            Module.quality = PickupObject.ItemQuality.EXCLUDED;
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.AdditionalShotPiercing, 1f, StatModifier.ModifyMethod.ADDITIVE);
        }
        public override void Pickup(PlayerController player)
        {
            this.CanBeDropped = false;
            base.Pickup(player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }
    }
}
namespace BunnyMod
{
    public class T2ModuleBounce : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Bouncer Module";
            string resourceName = "ExampleMod/Resources/WeaponModules/t2weaponmodularbounce.png";
            GameObject obj = new GameObject(itemName);
            T2ModuleBounce Module = obj.AddComponent<T2ModuleBounce>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Bouncing.";
            string longDesc = "Makes projectiles bounce.";
            Module.SetupItem(shortDesc, longDesc, "bny");
            Module.quality = PickupObject.ItemQuality.EXCLUDED;
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.AdditionalShotBounces, 1f, StatModifier.ModifyMethod.ADDITIVE);
        }
        public override void Pickup(PlayerController player)
        {
            this.CanBeDropped = false;
            base.Pickup(player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }
    }
}

namespace BunnyMod
{
    public class T3ModuleColossus : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Colossus Module";
            string resourceName = "ExampleMod/Resources/WeaponModules/t3weaponmodularmassiveslowdps.png";
            GameObject obj = new GameObject(itemName);
            T3ModuleColossus Module = obj.AddComponent<T3ModuleColossus>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Massive.";
            string longDesc = "Increases damage and size but decreases speed.";
            Module.SetupItem(shortDesc, longDesc, "bny");
            Module.quality = PickupObject.ItemQuality.EXCLUDED;
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.Damage, .25f, StatModifier.ModifyMethod.ADDITIVE);
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.PlayerBulletScale, 4f, StatModifier.ModifyMethod.ADDITIVE);
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.ProjectileSpeed, .5f, StatModifier.ModifyMethod.MULTIPLICATIVE);
        }
        public override void Pickup(PlayerController player)
        {
            this.CanBeDropped = false;
            base.Pickup(player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }
    }
}
namespace BunnyMod
{
    public class T3ModuleRocket : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Rocket Module";
            string resourceName = "ExampleMod/Resources/WeaponModules/t3weaponmodularrocket.png";
            GameObject obj = new GameObject(itemName);
            T3ModuleRocket Module = obj.AddComponent<T3ModuleRocket>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Velocity.";
            string longDesc = "Increases bullet speed and knockback. Slightly increases fire rate.";
            Module.SetupItem(shortDesc, longDesc, "bny");
            Module.quality = PickupObject.ItemQuality.EXCLUDED;
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.KnockbackMultiplier, 3f, StatModifier.ModifyMethod.ADDITIVE);
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.ProjectileSpeed, 2f, StatModifier.ModifyMethod.ADDITIVE);
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.RateOfFire, .2f, StatModifier.ModifyMethod.ADDITIVE);
        }
        public override void Pickup(PlayerController player)
        {
            this.CanBeDropped = false;
            base.Pickup(player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }
    }
}
namespace BunnyMod
{
    public class T3ModuleInaccurate : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Inaccurate Module";
            string resourceName = "ExampleMod/Resources/WeaponModules/t3weaponmodularinaccuratebutdps.png";
            GameObject obj = new GameObject(itemName);
            T3ModuleInaccurate Module = obj.AddComponent<T3ModuleInaccurate>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Tradeoff.";
            string longDesc = "Greatly increases damage. Decreases accuracy.";
            Module.SetupItem(shortDesc, longDesc, "bny");
            Module.quality = PickupObject.ItemQuality.EXCLUDED;
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.Damage, .75f, StatModifier.ModifyMethod.ADDITIVE);
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.DamageToBosses, .25f, StatModifier.ModifyMethod.ADDITIVE);
            ItemBuilder.AddPassiveStatModifier(Module, PlayerStats.StatType.Accuracy, 2.5f, StatModifier.ModifyMethod.ADDITIVE);
        }
        public override void Pickup(PlayerController player)
        {
            this.CanBeDropped = false;
            base.Pickup(player);
        }
        public override DebrisObject Drop(PlayerController player)
        {
            return base.Drop(player);
        }
    }
}