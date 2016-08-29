using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.GameLogic.ActorLogic;


namespace Assets.Scripts.GameLogic.ActionLogic {

    public class Attack : Action {

        public override Actor GetDefaultTarget() {
            return owner.GetOpponents().FirstOrDefault();
        }

        public override ICollection<Actor> GetValidTargets() {
            return owner.GetOpponents();
        }

    }

}