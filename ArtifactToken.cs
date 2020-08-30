using System;
using System.Collections.Generic;
using UnityEngine;
using ItemAPI;

namespace BunnyMod
{
    public class ArtifactToken : PassiveItem
    {
        public static void Init()
        {
            string itemName = "Artifact Token";
            string resourceName = "ExampleMod/Resources/Artifacts/artifactthing";
            GameObject obj = new GameObject(itemName);
            ArtifactToken greandeParasite = obj.AddComponent<ArtifactToken>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "+1 To Artifact.";
            string longDesc = "You're not supposed to see this.";
            greandeParasite.SetupItem(shortDesc, longDesc, "bny");
            greandeParasite.quality = PickupObject.ItemQuality.EXCLUDED;
        }

        public override void Pickup(PlayerController player)
        {
            this.CanBeDropped = false;
            base.Pickup(player);
			ArtifactToken.Char = UnityEngine.Random.Range(1, 11);
			switch (ArtifactToken.Char)
			{
				case 1:
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Attraction"].gameObject, player, true);
					break;
				case 2:
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Revenge"].gameObject, player, true);
					break;
				case 3:
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Glass"].gameObject, player, true);
					break;
				case 4:
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Avarice"].gameObject, player, true);
					break;
				case 5:
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Daze"].gameObject, player, true);
					break;
				case 6:
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Prey"].gameObject, player, true);
					break;
				case 7:
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Megalomania"].gameObject, player, true);
					break;
				case 8:
					LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Fodder"].gameObject, player, true);
					break;
                case 9:
                    LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Bolster"].gameObject, player, true);
                    break;
                case 10:
                    LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Enigma"].gameObject, player, true);
                    break;

            }
            base.Owner.DropPassiveItem(this);
            ArtifactToken.storedPlayer = player;
		}
        public override DebrisObject Drop(PlayerController player)
        {
            DebrisObject debrisObject = base.Drop(player);
            ArtifactToken component = debrisObject.GetComponent<ArtifactToken>();
            component.m_pickedUpThisRun = true;
            component.Break();
            return debrisObject;
        }
        public void Break()
        {
            this.m_pickedUp = true;
            UnityEngine.Object.Destroy(base.gameObject, 1f);
        }
        private static PlayerController storedPlayer;
		public static int Char = 0;
	}
}



