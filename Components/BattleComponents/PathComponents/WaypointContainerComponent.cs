using System.Collections.Generic;


namespace Assets.Scripts.Components.BattleComponents.PathComponents {

    public class WaypointContainerComponent : ContainerComponent {

        public void Add(WaypointComponent wp) {
            wp.transform.SetParent(transform);
        }

        public IList<WaypointComponent> GetWaypoints() {
            return GetComponentsInChildren<WaypointComponent>();
        }

        public WaypointComponent GetWaypoint(int i) {
            return transform.GetChild(i).GetComponent<WaypointComponent>();
        }

    }

}