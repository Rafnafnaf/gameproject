using UnityEngine;


namespace Assets.Scripts.Components.BattleComponents.PathComponents {

    public class WaypointComponent : MonoBehaviour {

        public Vector3 GlobalPosition {
            get { return transform.position; }
        }

        public void Initialize(Vector3 globalPosition) {
            transform.position = globalPosition;
        }

    }

}