using UnityEngine;


namespace Assets.Scripts.Components {

    public class TransformableComponent : BaseComponent, ITransformable {

        public Vector3 GlobalPosition {
            get { return transform.position; }
            set { transform.position = value; }
        }

        public Vector3 LocalPosition {
            get { return transform.localPosition; }
            set { transform.localPosition = value; }
        }

        public Vector3 LocalScale {
            get { return transform.localScale; }
            set { transform.localScale = value; }
        }

        protected override void Awake() {}

    }

}