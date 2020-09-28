using ItemAPI;
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
			FakePrefabHooks.Init();
			HookYeah.Init();
			ShatterEffect.Initialise();
			GungeonAPI.GungeonAP.Init();
			FakePrefabHooks.Init();
			GungeonAPI.Tools.Init();
			ItemAPI.FakePrefabHooks.Init();
			GungeonAP.Init();
			FakePrefabHooks.Init();
			ShrineFactoryBny.Init();
			ItemBuilder.Init();
			ShrineFactoryBny.PlaceBnyBreachShrines();
			CounterChamber.Register();
			GuillotineRounds.Register();
			ChaosGodsWrath.Register();
			MinigunRounds.Register();
			GodLifesGift.Init();
			StaticCharger.Init();
			SpeckOfDust.Init();
            AmmoRepurposer.Init();
            BookOfEconomics.Register();
            SkyGrass.Init();
            ChaosChamber.Init();
			AncientWhisper.Init();
			LunarGlassSyringe.Init();
			SlayerKey.Init();
			PersonalGuard.Init();
			TheMonolith.Init();
			GlockOfTheDead.Init();
			CrownOfBlood.Init();
			ResurrectionBullets.Init();
			LastResort.Init();
			FrequentFlyer.Init();
			LizardBloodTransfusion.Init();
			FreezeLighter.Init();
			LoopMarker.Init();
			GunslayerHelmet.Init();
			Coolrobes.Init();
			GreandeParasite.Init();
            PointZero.Init();
			ChaosGuonStone.Init();
			Blastcore.Init();
			AncientEnigma.Init();
			BulletRelic.Init();
			OnPlayerItemUsedItem.Init();
			TestActiveItem.Init();
			BoxGun.Add();
			SausageRevolver.Add();
			TrainGun.Add();
			BigNukeGun.Add();
			BulletCaster.Add();
			FlakCannon.Add();
			BrokenLockpicker.Init();
			CoolStaff.Add();
			DeathMark.Init();
			DamocleanClip.Init();
			AbsoluteZeroPotion.Init();
			MatrixPotion.Init();
			ASwordGun.Add();
			AGunSword.Add();
			ABlasphemimic.Add();
			MalachiteCrown.Init();
			Keylocator.Init();
			Keyceipt.Init();
			OppressorsCrossbow.Add();
			IDPDFreakGun.Add();
			FakeShotgun.Add();
			SpiritOfStagnation.Init();
			SoulInAJar.Init();
			SimpBullets.Init();
			NuclearTentacle.Add();
			GuonPebble.Init();
			DynamiteGuon.Init();
			BloodyTrigger.Init();
			ReaverHeart.Add();
			JokeBook.Init();
			DGrenade.Init();
			BulluonStone.Init();
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
			ThunderStorm.Add();
			AerialBombardment.Add();
			StickGun.Add();
			GunslayerShotgun.Add();
			GuonGeon.Init();
			RogueLegendary.Add();
			Dejammer.Init();
			BloatedRevolver.Add();
			GunSoulBox.Init();
			GunSoulBlue.BlueBuildPrefab();
			GunSoulGreen.GreenBuildPrefab();
			GunSoulRed.RedBuildPrefab();
			GunSoulYellow.YellowBuildPrefab();
			GunSoulPink.PinkBuildPrefab();
			GunSoulPurple.PurpleBuildPrefab();
			SoulStealer.Add();
			Casemimic.Add();
			LeadHand.Init();
			ChaosHand.Add();
			CaptainsShotgun.Add();
			Claycord.Init();
			ClayCordStatue.ClayBuildPrefab();
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
			MithrixHammer.Add();
			SuperFlakCannon.Add();
			TungstenCube.Add();
			Pickshot.Add();
			Microscope.Init();
			EmpoweringCore.Init();
			RTG.Init();
			Commiter.Add();
			Starbounder.Add();
			Vengeance.Init();
			ChaosRevolver.Add();
			ChaosRevolverSynergyForme.Add();
			ReaverClaw.Add();
			EnforcersLaw.Add();
			GunslayerGauntlets.Add();
			PrismaticShot.Add();
			GungeonInvestment.Init();
			JammedGuillotine.Init();
			TimeZoner.Add();
			SuperShield.Init();
			LastStand.Add();
			ArtemissileRocket.Add();
			BunnysFoot.Init();
			Infusion.Init();
			Gunthemimic.Add();
			REXNeedler.Add();
			SynergyFormInitialiser.AddSynergyForms();
			InitialiseSynergies.DoInitialisation();
			; BunnyModule.Log(BunnyModule.MOD_NAME + " v" + BunnyModule.VERSION + " started successfully.", BunnyModule.TEXT_COLOR);
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
				  ShrineFactoryBny.PlaceBnyBreachShrines();
				}
				BunnyModule.hasInitialized = true;
			}
			ShrineFactoryBny.PlaceBnyBreachShrines();
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
		public static readonly string VERSION = "1.13.0";

		// Token: 0x04000003 RID: 3
		public static readonly string TEXT_COLOR = "#316316";
		private static bool hasInitialized;

	}
}
