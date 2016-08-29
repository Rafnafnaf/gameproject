namespace Assets.Scripts.Components.BattleComponents.PathComponents {

    public class SegmentContainerComponent : ContainerComponent {

        public void Add(SegmentComponent segment) {
            segment.transform.SetParent(transform);
        }

    }

}