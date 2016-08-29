using Assets.Scripts.GameLogic.ActorLogic;
using Assets.Scripts.GameLogic.BattleLogic;


namespace Assets.Scripts.Components.BattleComponents {

    public class BattleComponent : BaseComponent, IBattle {

        public event ActorBeginTurnEvent ActorBeginTurnEvent {
            add { battle.ActorBeginTurnEvent += value; }
            remove { battle.ActorBeginTurnEvent -= value; }
        }

        public event ActorEndTurnEvent ActorEndTurnEvent {
            add { battle.ActorEndTurnEvent += value; }
            remove { battle.ActorEndTurnEvent -= value; }
        }

        public event ActorSelectedEvent ActorSelectedEvent {
            add { battle.ActorSelectedEvent += value; }
            remove { battle.ActorSelectedEvent -= value; }
        }

        public event BattleStartEvent BattleStartEvent {
            add { battle.BattleStartEvent += value; }
            remove { battle.BattleStartEvent -= value; }
        }

        private Battle battle;

        public IStage Stage {
            get { return GetComponentInChildren(typeof(IStage)) as IStage; }
        }

        public IActor ActiveActor {
            get { return battle.ActiveActor; }
        }

        public IGrid Grid {
            get { return GetComponentInChildren(typeof(IGrid)) as IGrid; }
        }

        public IActionTimeline ActionTimeline {
            get { return GetComponentInChildren(typeof(IActionTimeline)) as IActionTimeline; }
        }

        public void Start() {
            battle.Start();
        }

        public bool IsActiveActor(IActor actor) {
            return battle.IsActiveActor(actor);
        }

        public bool IsSelectedActor(IActor actor) {
            return battle.IsSelectedActor(actor);
        }

        public void SelectActor(IActor actor) {
            battle.SelectActor(actor);
        }

        public void OnActorEndTurn() {
            battle.OnActorEndTurn();
        }

        protected override void Awake() {
            battle = new Battle(Stage, Grid, ActionTimeline);
        }

    }

}