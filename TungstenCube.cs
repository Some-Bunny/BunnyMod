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
	// Token: 0x0200002D RID: 45
	public class TungstenCube : GunBehaviour
	{
		// Token: 0x0600013F RID: 319 RVA: 0x0000D468 File Offset: 0x0000B668
		public static void Add()
		{
			Gun gun = ETGMod.Databases.Items.NewGun("Cube Of Tungsten", "tungstencube");
			Game.Items.Rename("outdated_gun_mods:cube_of_tungsten", "bny:cube_of_tungsten");
			gun.gameObject.AddComponent<TungstenCube>();
			GunExt.SetShortDescription(gun, "THE CUBE");
			GunExt.SetLongDescription(gun, "A large cube of tungsten, perfect for chucking at your enemies!");
			GunExt.SetupSprite(gun, null, "tungstencube_idle_001", 8);
			GunExt.SetAnimationFPS(gun, gun.shootAnimation, 20);
			GunExt.SetAnimationFPS(gun, gun.reloadAnimation, 3);
			GunExt.SetAnimationFPS(gun, gun.chargeAnimation, 7);
			GunExt.AddProjectileModuleFrom(gun, PickupObjectDatabase.GetById(8) as Gun, true, false);
			gun.DefaultModule.ammoCost = 1;
			gun.DefaultModule.shootStyle = ProjectileModule.ShootStyle.Charged;
			gun.DefaultModule.sequenceStyle = ProjectileModule.ProjectileSequenceStyle.Random;
			gun.reloadTime = 1.9f;
			gun.DefaultModule.cooldownTime = 1f;
			gun.DefaultModule.numberOfShotsInClip = 1;
			gun.DefaultModule.preventFiringDuringCharge = true;
			gun.SetBaseMaxAmmo(200);
			gun.quality = PickupObject.ItemQuality.C;
			gun.encounterTrackable.EncounterGuid = "THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE THE CUBE ";
			ProjectileModule.ChargeProjectile item = new ProjectileModule.ChargeProjectile();
			gun.DefaultModule.chargeProjectiles = new List<ProjectileModule.ChargeProjectile>
			{
				item
			};
			gun.DefaultModule.chargeProjectiles[0].ChargeTime = 0.9f;
			gun.DefaultModule.chargeProjectiles[0].UsedProperties = ((Gun)ETGMod.Databases.Items[8]).DefaultModule.chargeProjectiles[0].UsedProperties;
			gun.DefaultModule.chargeProjectiles[0].VfxPool = ((Gun)ETGMod.Databases.Items[8]).DefaultModule.chargeProjectiles[0].VfxPool;
			gun.DefaultModule.chargeProjectiles[0].VfxPool.type = ((Gun)ETGMod.Databases.Items[8]).DefaultModule.chargeProjectiles[0].VfxPool.type;
			ProjectileModule.ChargeProjectile chargeProjectile = gun.DefaultModule.chargeProjectiles[0];
			Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(((Gun)ETGMod.Databases.Items[8]).DefaultModule.chargeProjectiles[0].Projectile);
			chargeProjectile.Projectile = projectile;
			projectile.gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(projectile.gameObject);
			UnityEngine.Object.DontDestroyOnLoad(projectile);
			gun.DefaultModule.projectiles[0] = projectile;
			gun.GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.chargeAnimation).wrapMode = tk2dSpriteAnimationClip.WrapMode.LoopSection;
			gun.GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.chargeAnimation).loopStart = 3;
			projectile.transform.parent = gun.barrelOffset;
			projectile.baseData.damage = 30f;
			projectile.baseData.range = 50f;
			projectile.baseData.force = 350f;
			projectile.shouldRotate = true;
			BounceProjModifier bouncy = projectile.gameObject.AddComponent<BounceProjModifier>();
			bouncy.numberOfBounces = 0;
			PierceProjModifier spook = projectile.gameObject.AddComponent<PierceProjModifier>();
			spook.penetration = 1;
			projectile.SetProjectileSpriteRight("tungstencube_projectile_001", 17, 16, true, tk2dBaseSprite.Anchor.MiddleCenter, new int?(11), new int?(5), null, null, null);
			gun.AddToSubShop(ItemBuilder.ShopType.Trorc, 1f);
			gun.AddToSubShop(ItemBuilder.ShopType.Cursula, 1f);
			ETGMod.Databases.Items.Add(gun, null, "ANY");
		}
		protected void Update()
		{
			if (gun.CurrentOwner)
			{

				if (!gun.PreventNormalFireAudio)
				{
					this.gun.PreventNormalFireAudio = true;
				}
				if (!gun.IsReloading && !HasReloaded)
				{
					this.HasReloaded = true;
				}
			}
		}
		private bool HasReloaded;

		public override void OnPostFired(PlayerController player, Gun gun)
		{
			gun.PreventNormalFireAudio = true;
		}
		public override void PostProcessProjectile(Projectile projectile)
		{
			AkSoundEngine.PostEvent("Play_OBJ_item_throw_01", gameObject);
		}


		public override void OnReloadPressed(PlayerController player, Gun gun, bool bSOMETHING)
		{
			if (gun.IsReloading && this.HasReloaded)
			{
				HasReloaded = false;
				AkSoundEngine.PostEvent("Stop_WPN_All", base.gameObject);
				base.OnReloadPressed(player, gun, bSOMETHING);
			}
		}
	}
}
