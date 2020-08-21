using System;
using System.Collections.Generic;
using UnityEngine;
using ItemAPI;

namespace BunnyMod
{
    public class Deicide : PassiveItem
    {

        public static void Init()
        {
            string itemName = "Deicide";
            string resourceName = "ExampleMod/Resources/Artifacts/artifactthing";
            GameObject obj = new GameObject(itemName);
            Deicide greandeParasite = obj.AddComponent<Deicide>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Hell.";
            string longDesc = "You're not supposed to see this.";
            greandeParasite.SetupItem(shortDesc, longDesc, "bny");
            greandeParasite.quality = PickupObject.ItemQuality.EXCLUDED;
        }

        public override void Pickup(PlayerController player)
        {
			{
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Attraction"].gameObject, player, true);
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Revenge"].gameObject, player, true);
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Glass"].gameObject, player, true);
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Avarice"].gameObject, player, true);
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Daze"].gameObject, player, true);
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Prey"].gameObject, player, true);
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Megalomania"].gameObject, player, true);
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Fodder"].gameObject, player, true);
                    LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Bolster"].gameObject, player, true);

            }
            base.Owner.DropPassiveItem(this);
		}
        public override DebrisObject Drop(PlayerController player)
        {
            DebrisObject debrisObject = base.Drop(player);
            Deicide component = debrisObject.GetComponent<Deicide>();
            component.m_pickedUpThisRun = true;
            component.Break();
            return debrisObject;
        }
        public void Break()
        {
            this.m_pickedUp = true;
            UnityEngine.Object.Destroy(base.gameObject, 1f);
        }
		public static int Char = 0;
	}
}



