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
	public class PocketPistol : GunBehaviour
	{
		public static void Add()
		{
			Gun boomrevolver = ETGMod.Databases.Items.NewGun("Pocket Pistol", "pocketpistol");
			Game.Items.Rename("outdated_gun_mods:pocket_pistol", "bny:pocket_pistol");
			boomrevolver.gameObject.AddComponent<PocketPistol>();
			GunExt.SetShortDescription(boomrevolver, "Happy to see me?");
			GunExt.SetLongDescription(boomrevolver, "An incredibly small firearm. How do bullets even fit in there?");
			GunExt.SetupSprite(boomrevolver, null, "pocketpistol_idle_001", 19);
			GunExt.SetAnimationFPS(boomrevolver, boomrevolver.shootAnimation, 15);
			GunExt.SetAnimationFPS(boomrevolver, boomrevolver.reloadAnimation, 7);
			GunExt.SetAnimationFPS(boomrevolver, boomrevolver.idleAnimation, 1);
			GunExt.AddProjectileModuleFrom(boomrevolver, "magnum", true, false);
			boomrevolver.gunSwitchGroup = (PickupObjectDatabase.GetById(79) as Gun).gunSwitchGroup;
			boomrevolver.DefaultModule.ammoCost = 1;
			boomrevolver.DefaultModule.shootStyle = ProjectileModule.ShootStyle.SemiAutomatic;
			boomrevolver.DefaultModule.sequenceStyle = ProjectileModule.ProjectileSequenceStyle.Random;
			boomrevolver.reloadTime = 0.9f;
			boomrevolver.barrelOffset.transform.localPosition = new Vector3(.5f, 0.25f, 0f);
			boomrevolver.DefaultModule.cooldownTime = .3f;
			boomrevolver.DefaultModule.numberOfShotsInClip = 6;
			boomrevolver.SetBaseMaxAmmo(327);
			boomrevolver.quality = PickupObject.ItemQuality.D;
			boomrevolver.DefaultModule.angleVariance = 4f;
			boomrevolver.AddPassiveStatModifier(PlayerStats.StatType.AmmoCapacityMultiplier, .1f, StatModifier.ModifyMethod.ADDITIVE);
			boomrevolver.AddToSubShop(ItemBuilder.ShopType.Trorc, 1f);
			boomrevolver.encounterTrackable.EncounterGuid = "The Small Gun Hell Yeah Brother";
			Projectile projectile = UnityEngine.Object.Instantiate<Projectile>(boomrevolver.DefaultModule.projectiles[0]);
			projectile.gameObject.SetActive(false);
			FakePrefab.MarkAsFakePrefab(projectile.gameObject);
			UnityEngine.Object.DontDestroyOnLoad(projectile);
			boomrevolver.DefaultModule.projectiles[0] = projectile;
			projectile.shouldRotate = true;
			projectile.baseData.damage = 7.5f;
			projectile.baseData.speed *= 1.5f;
			projectile.AdditionalScaleMultiplier = 0.7f;
			projectile.transform.parent = boomrevolver.barrelOffset;
			ETGMod.Databases.Items.Add(boomrevolver, null, "ANY");
			List<string> mandatoryConsoleIDs1 = new List<string>
			{
				"bny:pocket_pistol"
			};
			List<string> optionalConsoleID1s = new List<string>
			{
				"stout_bullets",
				"fat_bullets",
				"+1_bullets",
				"flak_bullets"
			};
			CustomSynergies.Add("How do these even fit in?", mandatoryConsoleIDs1, optionalConsoleID1s, true);
		}
		public override void PostProcessProjectile(Projectile projectile)
		{
			PlayerController player = this.gun.CurrentOwner as PlayerController;
			bool flagA = player.PlayerHasActiveSynergy("How do these even fit in?");
			if (flagA)
			{
				projectile.baseData.damage *= 1.2f;
				projectile.AdditionalScaleMultiplier *= 2f;
			}
		}
		private bool HasReloaded;

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
	}
}