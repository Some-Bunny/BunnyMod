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
    public class BunnysFoot : PassiveItem
    {
        private float random;

        public static void Init()
        {
            string itemName = "Bunnys Foot";
            string resourceName = "ExampleMod/Resources/bunnysfoot.png";
            GameObject obj = new GameObject(itemName);
            BunnysFoot counterChamber = obj.AddComponent<BunnysFoot>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Give it back!";
            string longDesc = "The foot of a bunny fitted onto a chain.\n\nUnlike the more common rabbits foot, a bunnys effect on luck is 100x more potent.\n\nI still want it back though.";
            counterChamber.SetupItem(shortDesc, longDesc, "bny");
            counterChamber.AddPassiveStatModifier(PlayerStats.StatType.MoneyMultiplierFromEnemies, 1.25f, StatModifier.ModifyMethod.MULTIPLICATIVE);
            counterChamber.AddPassiveStatModifier(PlayerStats.StatType.ExtremeShadowBulletChance, 5f, StatModifier.ModifyMethod.ADDITIVE);
            counterChamber.AddPassiveStatModifier(PlayerStats.StatType.ShadowBulletChance, 5f, StatModifier.ModifyMethod.ADDITIVE);
            counterChamber.AddPassiveStatModifier(PlayerStats.StatType.Coolness, 3f, StatModifier.ModifyMethod.MULTIPLICATIVE);
            counterChamber.quality = PickupObject.ItemQuality.S;
        }
        private void LuckOTheBunnyShoppe(PlayerController player, ShopItemController shop)
        {
            this.random = UnityEngine.Random.Range(0.00f, 1.00f);
            if (random <= 0.35f)
            {
                int num3 = UnityEngine.Random.Range(0, 5);
                bool flag3 = num3 == 0;
                if (flag3)
                {
                    LootEngine.GivePrefabToPlayer(PickupObjectDatabase.GetById(67).gameObject, player);
                }
                bool flag4 = num3 == 1;
                if (flag4)
                {
                    LootEngine.GivePrefabToPlayer(PickupObjectDatabase.GetById(120).gameObject, player);
                }
                bool aa = num3 == 3;
                if (aa)
                {
                    LootEngine.GivePrefabToPlayer(PickupObjectDatabase.GetById(127).gameObject, player);
                }
                bool snote = num3 == 4;
                if (snote)
                {
                    for (int counter = 0; counter < UnityEngine.Random.Range(7f, 23f); counter++)
                    {
                        LootEngine.GivePrefabToPlayer(PickupObjectDatabase.GetById(68).gameObject, player);
                    }
                }
            }
        }
        public static void LootPlus(Action<Chest, PlayerController> orig, Chest self, PlayerController player)
        {
            orig(self, player);
            {
                {
                    bool flag = player.HasPickupID(Game.Items["bny:bunnys_foot"].PickupObjectId);
                    if (flag)
                    {
                        int numure = UnityEngine.Random.Range(0, 5);
                        bool fuckye = numure == 0 | numure == 1 | numure == 2 | numure == 3;
                        if (fuckye)
                        {
                            int num3 = UnityEngine.Random.Range(0, 3);
                            bool flag3 = num3 == 0;
                            if (flag3)
                            {
                                LootEngine.SpawnItem(PickupObjectDatabase.GetById(224).gameObject, self.specRigidbody.UnitCenter, Vector2.down, .7f, false, true, false);
                            }
                            bool flag4 = num3 == 1;
                            if (flag4)
                            {
                                LootEngine.SpawnItem(PickupObjectDatabase.GetById(67).gameObject, self.specRigidbody.UnitCenter, Vector2.down, .7f, false, true, false);
                            }
                            bool flag6 = num3 == 2;
                            if (flag6)
                            {
                                LootEngine.SpawnItem(PickupObjectDatabase.GetById(78).gameObject, self.specRigidbody.UnitCenter, Vector2.down, .7f, false, true, false);
                            }
                        }
                        bool fuckye1 = numure == 4;
                        if (fuckye1)
                        {
                            GameObject obj = new GameObject();
                            BunnysFoot fuck = obj.AddComponent<BunnysFoot>();
                            int numu1re = UnityEngine.Random.Range(0, 10);
                            bool fuck1ye = numu1re == 0 | numure == 1;
                            if (fuck1ye)
                            {
                                fuck.Spawnquality = (PickupObject.ItemQuality)1;
                                fuck.target = LootEngine.GetItemOfTypeAndQuality<PassiveItem>(fuck.Spawnquality, GameManager.Instance.RewardManager.ItemsLootTable, false);
                                LootEngine.SpawnItem(fuck.target.gameObject, self.specRigidbody.UnitCenter, Vector2.down, .7f, false, true, false);
                            }
                            bool fuck11ye = numu1re == 2 | numure == 3 | numure == 4;
                            if (fuck11ye)
                            {
                                fuck.Spawnquality = (PickupObject.ItemQuality)2;
                                fuck.target = LootEngine.GetItemOfTypeAndQuality<PassiveItem>(fuck.Spawnquality, GameManager.Instance.RewardManager.ItemsLootTable, false);
                                LootEngine.SpawnItem(fuck.target.gameObject, self.specRigidbody.UnitCenter, Vector2.down, .7f, false, true, false);
                            }
                            bool fuck2ye = numu1re == 5 | numure == 6;
                            if (fuck2ye)
                            {
                                fuck.Spawnquality = (PickupObject.ItemQuality)3;
                                fuck.target = LootEngine.GetItemOfTypeAndQuality<PassiveItem>(fuck.Spawnquality, GameManager.Instance.RewardManager.ItemsLootTable, false);
                                LootEngine.SpawnItem(fuck.target.gameObject, self.specRigidbody.UnitCenter, Vector2.down, .7f, false, true, false);
                            }
                            bool fuck12ye = numu1re == 7 | numure == 8;
                            if (fuck12ye)
                            {
                                fuck.Spawnquality = (PickupObject.ItemQuality)4;
                                fuck.target = LootEngine.GetItemOfTypeAndQuality<PassiveItem>(fuck.Spawnquality, GameManager.Instance.RewardManager.ItemsLootTable, false);
                                LootEngine.SpawnItem(fuck.target.gameObject, self.specRigidbody.UnitCenter, Vector2.down, .7f, false, true, false);
                            }
                            bool fuck121ye = numu1re == 9;
                            if (fuck121ye)
                            {
                                fuck.Spawnquality = (PickupObject.ItemQuality)5;
                                fuck.target = LootEngine.GetItemOfTypeAndQuality<PassiveItem>(fuck.Spawnquality, GameManager.Instance.RewardManager.ItemsLootTable, false);
                                LootEngine.SpawnItem(fuck.target.gameObject, self.specRigidbody.UnitCenter, Vector2.down, .7f, false, true, false);
                            }
                        }
                    }
                }
            }
        }

        public override void Pickup(PlayerController player)
        {
            player.OnItemPurchased += this.LuckOTheBunnyShoppe;
            base.Pickup(player);
        }

        public override DebrisObject Drop(PlayerController player)
        {
            player.OnItemPurchased -= this.LuckOTheBunnyShoppe;
            return base.Drop(player);
        }

        public PickupObject.ItemQuality Spawnquality;
        public PassiveItem target;
    }
}