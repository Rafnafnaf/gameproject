namespace Assets.Scripts.GameLogic.BattleLogic {

    public interface IProp : IStageObject {

    }

    public class Prop : StageObject {

        public Prop(IBattle battle, string name) : base(battle, name) {}

    }

}