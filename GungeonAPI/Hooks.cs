using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using GungeonAPI;
using MonoMod.RuntimeDetour;
using UnityEngine;

namespace BunnyMod
{
	// Token: 0x02000018 RID: 24
	public static class HookYeah
	{
		// Token: 0x060000B7 RID: 183 RVA: 0x00008CE4 File Offset: 0x00006EE4
		public static void Init()
		{
			try
			{

				Hook hook = new Hook(typeof(Foyer).GetMethod("Awake", BindingFlags.Instance | BindingFlags.NonPublic), typeof(BunnyModule).GetMethod("LateStart1"));
				Hook openchesthook = new Hook(typeof(Chest).GetMethod("Open", BindingFlags.Instance | BindingFlags.NonPublic), typeof(BunnysFoot).GetMethod("LootPlus"));

			}
			catch (Exception e)
			{
				Tools.PrintException(e, "FF0000");
			}
		}
	}
}

