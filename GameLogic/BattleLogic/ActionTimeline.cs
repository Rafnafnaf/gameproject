using System.Collections.Generic;
using Assets.Scripts.GameLogic.ActorLogic;


namespace Assets.Scripts.GameLogic.BattleLogic {

    public interface IActionTimeline {

        void Put(IActor actor);
        IActor Unqueue();
        int CalculateIndex(IActor actor);

    }

    public class ActionTimeline : IActionTimeline {

        private List<IActor> timeline;

        public ActionTimeline() {
            timeline = new List<IActor>();
        }

        public void Put(IActor actor) {
            if (timeline.Count == 0) {
                timeline.Add(actor);
                return;
            }

            int index = CalculateIndex(actor);
            timeline.Insert(index, actor);
        }
        
        IActor IActionTimeline.Unqueue() {
            return Unqueue();
        }

        public int CalculateIndex(IActor actor) {
            throw new System.NotImplementedException();
        }

        public IActor Unqueue() {
            IActor result = timeline[0];
            timeline.RemoveAt(0);
            return result;
        }

        public int CalculateIndex(Actor actor) {
            for (int i = 0; i < timeline.Count; i++) {
                if (actor.ActionRank < timeline[i].ActionRank) return i;
            }
            return timeline.Count;
        }

    }

}