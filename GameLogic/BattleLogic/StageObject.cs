using Assets.Scripts.Values;


namespace Assets.Scripts.GameLogic.BattleLogic {

    public interface IStageObject : IBattleObject {

        Coord Coord { get; }
        string Name { get; }

    }

    public abstract class StageObject : BattleObject, IStageObject {

        protected StageObject(IBattle battle, string name) : base(battle) {
            Name = name;
        }

        public Coord Coord {
            get { return Battle.Grid.GetCoordOf(this); }
        }

        public string Name { get; private set; }

    }

}