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
	public class MithrixHammer : GunBehaviour
	{
		// Token: 0x0600013F RID: 319 RVA: 0x0000D468 File Offset: 0x0000B668
		public static void Add()
		{
			Gun gun = ETGMod.Databases.Items.NewGun("Hammer Of The Moon", "lunarhammer");
			Game.Items.Rename("outdated_gun_mods:hammer_of_the_moon", "bny:hammer_of_the_moon");
			gun.gameObject.AddComponent<MithrixHammer>();
			GunExt.SetShortDescription(gun, "Commencement");
			GunExt.SetLongDescription(gun, "You're Gonna Need A Bigger Hammer.");
			GunExt.SetupSprite(gun, null, "lunarhammer_idle_001", 8);
			GunExt.SetAnimationFPS(gun, gun.shootAnimation, 20);
			GunExt.SetAnimationFPS(gun, gun.reloadAnimation, 3);
			GunExt.SetAnimationFPS(gun, gun.chargeAnimation, 7);
			GunExt.AddProjectileModuleFrom(gun, PickupObjectDatabase.GetById(481) as Gun, true, false);
			gun.DefaultModule.ammoCost = 1;
			gun.DefaultModule.shootStyle = ProjectileModule.ShootStyle.Charged;
			gun.DefaultModule.sequenceStyle = ProjectileModule.ProjectileSequenceStyle.Random;
			gun.reloadTime = 3.5f;
			gun.DefaultModule.cooldownTime = 1f;
			gun.carryPixelOffset += new IntVector2((int)-2f, (int)0f);
			gun.DefaultModule.numberOfShotsInClip = 1;
			gun.DefaultModule.preventFiringDuringCharge = true;
			gun.SetBaseMaxAmmo(40);
			gun.InfiniteAmmo = true;
			gun.quality = PickupObject.ItemQuality.S;
			gun.encounterTrackable.EncounterGuid = "The Big Ukulele";
			ProjectileModule.ChargeProjectile item = new ProjectileModule.ChargeProjectile();
			gun.DefaultModule.chargeProjectiles = new List<ProjectileModule.ChargeProjectile>
			{
				item
			};
			gun.DefaultModule.chargeProjectiles[0].ChargeTime = 1.25f;
			gun.DefaultModule.chargeProjectiles[0].UsedProperties = ((Gun)ETGMod.Databases.Items[481]).DefaultModule.chargeProjectiles[0].UsedProperties;
			gun.DefaultModule.chargeProjectiles[0].VfxPool = ((Gun)ETGMod.Databases.Items[481]).DefaultModule.chargeProjectiles[0].VfxPool;
			gun.DefaultModule.chargeProjectiles[0].VfxPool.type = ((Gun)ETGMod.Databases.Items[481]).DefaultModule.chargeProjectiles[0].VfxPool.type;
			MithRixOnReloadModifier mithRixOnReloadModifier = gun.gameObject.AddComponent<MithRixOnReloadModifier>();
			ProjectileModule.ChargeProjectile chargeProjectile = gun.DefaultModule.chargeProjectiles[0];
			Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(((Gun)ETGMod.Databases.Items[481]).DefaultModule.chargeProjectiles[0].Projectile);
			chargeProjectile.Projectile = projectile;
			projectile.gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(projectile.gameObject);
			UnityEngine.Object.DontDestroyOnLoad(projectile);
			gun.DefaultModule.projectiles[0] = projectile;
			gun.GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.chargeAnimation).wrapMode = tk2dSpriteAnimationClip.WrapMode.LoopSection;
			gun.GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.chargeAnimation).loopStart = 5;
			projectile.transform.parent = gun.barrelOffset;
			projectile.baseData.damage = 0f;
			projectile.baseData.range = 0f;
			projectile.baseData.force = 350f;
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
			projectile.baseData.range = 0f;
			this.Blam(projectile.sprite.WorldCenter);
		}

		public void Blam(Vector3 position)
		{
			AkSoundEngine.PostEvent("Play_OBJ_nuke_blast_01", gameObject);
			ExplosionData defaultSmallExplosionData2 = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData;
			this.smallPlayerSafeExplosion.effect = defaultSmallExplosionData2.effect;
			this.smallPlayerSafeExplosion.ignoreList = defaultSmallExplosionData2.ignoreList;
			this.smallPlayerSafeExplosion.ss = defaultSmallExplosionData2.ss;
			Exploder.Explode(position, this.smallPlayerSafeExplosion, Vector2.zero, null, false, CoreDamageTypes.None, false);
		}
		private ExplosionData smallPlayerSafeExplosion = new ExplosionData
		{
			damageRadius = 10f,
			damageToPlayer = 0f,
			doDamage = true,
			damage = 40f,
			doExplosionRing = false,
			doDestroyProjectiles = false,
			doForce = true,
			debrisForce = 100f,
			preventPlayerForce = true,
			explosionDelay = 0f,
			usesComprehensiveDelay = false,
			doScreenShake = true,
			playDefaultSFX = false,
		};
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
