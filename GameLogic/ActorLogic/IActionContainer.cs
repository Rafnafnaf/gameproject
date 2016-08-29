using Assets.Scripts.GameLogic.ActionLogic;


namespace Assets.Scripts.GameLogic.ActorLogic {

    public interface IActionContainer {

        IAction[] Actions { get; }

    }

}