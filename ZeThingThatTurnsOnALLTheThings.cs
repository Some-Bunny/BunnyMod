using ItemAPI;
using GungeonAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace BunnyMod
{
	// Token: 0x02000008 RID: 8
	public class Module : ETGModule
	{
		// Token: 0x0600001B RID: 27 RVA: 0x000028E8 File Offset: 0x00000AE8
		public override void Start()
		{
			ArtifactMonger.Add();
			GungeonAPI.GungeonAP.Init();
			FakePrefabHooks.Init();
			GungeonAPI.Tools.Init();
			ItemAPI.FakePrefabHooks.Init();
			GungeonAP.Init();
			FakePrefabHooks.Init();
			ShrineFactory.Init();
			ItemBuilder.Init();
			ShrineFactory.PlaceBreachShrines();
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
			ChaosRevolver.Add();
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
			ArtifactToken.Init();
			Deicide.Init();
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
			; Module.Log(Module.MOD_NAME + " v" + Module.VERSION + " started successfully.", Module.TEXT_COLOR);
		}
		public static void LateStart(Action<Foyer> orig, Foyer self)
		{
			orig(self);
			GungeonAPI.Tools.Print<string>("oh shit deploy the boy", "FFFFFF", false);
			bool flag = Module.hasInitialized;
			if (!flag)
			{
				GungeonAPI.Tools.StartTimer("Initializing mod");
				ArtifactMonger.Add();
				GungeonAPI.Tools.StopTimerAndReport("Initializing mod");
				Module.hasInitialized = true;
				GungeonAPI.Tools.Print<string>("Custom Character Mod v" + Module.VERSION + " Initialized", "00FF00", true);
				GungeonAPI.Tools.Print<string>("Reloaded Breach:", "00FF00", true);
				ShrineFactory.PlaceBreachShrines();
			}
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
		public static readonly string MOD_NAME = "Some Bunnys Item Mod";

		// Token: 0x04000002 RID: 2
		public static readonly string VERSION = "1.10.0 ";

		// Token: 0x04000003 RID: 3
		public static readonly string TEXT_COLOR = "#316316";
        private static bool hasInitialized;
    }
}
