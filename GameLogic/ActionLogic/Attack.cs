using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.GameLogic.ActorLogic;


namespace Assets.Scripts.GameLogic.ActionLogic {

    public class Attack : Action {

        public override IActor GetDefaultTarget() {
            return actor.GetOpponents().FirstOrDefault();
        }

        public override ICollection<Actor> GetValidTargets() {
            return actor.GetOpponents() as ICollection<Actor>;
        }

        public override void Execute(Actor target) {
            base.Execute(target);
        }

    }

}