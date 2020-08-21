﻿using System;
using System.Collections.Generic;
using Gungeon;
using GungeonAPI;
using ItemAPI;
using UnityEngine;

namespace BunnyMod
{
	// Token: 0x0200006A RID: 106
	public class ThunderStorm : AdvancedGunBehavior
	{
		public static void Add()
		{
			Gun gun = ETGMod.Databases.Items.NewGun("Thunder Storm", "thunderstorm");
			Game.Items.Rename("outdated_gun_mods:thunder_storm", "bny:thunder_storm");
			gun.gameObject.AddComponent<ThunderStorm>();
			GunExt.SetShortDescription(gun, "Electric Music");
			GunExt.SetLongDescription(gun, "A master-craft weapon near-paradoxically made by a musician with no prior knowledge of guncraft. The letters 'K-A.F' and 'C.C' are engraved on it's side.");
			GunExt.SetupSprite(gun, null, "thunderstorm_idle_001", 2);
			GunExt.SetAnimationFPS(gun, gun.shootAnimation, 16);
			GunExt.SetAnimationFPS(gun, gun.idleAnimation, 2);
			GunExt.SetAnimationFPS(gun, gun.chargeAnimation, 3);
			GunExt.AddProjectileModuleFrom(gun, PickupObjectDatabase.GetById(390) as Gun, true, false);
			gun.DefaultModule.chargeProjectiles = new List<ProjectileModule.ChargeProjectile>();
			foreach (ProjectileModule.ChargeProjectile chargeProj in (PickupObjectDatabase.GetById(390) as Gun).DefaultModule.chargeProjectiles)
			{
				gun.DefaultModule.chargeProjectiles.Add(new ProjectileModule.ChargeProjectile
				{
					AdditionalWwiseEvent = chargeProj.AdditionalWwiseEvent,
					AmmoCost = chargeProj.AmmoCost = 3,
					ChargeTime = chargeProj.ChargeTime,
					LightIntensity = chargeProj.LightIntensity =.1f,
					MegaReflection = chargeProj.MegaReflection,
					OverrideMuzzleFlashVfxPool = chargeProj.OverrideMuzzleFlashVfxPool,
					OverrideShootAnimation = chargeProj.OverrideShootAnimation,
					previousChargeProjectile = chargeProj.previousChargeProjectile,
					Projectile = chargeProj.Projectile,
					ScreenShake = chargeProj.ScreenShake,
					UsedProperties = chargeProj.UsedProperties,
					VfxPool = chargeProj.VfxPool
				});
			}
			gun.DefaultModule.ammoCost = 1;
			gun.DefaultModule.shootStyle = ProjectileModule.ShootStyle.Charged;
			gun.DefaultModule.sequenceStyle = ProjectileModule.ProjectileSequenceStyle.Random;
			gun.DefaultModule.cooldownTime = 1f;
			gun.DefaultModule.angleVariance = 0f;
			gun.DefaultModule.numberOfShotsInClip = 3;
			gun.DefaultModule.preventFiringDuringCharge = true;
			Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(gun.DefaultModule.projectiles[0]);
			gun.DefaultModule.projectiles[0] = projectile;
			projectile.gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(projectile.gameObject);
			UnityEngine.Object.DontDestroyOnLoad(projectile);
			projectile.baseData.damage *= 2f;
			projectile.AdditionalScaleMultiplier = 1f;
			projectile.baseData.range = 6.25f;
			gun.reloadTime = 1f;
			gun.SetBaseMaxAmmo(90);
			gun.quality = PickupObject.ItemQuality.S;
			gun.GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.chargeAnimation).wrapMode = tk2dSpriteAnimationClip.WrapMode.LoopSection;
			gun.GetComponent<tk2dSpriteAnimator>().GetClipByName(gun.chargeAnimation).loopStart = 1;
			gun.encounterTrackable.EncounterGuid = "jjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj";
			ETGMod.Databases.Items.Add(gun, null, "ANY");
			gun.barrelOffset.transform.localPosition = new Vector3(1.37f, 0.37f, 0f);
			gun.DefaultModule.chargeProjectiles[0].UsedProperties = new ProjectileModule.ChargeProjectileProperties();

		}


		// Token: 0x0600028D RID: 653 RVA: 0x0001666C File Offset: 0x0001486C
		public override void PostProcessProjectile(Projectile projectile)
		{
			projectile.baseData.range = 4f;
			projectile.OnDestruction += this.OhFuckSpapiSawThisMethodRUN;
			projectile.OnPostUpdate += this.HandlePostUpdate;
		}
		private void OhFuckSpapiSawThisMethodRUN(Projectile obj)
		{
			this.Blam(obj.sprite.WorldCenter);
			AkSoundEngine.PostEvent("Play_OBJ_lightning_flash_01", base.gameObject);
			this.ReleaseElectric(obj);
		}

		private void ReleaseElectric(Projectile sourceprojectile)
		{

			for (int counter = 0; counter < 3f; counter++)
			{
				PlayerController playerController = this.gun.CurrentOwner as PlayerController;
				Projectile sourceprojectile1 = ((Gun)ETGMod.Databases.Items[13]).DefaultModule.projectiles[0];
				GameObject gameObject = SpawnManager.SpawnProjectile(sourceprojectile.gameObject, sourceprojectile.sprite.WorldCenter, Quaternion.Euler(0f, 0f, (this.gun == null) ? 0f : (UnityEngine.Random.Range(0f, 359f))), true);
				Projectile component = gameObject.GetComponent<Projectile>();
				bool flag = component != null;
				bool flag2 = flag;
				if (flag2)
				{
					BounceProjModifier bouncy = component.gameObject.AddComponent<BounceProjModifier>();
					bouncy.numberOfBounces = 3;
					component.Shooter = this.gun.CurrentOwner.specRigidbody;
					component.SpawnedFromOtherPlayerProjectile = true;
					component.Shooter = this.gun.CurrentOwner.specRigidbody;
					component.Owner = playerController;
					component.Shooter = playerController.specRigidbody;
					component.baseData.speed = 10f;
					component.baseData.damage = 2f;
					component.AdditionalScaleMultiplier = .5f;
					component.SetOwnerSafe(this.gun.CurrentOwner, "Player");
					component.ignoreDamageCaps = true;
					HomingModifier homing = component.gameObject.AddComponent<HomingModifier>();
					homing.HomingRadius = 45;
					homing.AngularVelocity = 90;
					component.baseData.range = 35f;
				}
			}

		}
		public void Blam(Vector3 position)
		{
			ExplosionData defaultSmallExplosionData2 = GameManager.Instance.Dungeon.sharedSettingsPrefab.DefaultSmallExplosionData;
			this.smallPlayerSafeExplosion.effect = defaultSmallExplosionData2.effect;
			this.smallPlayerSafeExplosion.ignoreList = defaultSmallExplosionData2.ignoreList;
			this.smallPlayerSafeExplosion.ss = defaultSmallExplosionData2.ss;
			Exploder.Explode(position, this.smallPlayerSafeExplosion, Vector2.zero, null, false, CoreDamageTypes.None, false);
		}
		private ExplosionData smallPlayerSafeExplosion = new ExplosionData
		{
			damageRadius = 5f,
			damageToPlayer = 0f,
			doDamage = true,
			damage = 20f,
			doExplosionRing = false,
			doDestroyProjectiles = false,
			doForce = false,
			debrisForce = 0f,
			preventPlayerForce = true,
			explosionDelay = 0f,
			usesComprehensiveDelay = false,
			doScreenShake = false,
			playDefaultSFX = false,
		};
		private void HandlePostUpdate(Projectile projectile)
		{
			bool flag = projectile && projectile.GetElapsedDistance() > 1f;
			if (flag)
			{
				projectile.baseData.speed = 0.85f;
				projectile.RuntimeUpdateScale(1f);
			}
			bool flag1 = projectile && projectile.GetElapsedDistance() > 1.5f;
			if (flag1)
			{
				projectile.baseData.speed = 0.7f;
				projectile.RuntimeUpdateScale(1f);
			}
			bool flag2 = projectile && projectile.GetElapsedDistance() > 2f;
			if (flag2)
			{
				projectile.baseData.speed = 0.55f;
				projectile.RuntimeUpdateScale(1f);
			}
			bool flag3 = projectile && projectile.GetElapsedDistance() > 2.5f;
			if (flag3)
			{
				projectile.baseData.speed = 0.40f;
				projectile.RuntimeUpdateScale(1f);
			}
			bool flag4 = projectile && projectile.GetElapsedDistance() > 3f;
			if (flag4)
			{
				projectile.baseData.speed = 0.25f;
				projectile.RuntimeUpdateScale(1f);
			}
		}

		public float FlashHoldtime;
		public float FlashFadetime;

		// Token: 0x040000DB RID: 219
		public static int ThunderStormID;
	}
}
