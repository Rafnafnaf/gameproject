using System.Collections.Generic;
using Assets.Scripts.BattleUI.UIGrid;
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

        ICollection<IActor> GetActors();
        ICollection<IEnemy> GetEnemies();
        ICollection<IHero> GetHeroes();
        bool IsActiveActor(IActor actor);
        bool IsSelectedActor(IActor actor);
        void SelectActor(IActor actor);
        void OnActorEndTurn();

    }

    public class Battle : MonoBehaviour, IBattle {

        public event ActorBeginTurnEvent ActorBeginTurnEvent;
        public event ActorEndTurnEvent ActorEndTurnEvent;
        public event ActorSelectedEvent ActorSelectedEvent;
        public event BattleStartEvent BattleStartEvent;

        private ActorQueue actorQueue = null;
        private IActor activeActor;
        private IActor selectedActor = null;

        public ICollection<IActor> GetActors() {
            return GetComponentsInChildren(typeof(IActor)) as ICollection<IActor>;
        }

        public ICollection<IEnemy> GetEnemies() {
            return GetComponentsInChildren(typeof(IEnemy)) as ICollection<IEnemy>;
        }

        public ICollection<IHero> GetHeroes() {
            return GetComponentsInChildren(typeof(IHero)) as ICollection<IHero>;
        }

        public IGrid Grid {
            get { return GetComponentInChildren(typeof(IGrid)) as IGrid; }
        }

        public bool IsActiveActor(IActor actor) {
            return actor == activeActor;
        }

        public bool IsSelectedActor(IActor actor) {
            return actor == selectedActor;
        }

        public void SelectActor(IActor actor) {
            Debug.Log(actor.Name + "selected");
            if (ActorSelectedEvent != null) ActorSelectedEvent(actor, selectedActor);
        }

        public void OnActorEndTurn() {
            if (ActorEndTurnEvent != null) ActorEndTurnEvent(activeActor);
            actorQueue.Put(activeActor);
            activeActor = actorQueue.Unqueue();
            if (ActorBeginTurnEvent != null) ActorBeginTurnEvent(activeActor);
            activeActor.BeginTurn();
        }

        private void Awake() {
            Debug.Log("Initializing battle");
            AddActorsToQueue();
        }

        private void AddActorsToQueue() {
            foreach (IActor actor in GetActors()) actorQueue.Put(actor);
        }

        private void Start() {
            Debug.Log("Battle starts!");
            activeActor = actorQueue.Unqueue();
            if (BattleStartEvent != null) BattleStartEvent();
            if (ActorBeginTurnEvent != null) ActorBeginTurnEvent(activeActor);
            activeActor.BeginTurn();
        }

    }

    public class ActorQueue {

        private List<IActor> queue;

        public ActorQueue() {
            queue = new List<IActor>();
        }

        public void Put(IActor actor) {
            if (queue.Count == 0) {
                queue.Add(actor);
                return;
            }

            int index = CalculateIndex(actor);
            queue.Insert(index, actor);
        }

        public IActor Unqueue() {
            IActor result = queue[0];
            queue.RemoveAt(0);
            return result;
        }

        public int CalculateIndex(IActor actor) {
            for (int i = 0; i < queue.Count; i++) {
                if (actor.ActionRank > queue[i].ActionRank) return i;
            }
            return queue.Count;
        }

    }

}