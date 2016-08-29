using UnityEngine;


namespace Assets.Scripts.Components {

    public class ContainerComponent : MonoBehaviour {

        public int Count {
            get { return transform.childCount; }
        }

        public void Clear() {
            while (Count > 0) {
                DestroyLastChild();
            }
        }

        private void DestroyLastChild() {
            DestroyChild(transform.GetChild(Count - 1));
        }

        private void DestroyChild(Transform child) {
            child.transform.SetParent(null);
            Destroy(child.gameObject);
        }

    }

}