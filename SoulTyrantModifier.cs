using Modding;
using SFCore.Utils;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;

namespace SoulTyrantModifier {
    public class SoulTyrantModifier : Mod {
        public static SoulTyrantModifier instance;

        public SoulTyrantModifier() : base("Soul Tyrant Modifier") => instance = this;

        public override string GetVersion() => GetType().Assembly.GetName().Version.ToString();

        public bool ToggleButtonInsideMenu => false;

        public override void Initialize() {
            Log("Initializing");

            On.PlayMakerFSM.OnEnable += OnEnable;

            Log("Initialized");
        }

        public void OnEnable(On.PlayMakerFSM.orig_OnEnable orig, PlayMakerFSM self) {
            orig(self);

            if (self.FsmName == "Mage Lord 2" && self.gameObject.name == "Dream Mage Lord Phase2") {
                self.GetAction<SendRandomEvent>("Shift?", 0).weights = new FsmFloat[]{1f, 0f};
            }
        }
    }
}
