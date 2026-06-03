using FrooxEngine;
using HarmonyLib;
using ResoniteModLoader;

namespace JustDontYield;
//More info on creating mods can be found https://github.com/resonite-modding-group/ResoniteModLoader/wiki/Creating-Mods
public class JustDontYield : ResoniteMod {
	internal const string VERSION_CONSTANT = "1.0.0"; //Changing the version here updates it in all locations needed
	public override string Name => "JustDontYield";
	public override string Author => "Noble";
	public override string Version => VERSION_CONSTANT;
	public override string Link => "https://github.com/noblereign/JustDontYield/";

	public override void OnEngineInit() {
		Harmony harmony = new("dog.glacier.JustDontYield");
		harmony.PatchAll();
	}

	//Example of how a HarmonyPatch can be formatted, Note that the following isn't a real patch and will not compile.
	[HarmonyPatch(typeof(ToWorld), "OnCompleted")]
	class ToWorld_OnCompleted_Patch {
		static bool Prefix(ToWorld __instance) {
			CoroutineManager _manager = CoroutineManager.Manager.Value;
			if (_manager == null) {
				Warn("JustDontYield intercepted: Cannot yield to world, origin CoroutineManager is null!");
				return false;
			}
			return true;
		}
	}
}
