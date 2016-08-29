using Assets.Scripts.GameLogic.ActorLogic;
using Assets.Scripts.GameLogic.BattleLogic;


namespace Assets.Scripts.Components.BattleComponents {

    public class ActionTimelineComponent : BattleObjectComponent, IActionTimeline {

        private IActionTimeline implementation;

        public void Put(IActor actor) {
            implementation.Put(actor);
        }

        public IActor Unqueue() {
            return implementation.Unqueue();
        }

        public int CalculateIndex(IActor actor) {
            return implementation.CalculateIndex(actor);
        }

        protected override void Awake() {
            implementation = new ActionTimeline();
        }

    }

}