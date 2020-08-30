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
	public class ModuleCannon : GunBehaviour
	{
		public static void Add()
		{
			Gun modcannon = ETGMod.Databases.Items.NewGun("Modular Cannon", "modulecannon");
			Game.Items.Rename("outdated_gun_mods:modular_cannon", "bny:modular_cannon");
			modcannon.gameObject.AddComponent<ModuleCannon>();
			GunExt.SetShortDescription(modcannon, "Base Hand Cannon V1.395");
			GunExt.SetLongDescription(modcannon, "A basic model hand cannon fitted with modular tech compatibility.");
			GunExt.SetupSprite(modcannon, null, "modulecannon_idle_001", 25);
			GunExt.SetAnimationFPS(modcannon, modcannon.shootAnimation, 36);
			GunExt.SetAnimationFPS(modcannon, modcannon.reloadAnimation, 4);
			GunExt.SetAnimationFPS(modcannon, modcannon.idleAnimation, 1);
			GunExt.AddProjectileModuleFrom(modcannon, PickupObjectDatabase.GetById(88) as Gun, true, false);
			modcannon.DefaultModule.ammoCost = 1;
			modcannon.gunSwitchGroup = (PickupObjectDatabase.GetById(88) as Gun).gunSwitchGroup;
			modcannon.DefaultModule.shootStyle = ProjectileModule.ShootStyle.SemiAutomatic;
			modcannon.DefaultModule.sequenceStyle = ProjectileModule.ProjectileSequenceStyle.Random;
			modcannon.reloadTime = 2f;
			modcannon.DefaultModule.cooldownTime = .33f;
			modcannon.DefaultModule.numberOfShotsInClip = 12;
			modcannon.SetBaseMaxAmmo(300);
			modcannon.InfiniteAmmo = true;
			modcannon.barrelOffset.transform.localPosition = new Vector3(.5625f, 0.25f, 0f);
			modcannon.quality = PickupObject.ItemQuality.EXCLUDED;
			modcannon.DefaultModule.angleVariance = 3f;
			modcannon.DefaultModule.burstShotCount = 1;
			modcannon.encounterTrackable.EncounterGuid = "ModularCannon";
			modcannon.CanBeDropped = false;
			Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(modcannon.DefaultModule.projectiles[0]);
			projectile.gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(projectile.gameObject);
			UnityEngine.Object.DontDestroyOnLoad(projectile);
			modcannon.DefaultModule.projectiles[0] = projectile;
			projectile.baseData.damage *= .8f;
			projectile.baseData.speed *= 1f;
			projectile.shouldRotate = true;
			projectile.baseData.range = 1000;
			projectile.transform.parent = modcannon.barrelOffset;
			ETGMod.Databases.Items.Add(modcannon, null, "ANY");
			ModuleCannon.ModuleGunID = modcannon.PickupObjectId;

		}
		protected void Update()
		{
			bool flag = this.gun.CurrentOwner;
			if (flag)
			{
				bool flag2 = !this.gun.IsReloading && !this.HasReloaded;
				if (flag2)
				{
					this.HasReloaded = true;
				}
			}
		}
		private bool HasReloaded;
		public static int ModuleGunID;
	}
}