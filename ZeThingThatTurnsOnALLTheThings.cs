﻿using ItemAPI;
using GungeonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;
using MonoMod.RuntimeDetour;
using System.Reflection;
using MonoMod.Utils;


namespace BunnyMod
{
	// Token: 0x02000008 RID: 8
	public class BunnyModule : ETGModule
	{

		// Token: 0x0600001B RID: 27 RVA: 0x000028E8 File Offset: 0x00000AE8
		public override void Start()
		{
			ItemBuilder.Init();
			FakePrefabHooks.Init();
			HookYeah.Init();
			GungeonAPI.GungeonAP.Init();
			FakePrefabHooks.Init();
			GungeonAPI.Tools.Init();
			ItemAPI.FakePrefabHooks.Init();
			GungeonAP.Init();
			FakePrefabHooks.Init();
			ShrineFactory.Init();
			ShrineFactory.PlaceBnyBreachShrines();
			TestActiveItem.Init();
			VengeanceVlone.Init();
			ShatterEffect.Initialise();
			ShrineOfTheLeadLord.Add();


			ArtifactOfRevenge.Init();
			ArtifactOfAttraction.Init();
			ArtifactOfGlass.Init();
			ArtifactOfAvarice.Init();
			ArtifactOfDaze.Init();
			ArtifactOfPrey.Init();
			ArtifactOfMegalomania.Init();
			ArtifactOfFodder.Init();
			ArtifactOfBolster.Init();
			ArtifactOfHatred.Init();
			ArtifactOfEnigma.Init();
			ArtifactOfSacrifice.Init();



			ModuleCannon.Add();
			ModuleChip.Init();
			ModuleAmmoEater.Init();
			ModuleDamage.Init();
			ModuleClipSize.Init();
			ModuleFireRate.Init();
			ModuleReload.Init();
			T2ModuleYV.Init();
			T2ModuleCloak.Init();
			T2ModulePierce.Init();
			T2ModuleBounce.Init();
			T2ModuleEjector.Init();
			T2ModuleHoming.Init();
			T3ModuleRocket.Init();
			T3ModuleInaccurate.Init();
			T3ModuleColossus.Init();
			T3ModuleOverload.Init();
			T3ModuleReactive.Init();
			CorruptModuleSensor.Init();
			CorruptModuleAccuracy.Init();
			CorruptModuleLoose.Init();
			CorruptModuleCoolant.Init();
			CorruptModuleDamage.Init();


			//Gimmick Heavy Guns
			TrainGun.Add();
			LastStand.Add();
			SoulStealer.Add();
			Commiter.Add();
			Pickshot.Add();
			AerialBombardment.Add();


			//Mimic Guns
			Casemimic.Add();
			ABlasphemimic.Add();
			Gunthemimic.Add();
			
			Mimikey47.Add();

			//Mechanical Guns

			ThunderStorm.Add();
			CaptainsShotgun.Add();
			EnforcersLaw.Add();
			TimeZoner.Add();
			ArtemissileRocket.Add();
			BigNukeGun.Add();
			BoxGun.Add();
			REXNeedler.Add(); 
			FlakCannon.Add();
			GunslayerShotgun.Add();
			RogueLegendary.Add();


			//Otherworldly Guns
			HarvestersShotgun.Add();
			
			PrismaticShot.Add();
			Starbounder.Add();
			ReaverClaw.Add();
			ReaverHeart.Add();
			ChaosRevolver.Add();
			ChaosRevolverSynergyForme.Add();
			ChaosHand.Add();
			NuclearTentacle.Add();

			//Outright Wacky weaponry
			OppressorsCrossbow.Add();
			GunslayerGauntlets.Add();
			SuperFlakCannon.Add();
			MithrixHammer.Add();
			TungstenCube.Add();
			CoolStaff.Add();
			ASwordGun.Add();
			AGunSword.Add();

			//Dumb Guns
			StickGun.Add();
			BulletCaster.Add();
			SausageRevolver.Add();
			BloatedRevolver.Add();
			PocketPistol.Add();
			BrokenGunParts.Add();
			IDPDFreakGun.Add();
			FakeShotgun.Add();

			//Life Living 
			PersonalGuard.Init();
			GlockOfTheDead.Init();
			LizardBloodTransfusion.Init();
			AbsoluteZeroPotion.Init();
			MatrixPotion.Init();
			GreandeParasite.Init();
			//Joke Items
			SpeckOfDust.Init();
			LastResort.Init();
			JokeBook.Init();
			//Mechanical Items
			OnPlayerItemUsedItem.Init();
			BloodyTrigger.Init();
			StaticCharger.Init();

			//Bullet Type Items
			ResurrectionBullets.Init();
			GuillotineRounds.Register();
			
			LunarGlassRounds.Init();
			ReaverRounds.Init();
			
			
			SimpBullets.Init();
			//Cursed Items   Risk Reward Items
			LeadHand.Init();
			JammedGuillotine.Init();

			CrownOfBlood.Init();
			RTG.Init();
			DGrenade.Init();
			MalachiteCrown.Init();
			AncientWhisper.Init();
			AncientEnigma.Init();
			LunarGlassSyringe.Init();
			SlayerKey.Init();
			DamocleanClip.Init();
			DeathMark.Init();
			TheMonolith.Init();
			LoopMarker.Init();
			BulletRelic.Init();
			GodLifesGift.Init();

			//Defense Items
			SuperShield.Init();
			GunslayerHelmet.Init();
			FreezeLighter.Init();
			//Stats Up
			Microscope.Init();
			EmpoweringCore.Init();
			BookOfEconomics.Register();
			CounterChamber.Register();
			Infusion.Init();
			MinigunRounds.Register();
			//Otherworldly
			SpiritOfStagnation.Init();
			SoulInAJar.Init();
			AmmoRepurposer.Init();
			SkyGrass.Init();
			ChaosChamber.Init();
			ChaosGodsWrath.Register();
			Coolrobes.Init();
			//Companion Items/CompanionAI
			Claycord.Init();
			Blastcore.Init();
			ClayCordStatue.ClayBuildPrefab();
			GunSoulBox.Init();
			GunSoulBlue.BlueBuildPrefab();
			GunSoulGreen.GreenBuildPrefab();
			GunSoulRed.RedBuildPrefab();
			GunSoulYellow.YellowBuildPrefab();
			GunSoulPink.PinkBuildPrefab();
			GunSoulPurple.PurpleBuildPrefab();
			PointZero.Init();
			BabyGoodModular.Init();
			//Guon Stones
			GuonPebble.Init();
			ChaosGuonStone.Init();
			BulluonStone.Init();
			DynamiteGuon.Init();
			GuonGeon.Init();
			//Ammolets
			LunarGlassAmmolet.Init();
			ReaverAmmolet.Init();
			//TableTechs
			TableTechReload.Init();
			TableTechBomb.Init();
			TableTechSoul.Init();
			TableTechKnife.Init();
			//OP???
			BunnysFoot.Init();
			//Random Weird Shit that just kinda exists
			GungeonInvestment.Init();
			BrokenLockpicker.Init();
			Dejammer.Init();
			Keylocator.Init();
			Keyceipt.Init();
			FrequentFlyer.Init();

			//Vengeance.Init();
			TestItemBNY.Init();
			DragunHeartThing.Init();
			MasteryReplacementRNG.InitDungeonHook();
			SynergyFormInitialiser.AddSynergyForms();
			InitialiseSynergies.DoInitialisation();
			BunnyModule.Log(BunnyModule.MOD_NAME + " v" + BunnyModule.VERSION + " started successfully.", BunnyModule.TEXT_COLOR);
		}
		public static void LateStart1(Action<Foyer> orig, Foyer self1)
		{
			orig(self1);
			bool flag = BunnyModule.hasInitialized;
			if (!flag)
			{
				ArtifactMonger.Add();
				WhisperShrine.Add();
				DeicideShrine.Add();

				{
					ShrineFactory.PlaceBnyBreachShrines();
				}
				BunnyModule.hasInitialized = true;
			}
			ShrineFactory.PlaceBnyBreachShrines();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00002944 File Offset: 0x00000B44
		public static void Log(string text, string color = "#FFFFFF")
		{
			ETGModConsole.Log(string.Concat(new string[]
			{
				"<color=",
				color,
				">",
				text,
				"</color>"
			}), false);
		}

		public static string LocalShaderNameGetHook(Func<PlayerController, string> orig, PlayerController self)
		{
			if (!GameOptions.SupportsStencil)
			{
				return "Brave/PlayerShaderNoStencil";
			}
			if (self.name == "PlayerModular(Clone)")
			{
				Material mat = new Material(EnemyDatabase.GetOrLoadByName("GunNut").sprite.renderer.material);
				mat.SetTexture("_MainTexture", self.sprite.renderer.material.GetTexture("_MainTex"));
				mat.SetColor("_EmissiveColor", new Color32(67, 225, 240, 255));
				mat.SetFloat("_EmissiveColorPower", 1.55f);
				mat.SetFloat("_EmissivePower", 80);
				self.sprite.renderer.material = mat;
				return mat.shader.name;
			}
			return orig(self);
		}


		// Token: 0x0600001D RID: 29 RVA: 0x00002979 File Offset: 0x00000B79
		public override void Exit()
		{
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000297C File Offset: 0x00000B7C
		public override void Init()
		{
		}

		// Token: 0x04000001 RID: 1
		public static readonly string MOD_NAME = "Some Bunnys Content Mod";

		// Token: 0x04000002 RID: 2
		public static readonly string VERSION = "1.14.1";

		// Token: 0x04000003 RID: 3
		public static readonly string TEXT_COLOR = "#316316";
		private static bool hasInitialized;

	}
}
