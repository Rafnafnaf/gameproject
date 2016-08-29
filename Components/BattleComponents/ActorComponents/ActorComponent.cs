using Assets.Scripts.Components.BattleComponents.StageComponents;
using Assets.Scripts.GameLogic.ActionLogic;
using Assets.Scripts.GameLogic.ActorLogic;
using UnityEngine;


namespace Assets.Scripts.Components.BattleComponents.ActorComponents {

    public abstract class ActorComponent : StageObjectComponent, IActor {

        private IActor Implementation {
            get { return (IActor) implementation; }
        }

        public Vector3 GlobalPosition {
            get { return transform.position; }
        }

        protected IActionContainer ActionContainer {
            get { return GetComponentInChildren(typeof(IActionContainer)) as IActionContainer; }
        }

        public IAction[] Actions {
            get { return Implementation.Actions; }
        }

        public int ActionRank {
            get { return Implementation.ActionRank; }
        }

        public void BeginTurn() {
            Implementation.BeginTurn();
        }

    }

}