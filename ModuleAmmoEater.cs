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
    public class ModuleAmmoEater : PlayerItem
    {

        public static void Init()
        {
            string itemName = "Modular Ammo Converter";
            string resourceName = "ExampleMod/Resources/weaponmodularammoeater.png";
            GameObject obj = new GameObject(itemName);
            ModuleAmmoEater lockpicker = obj.AddComponent<ModuleAmmoEater>();
            ItemBuilder.AddSpriteToObject(itemName, resourceName, obj);
            string shortDesc = "Convert into Upgrades.";
            string longDesc = "A surprisingly small machine that prints modular upgrades from ammunition.";
            lockpicker.SetupItem(shortDesc, longDesc, "bny");
            lockpicker.SetCooldownType(ItemBuilder.CooldownType.Timed, 0f);
			lockpicker.AddPassiveStatModifier(PlayerStats.StatType.AdditionalItemCapacity, 1f, StatModifier.ModifyMethod.ADDITIVE);
			lockpicker.consumable = false;
            lockpicker.quality = PickupObject.ItemQuality.EXCLUDED;
			ModuleAmmoEater.spriteIDs = new int[ModuleAmmoEater.spritePaths.Length];
			ModuleAmmoEater.spriteIDs[0] = SpriteBuilder.AddSpriteToCollection(ModuleAmmoEater.spritePaths[0], lockpicker.sprite.Collection);
			ModuleAmmoEater.spriteIDs[1] = SpriteBuilder.AddSpriteToCollection(ModuleAmmoEater.spritePaths[1], lockpicker.sprite.Collection);
		}
        public override void Pickup(PlayerController player)
        {
            base.Pickup(player);
        }
		public override void Update()
		{
			PlayerController lastOwner = this.LastOwner;
			bool flag = lastOwner;
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				bool flag4 = this.stacks >= 1;
				if (flag4)
				{
					this.id = ModuleAmmoEater.spriteIDs[1];
				}
				else
				{
					bool flag5 = this.stacks >= 2 && this.stacks <= 1;
					if (flag5)
					{
						this.id = ModuleAmmoEater.spriteIDs[1];
					}
					else
					{
						this.id = ModuleAmmoEater.spriteIDs[0];
					}
				}
				base.sprite.SetSprite(this.id);
			}
		}

		protected override void DoEffect(PlayerController user)
        {
			tk2dSpriteCollectionData tk2dSpriteCollectionData = null;
			int spriteId = -1;
			Vector3 position = Vector3.zero;
			bool flag = this.stacks == 1;
			if (flag)
			{
				this.AddModule();
				base.StartCoroutine(this.RemoveStacks());
			}
			else
			{
				AkSoundEngine.PostEvent("Play_OBJ_blackhole_close_01", base.gameObject);
				this.stacks++;
				bool flag5 = StaticReferenceManager.AllDebris != null;
				if (flag5)
				{
					DebrisObject debrisObject = null;
					float num = float.MaxValue;
					for (int i = 0; i < StaticReferenceManager.AllDebris.Count; i++)
					{
						DebrisObject debrisObject2 = StaticReferenceManager.AllDebris[i];
						bool isPickupObject = debrisObject2.IsPickupObject;
						if (isPickupObject)
						{
							float sqrMagnitude = (user.CenterPosition - debrisObject2.transform.position.XY()).sqrMagnitude;
							bool flag6 = sqrMagnitude <= 15f;
							if (flag6)
							{
								AmmoPickup component2 = debrisObject2.GetComponent<AmmoPickup>();
								bool flag7 = (component2);
								if (flag7)
								{
									float num2 = Mathf.Sqrt(sqrMagnitude);
									bool flag8 = num2 < num && num2 < 5f;
									if (flag8)
									{
										num = num2;
										debrisObject = debrisObject2;
									}
								}
							}
						}
					}
					bool flag9 = debrisObject;
					if (flag9)
					{
						AmmoPickup component6 = debrisObject.GetComponent<AmmoPickup>();
					
						{
							bool flag14 = component6;
							if (flag14)
							{
								bool flag15 = component6.sprite;
								if (flag15)
								{
									tk2dSpriteCollectionData = component6.sprite.Collection;
									spriteId = component6.sprite.spriteId;
									position = component6.transform.position;
								}
								UnityEngine.Object.Destroy(component6.gameObject);
							}
						}
					}
				}
				bool flag20 = tk2dSpriteCollectionData != null;
				if (flag20)
				{
					tk2dSprite targetSprite = tk2dSprite.AddComponent(new GameObject("sucked sprite")
					{
						transform =
						{
							position = position
						}
					}, tk2dSpriteCollectionData, spriteId);
					GameManager.Instance.Dungeon.StartCoroutine(this.HandleSuck(targetSprite));
				}
			}
		}

        public override bool CanBeUsed(PlayerController user)
        {
			bool flag = this.stacks < 1;
			bool result;
			if (flag)
			{
				bool flag2 = !user;
				if (flag2)
				{
					result = false;
				}
				else
				{
					List<DebrisObject> allDebris = StaticReferenceManager.AllDebris;
					bool flag3 = allDebris != null;
					if (flag3)
					{
						for (int i = 0; i < allDebris.Count; i++)
						{
							DebrisObject debrisObject = allDebris[i];
							bool flag4 = debrisObject && debrisObject.IsPickupObject;
							if (flag4)
							{
								float sqrMagnitude = (user.CenterPosition - debrisObject.transform.position.XY()).sqrMagnitude;
								bool flag5 = sqrMagnitude <= 15f;
								if (flag5)
								{
									AmmoPickup component2 = debrisObject.GetComponent<AmmoPickup>();
									bool flag6 = (component2);
									if (flag6)
									{
										float num = Mathf.Sqrt(sqrMagnitude);
										bool flag7 = num < 5f;
										if (flag7)
										{
											return true;
										}
									}
								}
							}
						}
					}
				}
				result = false;
			}
			else
			{
				result = base.CanBeUsed(user);
			}
			return result;
		}

		private IEnumerator HandleSuck(tk2dSprite targetSprite)
		{
			float elapsed = 0f;
			float duration = 0.25f;
			PlayerController owner = this.LastOwner;
			bool flag = targetSprite;
			if (flag)
			{
				Vector3 startPosition = targetSprite.transform.position;
				while (elapsed < duration && owner)
				{
					elapsed += BraveTime.DeltaTime;
					bool flag2 = targetSprite;
					if (flag2)
					{
						targetSprite.transform.localScale = Vector3.Lerp(Vector3.one, new Vector3(0.1f, 0.1f, 0.1f), elapsed / duration);
						targetSprite.transform.position = Vector3.Lerp(startPosition, owner.CenterPosition.ToVector3ZisY(0f), elapsed / duration);
					}
					yield return null;
				}
				startPosition = default(Vector3);
			}
			UnityEngine.Object.Destroy(targetSprite.gameObject);
			yield break;
		}
		private IEnumerator RemoveStacks()
		{
			yield return new WaitForSeconds(0.1f);
			this.stacks -= this.stacks;
			yield break;
		}
		private static int[] spriteIDs;
		public void AddModule()
		{
			PlayerController user = this.LastOwner;
			int num3 = UnityEngine.Random.Range(0, 3);
			bool flag3 = num3 == 0;
			if (flag3)
			{
				LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Colossus Module"].gameObject, user, true);
			}
			bool flag4 = num3 == 1;
			if (flag4)
			{
				LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Rocket Module"].gameObject, user, true);
			}
			bool flag5 = num3 == 2;
			if (flag5)
			{
				LootEngine.TryGivePrefabToPlayer(ETGMod.Databases.Items["Inaccurate Module"].gameObject, user, true);
			}
		}


		// Token: 0x04000087 RID: 135
		private static readonly string[] spritePaths = new string[]
		{
			"ExampleMod/Resources/weaponmodularammoeater.png",
			"ExampleMod/Resources/weaponmodularammoeaterfull.png"
		};
		private int id;

		private int stacks;
	}
}



