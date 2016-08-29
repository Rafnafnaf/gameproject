using Assets.Scripts.GameLogic.ActorLogic;
using UnityEngine;


namespace Assets.Scripts.GameLogic.BattleLogic {

    public delegate void ActorBeginTurnEvent(IActor actor);

    public delegate void ActorEndTurnEvent(IActor actor);

    public delegate void ActorSelectedEvent(IActor current, IActor previous);

    public delegate void BattleStartEvent();

    public interface IBattle {

        event ActorBeginTurnEvent ActorBeginTurnEvent;
        event ActorEndTurnEvent ActorEndTurnEvent;
        event ActorSelectedEvent ActorSelectedEvent;
        event BattleStartEvent BattleStartEvent;

        IGrid Grid { get; }
        IActionTimeline ActionTimeline { get; }
        IStage Stage { get; }
        IActor ActiveActor { get; }

        void Start();
        bool IsActiveActor(IActor actor);
        bool IsSelectedActor(IActor actor);
        void SelectActor(IActor actor);

        void OnActorEndTurn();

    }

    public class Battle : IBattle {

        public event ActorBeginTurnEvent ActorBeginTurnEvent;
        public event ActorEndTurnEvent ActorEndTurnEvent;
        public event ActorSelectedEvent ActorSelectedEvent;
        public event BattleStartEvent BattleStartEvent;

        private IActor selectedActor = null;

        public Battle(IStage stage, IGrid grid, IActionTimeline actionTimeline) {
            Debug.Log("Initializing battle");
            Stage = stage;
            Grid = grid;
            ActionTimeline = actionTimeline;
            AddActorsToTimeline();
        }

        public IActionTimeline ActionTimeline { get; private set; }
        public IStage Stage { get; private set; }
        public IActor ActiveActor { get; private set; }
        public IGrid Grid { get; private set; }

        public void Start() {
            Debug.Log("Battle starts!");
            //activeActor = ActionQueue.Unqueue();
            //if (BattleStartEvent != null) BattleStartEvent();
            //if (ActorBeginTurnEvent != null) ActorBeginTurnEvent(activeActor);
            //activeActor.BeginTurn();
        }

        public bool IsActiveActor(IActor actor) {
            return actor == ActiveActor;
        }

        public bool IsSelectedActor(IActor actor) {
            return actor == selectedActor;
        }

        public void SelectActor(IActor actor) {
            Debug.Log(actor.Name + "selected");
            if (ActorSelectedEvent != null) ActorSelectedEvent(actor, selectedActor);
        }

        public void OnActorEndTurn() {
            if (ActorEndTurnEvent != null) ActorEndTurnEvent(ActiveActor);
            ActionTimeline.Put(ActiveActor);
            ActiveActor = ActionTimeline.Unqueue();
            if (ActorBeginTurnEvent != null) ActorBeginTurnEvent(ActiveActor);
            ActiveActor.BeginTurn();
        }

        private void AddActorsToTimeline() {
            foreach (IActor actor in Stage.GetActors()) ActionTimeline.Put(actor);
        }

    }

}