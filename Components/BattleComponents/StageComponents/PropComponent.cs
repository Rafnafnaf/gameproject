using Assets.Scripts.GameLogic.BattleLogic;


namespace Assets.Scripts.Components.BattleComponents.StageComponents {

    public class PropComponent : StageObjectComponent, IProp {

        protected override void Awake() {
            implementation = new Prop(Battle, name);
        }

    }

}