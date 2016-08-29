using System.Collections.Generic;
using Assets.Scripts.GameLogic.ActorLogic;
using Assets.Scripts.GameLogic.BattleLogic;


namespace Assets.Scripts.Components.BattleComponents.StageComponents {

    public class StageComponent : BattleObjectComponent, IStage {

        private ActorContainerComponent ActorContainer {
            get { return GetComponentInChildren<ActorContainerComponent>(); }
        }

        private PropContainerComponent PropContainer {
            get { return GetComponentInChildren<PropContainerComponent>(); }
        }

        public IList<IActor> GetActors() {
            return ActorContainer.GetActors();
        }

        public IList<IEnemy> GetEnemies() {
            return ActorContainer.GetEnemies();
        }

        public IList<IHero> GetHeroes() {
            return ActorContainer.GetHeroes();
        }

        public IProp[] GetProps() {
            return PropContainer.GetProps();
        }

        public IStageObject[] GetStageObjects() {
            return GetComponentsInChildren(typeof(IStageObject)) as IStageObject[];
        }

        public void Add(IActor actor) {
            ActorContainer.Add(actor);
        }

        public void Add(IProp prop) {
            PropContainer.Add(prop);
        }

        protected override void Awake() {}

    }

}