using System.Collections;
using UnityEngine;


namespace Assets.Scripts.GameLogic.ActionLogic {

    public class AttackAnimationController : ActionAnimationController {

        [SerializeField] private float speed = 0.3f;
        [SerializeField] private float distance = 2;


        public override void Trigger() {
            StartCoroutine(MoveForward());
        }


        private void OnMoveForwardComplete() {
            StartCoroutine(MoveBack());
        }


        private void OnMoveBackComplete() {
            AnimationComplete();
        }


        private IEnumerator MoveForward() {
            float currentDistance = 0;

            while (currentDistance < distance) {
                Actor.transform.localPosition += Vector3.right * speed * Time.deltaTime;
                currentDistance += speed*Time.deltaTime;
                yield return null;
            }

            OnMoveForwardComplete();
        }


        private IEnumerator MoveBack() {
            float currentDistance = 0;

            while (currentDistance < distance)
            {
                Actor.transform.localPosition += Vector3.left * speed * Time.deltaTime;
                currentDistance += speed * Time.deltaTime;
                yield return null;
            }

            OnMoveBackComplete();
        }

    }

}