using System.Collections.Generic;
using Assets.Scripts.GameLogic.ActionLogic;
using Assets.Scripts.GameLogic.BattleLogic;
using UnityEngine;


namespace Assets.Scripts.GameLogic.ActorLogic {

    public interface IActor : IStageObject {

        IAction[] Actions { get; }
        int ActionRank { get; }
        void BeginTurn();

    }

    public abstract class Actor : StageObject, IActor {

        private IActionContainer actionContainer;

        protected Actor(IBattle battle, string name, IActionContainer actionContainer) : base(battle, name) {
            this.actionContainer = actionContainer;
        }

        public int ActionRank { get; private set; }

        public IAction[] Actions {
            get { return actionContainer.Actions; }
        }

        public virtual void BeginTurn() {
            Debug.Log(Name + "'s turn begins");
        }

        public abstract ICollection<Actor> GetOpponents();
        public abstract ICollection<Actor> GetAllies();

        protected void EndTurn() {
            Debug.Log(Name + "'s turn ends");
            Battle.OnActorEndTurn();
        }

    }

}