using System.Collections.Generic;
using Assets.Scripts.GameLogic.ActorLogic;
using UnityEngine;


namespace Assets.Scripts.GameLogic.ActionLogic {

    public delegate void ActorActionCompleteHandler();

    public abstract class Action : MonoBehaviour {

        public event ActorActionCompleteHandler CompleteEvent;

        public Sprite Icon;
        public int TimeCost = 100;
        protected Actor actor;
        protected Actor target;
        private ActionAnimationController animationController;

        public bool IsSelectable {
            get { return true; }
        }

        public abstract IActor GetDefaultTarget();

        public abstract ICollection<Actor> GetValidTargets();

        public virtual void Execute(Actor target) {
            this.target = target;
        }

        private void OnAnimationComplete() {
            animationController.CompleteEvent -= OnAnimationComplete;
            Complete();
        }

        protected void Complete() {
            if (CompleteEvent != null)
                CompleteEvent();
        }

        protected void TriggerAnimation() {
            animationController.CompleteEvent += OnAnimationComplete;
            animationController.Trigger();
        }

        private void Awake() {
            actor = GetComponentInParent<Actor>();
            animationController = GetComponent<ActionAnimationController>();
        }

    }

}