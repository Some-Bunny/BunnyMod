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
    public class Dejammer : PlayerItem
    {

        public static void Init()
        {
            string itemName = "De-Jammer";
            string resourceName = "BunnyMod/Resources/dejammer";
            GameObject obj = new GameObject(itemName);
            Dejammer lockpicker = obj.AddComponent<Dejammer>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "I'll be undamned!";
            string longDesc = "A strange device that purifies enemies. Nothing much to it. Press a button and you're done.";
            lockpicker.SetupItem(shortDesc, longDesc, "bny");
            lockpicker.SetCooldownType(ItemBuilder.CooldownType.PerRoom, 1f);
            lockpicker.consumable = false;
            lockpicker.quality = PickupObject.ItemQuality.C;
            lockpicker.AddToSubShop(ItemBuilder.ShopType.Cursula, 1f);
            lockpicker.AddToSubShop(ItemBuilder.ShopType.Goopton, 1f);
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }

        protected override void DoEffect(PlayerController user)
        {
            AkSoundEngine.PostEvent("Play_WPN_blasterbow_shot_01", gameObject);
            for (int counter = 0; counter < 2; counter++)
            {
                Projectile projectile = ((Gun)ETGMod.Databases.Items[17]).DefaultModule.projectiles[0];
                Vector3 vector = user.unadjustedAimPoint - user.LockedApproximateSpriteCenter;
                Vector3 vector2 = user.specRigidbody.UnitCenter;
                GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, user.sprite.WorldCenter, Quaternion.Euler(0f, 0f, ((user.CurrentGun == null) ? 1.2f : user.CurrentGun.CurrentAngle) + UnityEngine.Random.Range(-45, 45)), true);
                Projectile component = gameObject.GetComponent<Projectile>();
                component.baseData.range = 50f;
                component.baseData.damage = 0f;
                {
                    component.Owner = user;
                    component.Shooter = user.specRigidbody;
                }
            }
        }
    }
}



