using UnityEngine;


namespace Assets.Scripts.Components.BattleComponents.PathComponents {

    public class SegmentComponent : MonoBehaviour {

        public void Initialize(Vector3 origin, Vector3 end) {
            var angle = Vector3.Angle(Vector3.right, end - origin);
            var length = Vector3.Distance(origin, end);
            transform.localScale = new Vector3(length, 1, 1);
            transform.localEulerAngles = new Vector3(0, 0, angle);
        }

    }

}