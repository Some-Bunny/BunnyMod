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
    public class SoulInAJar : PlayerItem
    {

        public static void Init()
        {
            string itemName = "Soul In A Jar";
            string resourceName = "ExampleMod/Resources/soulinajar";
            GameObject obj = new GameObject(itemName);
            SoulInAJar lockpicker = obj.AddComponent<SoulInAJar>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Little Fella'";
            string longDesc = "A tiny little gunslinger soul in a jar. Fly my pretty!";
            lockpicker.SetupItem(shortDesc, longDesc, "bny");
            lockpicker.SetCooldownType(ItemBuilder.CooldownType.Damage, 250f);
            lockpicker.consumable = false;
            lockpicker.quality = PickupObject.ItemQuality.D;
            lockpicker.AddToSubShop(ItemBuilder.ShopType.Cursula, 1f);
            lockpicker.AddToSubShop(ItemBuilder.ShopType.Goopton, 1f);
            List<string> mandatoryConsoleIDs1 = new List<string>
            {
                "bny:soul_in_a_jar"
            };
            List<string> optionalConsoleID1s = new List<string>
            {
                "shotgun_full_of_hate",
                "ghost_bullets",
                "skull_spitter",
                "bullet_idol",
                "clear_guon_stone",
                "gun_soul",
                "sixth_chamber",
                "cursed_bullets"

            };
            CustomSynergies.Add("Go! Go! Go!", mandatoryConsoleIDs1, optionalConsoleID1s, true);
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }

        protected override void DoEffect(PlayerController user)
        {
            bool flag1 = user.HasPickupID(143);
            bool flag2 = user.HasPickupID(172);
            bool flag3 = user.HasPickupID(45);
            bool flag4 = user.HasPickupID(434);
            bool flag5 = user.HasPickupID(264);
            bool flag6 = user.HasPickupID(489);
            bool flag7 = user.HasPickupID(407);
            bool flag8 = user.HasPickupID(571);
            if (flag1)
            {
                for (int counter = 0; counter < 3; counter++)
                {
                    Projectile projectile = ((Gun)ETGMod.Databases.Items[198]).DefaultModule.projectiles[0];
                    Vector3 vector = user.unadjustedAimPoint - user.LockedApproximateSpriteCenter;
                    Vector3 vector2 = user.specRigidbody.UnitCenter;
                    GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, user.sprite.WorldCenter, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-25, 25)));
                    Projectile component = gameObject.GetComponent<Projectile>();
                    component.baseData.range = 50f;

                    {
                        component.Owner = user;
                        component.Shooter = user.specRigidbody;
                    }
                }

            }
            else
            if (flag2)
            {
                for (int counter = 0; counter < 3; counter++)
                {
                    Projectile projectile = ((Gun)ETGMod.Databases.Items[198]).DefaultModule.projectiles[0];
                    Vector3 vector = user.unadjustedAimPoint - user.LockedApproximateSpriteCenter;
                    Vector3 vector2 = user.specRigidbody.UnitCenter;
                    GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, user.sprite.WorldCenter, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-25, 25)));
                    Projectile component = gameObject.GetComponent<Projectile>();
                    component.baseData.range = 50f;

                    {
                        component.Owner = user;
                        component.Shooter = user.specRigidbody;
                    }
                }
            }
            else
            if (flag3)
            {
                for (int counter = 0; counter < 3; counter++)
                {
                    Projectile projectile = ((Gun)ETGMod.Databases.Items[198]).DefaultModule.projectiles[0];
                    Vector3 vector = user.unadjustedAimPoint - user.LockedApproximateSpriteCenter;
                    Vector3 vector2 = user.specRigidbody.UnitCenter;
                    GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, user.sprite.WorldCenter, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-25, 25)));
                    Projectile component = gameObject.GetComponent<Projectile>();
                    component.baseData.range = 50f;

                    {
                        component.Owner = user;
                        component.Shooter = user.specRigidbody;
                    }
                }
            }
            if (flag4)
            {
                for (int counter = 0; counter < 3; counter++)
                {
                    Projectile projectile = ((Gun)ETGMod.Databases.Items[198]).DefaultModule.projectiles[0];
                    Vector3 vector = user.unadjustedAimPoint - user.LockedApproximateSpriteCenter;
                    Vector3 vector2 = user.specRigidbody.UnitCenter;
                    GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, user.sprite.WorldCenter, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-25, 25)));
                    Projectile component = gameObject.GetComponent<Projectile>();
                    component.baseData.range = 50f;

                    {
                        component.Owner = user;
                        component.Shooter = user.specRigidbody;
                    }
                }
            }
            else
            if (flag5)
            {
                for (int counter = 0; counter < 3; counter++)
                {
                    Projectile projectile = ((Gun)ETGMod.Databases.Items[198]).DefaultModule.projectiles[0];
                    Vector3 vector = user.unadjustedAimPoint - user.LockedApproximateSpriteCenter;
                    Vector3 vector2 = user.specRigidbody.UnitCenter;
                    GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, user.sprite.WorldCenter, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-25, 25)));
                    Projectile component = gameObject.GetComponent<Projectile>();
                    component.baseData.range = 50f;

                    {
                        component.Owner = user;
                        component.Shooter = user.specRigidbody;
                    }
                }

            }
            else
            if (flag6)
            {
                for (int counter = 0; counter < 3; counter++)
                {
                    Projectile projectile = ((Gun)ETGMod.Databases.Items[198]).DefaultModule.projectiles[0];
                    Vector3 vector = user.unadjustedAimPoint - user.LockedApproximateSpriteCenter;
                    Vector3 vector2 = user.specRigidbody.UnitCenter;
                    GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, user.sprite.WorldCenter, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-25, 25)));
                    Projectile component = gameObject.GetComponent<Projectile>();
                    component.baseData.range = 50f;

                    {
                        component.Owner = user;
                        component.Shooter = user.specRigidbody;
                    }
                }
            }
            else
            if (flag7)
            {
                for (int counter = 0; counter < 3; counter++)
                {
                    Projectile projectile = ((Gun)ETGMod.Databases.Items[198]).DefaultModule.projectiles[0];
                    Vector3 vector = user.unadjustedAimPoint - user.LockedApproximateSpriteCenter;
                    Vector3 vector2 = user.specRigidbody.UnitCenter;
                    GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, user.sprite.WorldCenter, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-25, 25)));
                    Projectile component = gameObject.GetComponent<Projectile>();
                    component.baseData.range = 50f;

                    {
                        component.Owner = user;
                        component.Shooter = user.specRigidbody;
                    }
                }
            }
            if (flag8)
            {
                for (int counter = 0; counter < 3; counter++)
                {
                    Projectile projectile = ((Gun)ETGMod.Databases.Items[198]).DefaultModule.projectiles[0];
                    Vector3 vector = user.unadjustedAimPoint - user.LockedApproximateSpriteCenter;
                    Vector3 vector2 = user.specRigidbody.UnitCenter;
                    GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, user.sprite.WorldCenter, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-25, 25)));
                    Projectile component = gameObject.GetComponent<Projectile>();
                    component.baseData.range = 50f;

                    {
                        component.Owner = user;
                        component.Shooter = user.specRigidbody;
                    }
                }
            }
            else
            {
                Projectile projectile = ((Gun)ETGMod.Databases.Items[198]).DefaultModule.projectiles[0];
                Vector3 vector = user.unadjustedAimPoint - user.LockedApproximateSpriteCenter;
                Vector3 vector2 = user.specRigidbody.UnitCenter;
                GameObject gameObject = SpawnManager.SpawnProjectile(projectile.gameObject, user.sprite.WorldCenter, Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(-25, 25)));
                Projectile component = gameObject.GetComponent<Projectile>();
                component.baseData.range = 50f;

                {
                    component.Owner = user;
                    component.Shooter = user.specRigidbody;
                }
            }
        }
    }
}



