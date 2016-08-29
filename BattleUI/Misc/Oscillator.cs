using UnityEngine;


namespace Assets.Scripts.UIScripts.Misc {

    public class Oscillator: MonoBehaviour {

        public float Period = 1;

        [Range(0,1)]
        public float Value = 0;

        private float elapsedTime = 0;

        public AnimationCurve Curve;

        private void Update() {
            if (Period == 0) return; 

            elapsedTime += Time.deltaTime;

            if (elapsedTime > Period) elapsedTime -= Period;

            Value = Curve.Evaluate(elapsedTime/Period);
        }
    }

}