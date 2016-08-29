using Assets.Scripts.Values;
using UnityEngine;


namespace Assets.Scripts.GameLogic.BattleLogic {

    public interface IBattleObject {

        Coord Coord { get; }
        string Name { get; }

    }

    public class BattleObject: MonoBehaviour, IBattleObject {

        public Coord Coord { get { return Battle.Grid.GetCoord(this); } }

        public string Name {
            get { return name; }
        }

        protected IBattle Battle {
            get { return GetComponentInParent(typeof(IBattle)) as IBattle; }
        }

    }

}