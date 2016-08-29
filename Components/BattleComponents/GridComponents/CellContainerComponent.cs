using System.Collections.Generic;
using UnityEngine;


namespace Assets.Scripts.Components.BattleComponents.GridComponents {

    public class CellContainerComponent : MonoBehaviour {

        public void Add(CellComponent cell) {
            cell.transform.SetParent(transform);
        }

        public ICollection<CellComponent> GetCells() {
            return GetComponentsInChildren<CellComponent>();
        }

    }

}