using System.Collections.Generic;
using Assets.Scripts.GameLogic.ActorLogic;


namespace Assets.Scripts.GameLogic.ActionLogic {

    public interface IAction {

        

    }

    public abstract class Action: IAction {

        public int TimeCost = 100;
        protected Actor owner;
        protected Actor target;

        public bool IsSelectable {
            get { return true; }
        }

        public abstract Actor GetDefaultTarget();

        public abstract ICollection<Actor> GetValidTargets();

    }

}