using Assets.Scripts.Components.BattleComponents.ActorComponents;
using UnityEngine;


namespace Assets.Scripts.Components.BattleComponents.PathComponents {

    public class PathComponent : BattleObjectComponent {

        public WaypointComponent WaypointPrefab;
        public SegmentComponent SegmentPrefab;

        private WaypointContainerComponent WaypointContainer {
            get { return GetComponentInChildren<WaypointContainerComponent>(); }
        }

        private SegmentContainerComponent SegmentContainer {
            get { return GetComponentInChildren<SegmentContainerComponent>(); }
        }

        public void AddWaypoint(Vector3 globalPosition) {
            var wp = Instantiate(WaypointPrefab);
            WaypointContainer.Add(wp);

            wp.Initialize(globalPosition);

            var end = globalPosition;
            var origin = Vector3.zero;

            if (WaypointContainer.Count == 1)
                origin = ((ActorComponent) Battle.ActiveActor).GlobalPosition;

            if (WaypointContainer.Count > 1)
                origin = WaypointContainer.GetWaypoint(WaypointContainer.Count - 2).GlobalPosition;

            AddPathSegment(origin, end);
        }

        public void Clear() {
            WaypointContainer.Clear();
            SegmentContainer.Clear();
        }

        private void AddPathSegment(Vector3 origin, Vector3 end) {
            var segment = Instantiate(SegmentPrefab);
            SegmentContainer.Add(segment);
            segment.transform.SetParent(transform);
            segment.Initialize(origin, end);
        }

        protected override void Awake() {}

    }

}