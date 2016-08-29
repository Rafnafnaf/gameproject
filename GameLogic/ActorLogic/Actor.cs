using System.Collections.Generic;
using Assets.Scripts.GameLogic.ActionLogic;
using Assets.Scripts.GameLogic.BattleLogic;
using Assets.Scripts.Values;
using UnityEngine;


namespace Assets.Scripts.GameLogic.ActorLogic {

    public interface IActor {

        string Name { get; }
        int ActionRank { get; }
        void BeginTurn();
        void MoveTo(Coord coord);

    }

    public abstract class Actor : MonoBehaviour, IActor {

        private int actionRank = 0;

        protected IBattle Battle {
            get { return GetComponentInParent(typeof(IBattle)) as IBattle; }
        }

        public string Name {
            get { return name; }
        }

        public int ActionRank {
            get { return actionRank; }
        }

        public virtual void BeginTurn() {
            Debug.Log(name + "'s turn begins");
        }

        public void MoveTo(Coord coord) {
            Debug.Log(name + " moving to " + coord);
        }

        public abstract ICollection<IActor> GetOpponents();
        public abstract ICollection<IActor> GetAllies();

        protected ICollection<Action> GetActions() {
            return GetComponentsInChildren<Action>();
        }

        protected void EndTurn() {
            Debug.Log(name + "'s turn ends");
            Battle.OnActorEndTurn();
        }

    }

}