using System.Collections.Generic;
using Assets.Scripts.GameLogic.ActionLogic;


namespace Assets.Scripts.GameLogic.ActorLogic {

    public interface IActionList {

        IList<Action> GetActions();

    }

}