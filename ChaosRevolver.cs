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
	public class ChaosRevolver : GunBehaviour
	{
		// Token: 0x06000036 RID: 54 RVA: 0x000037D8 File Offset: 0x000019D8
		public static void Add()
		{
			Gun chaosgun = ETGMod.Databases.Items.NewGun("Chaos Revolver", "chaosrevolver");
			Game.Items.Rename("outdated_gun_mods:chaos_revolver", "bny:chaos_revolver");
			chaosgun.gameObject.AddComponent<ChaosRevolver>();
			GunExt.SetShortDescription(chaosgun, "Predictable Gun");
			GunExt.SetLongDescription(chaosgun, "A legendary gun that was sealed away because it was thought to speak ancient secrets, when in reality the Chamber was.\n\nWhile the gun was sealed away, the Chamber managed to escape, leaving the innocent weapon behind. You are lucky to resurface it.");
			GunExt.SetupSprite(chaosgun, null, "chaosrevolver_idle_001", 25);
			GunExt.SetAnimationFPS(chaosgun, chaosgun.shootAnimation, 14);
			GunExt.SetAnimationFPS(chaosgun, chaosgun.reloadAnimation, 8);
			GunExt.SetAnimationFPS(chaosgun, chaosgun.idleAnimation, 5);
			GunExt.AddProjectileModuleFrom(chaosgun, "ak-47", true, false);
			chaosgun.DefaultModule.ammoCost = 1;
			chaosgun.DefaultModule.shootStyle = ProjectileModule.ShootStyle.SemiAutomatic;
			chaosgun.DefaultModule.sequenceStyle = ProjectileModule.ProjectileSequenceStyle.Random;
			chaosgun.reloadTime = 1.8f;
			chaosgun.DefaultModule.cooldownTime = .2f;
			chaosgun.DefaultModule.numberOfShotsInClip = 6;
			chaosgun.SetBaseMaxAmmo(150);
			chaosgun.quality = PickupObject.ItemQuality.A;
			chaosgun.DefaultModule.angleVariance = 15f;
			chaosgun.DefaultModule.burstShotCount = 1;
			chaosgun.encounterTrackable.EncounterGuid = "chaosgun";
			ChaosRevolver.ChaosRevolverID = chaosgun.PickupObjectId;
			chaosgun.AddToSubShop(ItemBuilder.ShopType.Cursula, 1f);
			Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(chaosgun.DefaultModule.projectiles[0]);
			projectile.gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(projectile.gameObject);
			UnityEngine.Object.DontDestroyOnLoad(projectile);
			chaosgun.DefaultModule.projectiles[0] = projectile;
			projectile.baseData.damage *= 1.8f;
			projectile.baseData.speed *= 1.1f;
			projectile.transform.parent = chaosgun.barrelOffset;
			HomingModifier homing = projectile.gameObject.AddComponent<HomingModifier>();
			homing.HomingRadius = 2.5f; 
			homing.AngularVelocity = 5000;
			PierceProjModifier spook = projectile.gameObject.AddComponent<PierceProjModifier>();
			spook.penetration = 4;
			projectile.SetProjectileSpriteRight("chaosrevolver_projectile_001", 10, 10, true, tk2dBaseSprite.Anchor.MiddleCenter, new int?(7), new int?(7), null, null, null);
			ETGMod.Databases.Items.Add(chaosgun, null, "ANY");
			List<string> mandatoryConsoleIDs2 = new List<string>
			{
				"bny:chaos_chamber",
				"bny:chaos_revolver"
			};
			CustomSynergies.Add("Reunion.", mandatoryConsoleIDs2, null, true);
		}

		public override void OnPostFired(PlayerController player, Gun chaosgun)
		{
			gun.PreventNormalFireAudio = true;
			AkSoundEngine.PostEvent("Play_BOSS_dragun_shot_01", gameObject);
		}
		private bool HasReloaded;

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

		public override void OnReloadPressed(PlayerController player, Gun chaosgun, bool bSOMETHING)
		{
			if (gun.IsReloading && this.HasReloaded)
			{
				HasReloaded = false;
				AkSoundEngine.PostEvent("Stop_WPN_All", base.gameObject);
				base.OnReloadPressed(player, gun, bSOMETHING);
				AkSoundEngine.PostEvent("Play_VO_lichA_cackle_01", gameObject);
			}
		}
		public static int ChaosRevolverID;
	}
}