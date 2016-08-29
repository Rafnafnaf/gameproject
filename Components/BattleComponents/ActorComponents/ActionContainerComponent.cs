using Assets.Scripts.GameLogic.ActionLogic;
using Assets.Scripts.GameLogic.ActorLogic;


namespace Assets.Scripts.Components.BattleComponents.ActorComponents {

    public class ActionContainerComponent : ActorObjectComponent, IActionContainer {

        public IAction[] Actions {
            get { return GetComponentsInChildren(typeof(IAction)) as IAction[]; }
        }

    }

}