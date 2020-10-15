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
    public class BloodyTrigger : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Bloody Trigger";
            string resourceName = "BunnyMod/Resources/bloodytrigger";
            GameObject obj = new GameObject(itemName);
            BloodyTrigger bloodyTrigger = obj.AddComponent<BloodyTrigger>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Bloodlust";
            string longDesc = "Shoot! Shoot! Shoot! Shoot! Shoot! Shoot! Shoot! Shoot! Shoot! Shoot! Shoot! Shoot! Shoot! Shoot! Shoot! Shoot! ";
            bloodyTrigger.SetupItem(shortDesc, longDesc, "bny");
            bloodyTrigger.quality = PickupObject.ItemQuality.A;
            bloodyTrigger.AddToSubShop(ItemBuilder.ShopType.Trorc, 1f);
            bloodyTrigger.AddToSubShop(ItemBuilder.ShopType.Cursula, 1f);
            List<string> mandatoryConsoleIDs2 = new List<string>
            {
                "bny:bloody_trigger",
                "lichy_trigger_finger"
            };
            CustomSynergies.Add("So it benefits you...", mandatoryConsoleIDs2, null, true);
        }
        private void HandleTriedAttack(PlayerController obj)
        {
            bool flag1 = base.Owner.HasPickupID(213);
            if (flag1)
            {
                GameManager.Instance.StartCoroutine(BloodLustPOWERED());
            }
            else
            {
                GameManager.Instance.StartCoroutine(BloodLust());
            }
        }
        private IEnumerator BloodLust()
        {
            this.AddStat(PlayerStats.StatType.Damage, 0.05f, StatModifier.ModifyMethod.ADDITIVE);
            base.Owner.stats.RecalculateStats(base.Owner, true, true);
            yield return new WaitForSeconds(0.125f);
            {
                this.AddStat(PlayerStats.StatType.Damage, -0.05f, StatModifier.ModifyMethod.ADDITIVE);
                base.Owner.stats.RecalculateStats(base.Owner, true, true);
            }
            yield break;
        }
        private IEnumerator BloodLustPOWERED()
        {
            this.AddStat(PlayerStats.StatType.Damage, 0.1f, StatModifier.ModifyMethod.ADDITIVE);
            this.AddStat(PlayerStats.StatType.Accuracy, -0.15f, StatModifier.ModifyMethod.ADDITIVE);
            base.Owner.stats.RecalculateStats(base.Owner, true, true);
            yield return new WaitForSeconds(0.166f);
            {
                this.AddStat(PlayerStats.StatType.Damage, -0.1f, StatModifier.ModifyMethod.ADDITIVE);
                this.AddStat(PlayerStats.StatType.Accuracy, 0.15f, StatModifier.ModifyMethod.ADDITIVE);
                base.Owner.stats.RecalculateStats(base.Owner, true, true);
            }
            yield break;
        }
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
            player.OnTriedToInitiateAttack += this.HandleTriedAttack;
        }
        public override DebrisObject Drop(PlayerController player)
        {
            player.OnTriedToInitiateAttack -= this.HandleTriedAttack;
            return base.Drop(player);
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
    }
}