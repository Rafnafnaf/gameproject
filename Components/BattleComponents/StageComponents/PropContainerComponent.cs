using Assets.Scripts.GameLogic.BattleLogic;
using UnityEngine;


namespace Assets.Scripts.Components.BattleComponents.StageComponents {

    public class PropContainerComponent : MonoBehaviour {

        public IProp[] GetProps() {
            return GetComponentsInChildren(typeof(IProp)) as IProp[];
        }

        public void Add(IProp prop) {
            ((PropComponent) prop).transform.SetParent(transform);
        }

    }

}