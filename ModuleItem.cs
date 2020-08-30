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
using System.Runtime.CompilerServices;

namespace BunnyMod
{
    public class ModuleChip : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Modular Weapon Chip";
            string resourceName = "ExampleMod/Resources/weaponmodular.png";
            GameObject obj = new GameObject(itemName);
            ModuleChip counterChamber = obj.AddComponent<ModuleChip>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Compatible with V1.395";
            string longDesc = "An implant that instantly scraps non-compatible weapons into weapon modules.";
            counterChamber.SetupItem(shortDesc, longDesc, "bny");
            counterChamber.quality = PickupObject.ItemQuality.EXCLUDED;
            ModuleGunID = ModuleChip.ModuleGun.PickupObjectId;
        }
        protected override void Update()
        {
            Gun currentGun = base.Owner.CurrentGun;
            PickupObject.ItemQuality quality = currentGun.quality;
            this.CurrentGuns = 1;
            this.LastGuns = 2;
            base.Owner.inventory.AllGuns.Count();
            {
                bool flag2 = CurrentGuns != this.LastGuns;
                bool flag3 = flag2;
                if (flag3)
                {
                    if (this.m_owner.CurrentGun.PickupObjectId != ModuleGunID)
                    {
                        bool flagh = currentGun.quality == PickupObject.ItemQuality.D;
                        if (flagh)
                        {
                            this.StripGun();
                            this.AddModule();
                        }
                        else
                        {
                            bool flage = currentGun.quality == PickupObject.ItemQuality.C;
                            if (flage)
                            {
                                this.StripGun();
                                this.AddModule();
                            }
                            else
                            {
                                bool flagt = currentGun.quality == PickupObject.ItemQuality.B;
                                if (flagt)
                                {
                                    this.StripGun();
                                    this.AddModule();
                                    this.AddT2Module();
                                }
                                else
                                {
                                    bool flagi = currentGun.quality == PickupObject.ItemQuality.A;
                                    if (flagi)
                                    {
                                        this.StripGun();
                                        this.AddModule();
                                        this.AddT2Module();
                                    }
                                    else
                                    {
                                        bool flag6 = currentGun.quality == PickupObject.ItemQuality.S;
                                        if (flag6)
                                        {
                                            this.StripGun();
                                            this.AddModule();
                                            this.AddModule();
                                            this.AddT2Module();
                                        }
                                        else
                                        {
                                            this.StripGun();
                                            this.AddModule();
                                        }
                                    }
                                }
                            }
                        }
                    }    
                }
            }
        }

        private void StripGun()
        {
            ModuleChip.StripPlayer(base.Owner);
            base.Owner.inventory.AddGunToInventory(ModuleChip.ModuleGun, true);
        }
        public void AddModule()
        {
            int num3 = UnityEngine.Random.Range(0, 4);
            bool flag3 = num3 == 0;
            if (flag3)
            {
                LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Damage Module"].gameObject, base.Owner, true);
            }
            bool flag4 = num3 == 1;
            if (flag4)
            {
                LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Clip Size Module"].gameObject, base.Owner, true);
            }
            bool flag5 = num3 == 2;
            if (flag5)
            {
                LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Reload Module"].gameObject, base.Owner, true);
            }
            bool flag6 = num3 == 3;
            if (flag6)
            {
                LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Fire Rate Module"].gameObject, base.Owner, true);
            }
        }
        public void AddT2Module()
        {
            int num3 = UnityEngine.Random.Range(0, 3);
            bool flag3 = num3 == 0;
            if (flag3)
            {
                LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Bouncer Module"].gameObject, base.Owner, true);
            }
            bool flag4 = num3 == 1;
            if (flag4)
            {
                LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Piercer Module"].gameObject, base.Owner, true);
            }
            bool flag5 = num3 == 2;
            if (flag5)
            {
                LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Splitter Module"].gameObject, base.Owner, true);
            }
        }
        public static void StripPlayer(PlayerController player)
        {
            bool flag = player.inventory != null;
            bool flag2 = flag;
            if (flag2)
            {
                player.inventory.DestroyAllGuns();
            }
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
        public static int ModuleGunID;
        public static Gun ModuleGun = Game.Items["bny:modular_cannon"] as Gun;
        public Gun currentHeldGun;
        public int CurrentGuns;
        public int LastGuns;
	}
}