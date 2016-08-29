namespace Assets.Scripts.GameLogic.BattleLogic {

    public interface IBattleObject {

    }

    public class BattleObject : IBattleObject {

        protected BattleObject(IBattle battle) {
            Battle = battle;
        }

        protected IBattle Battle { get; private set; }

    }

}