using Assets.Scripts.GameLogic.ActorLogic;
using UnityEngine;


namespace Assets.Scripts.GameLogic.ActionLogic {

    public delegate void ActionAnimationCompleteHandler();

    public abstract class ActionAnimationController : MonoBehaviour {

        public event ActionAnimationCompleteHandler CompleteEvent;


        protected Actor Actor {
            get { return GetComponentInParent<Actor>(); }
        }

        public abstract void Trigger();


        protected void AnimationComplete() {
            if (CompleteEvent != null)
                CompleteEvent();
        }

    }

}