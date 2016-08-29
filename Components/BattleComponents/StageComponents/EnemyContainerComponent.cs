using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.GameLogic.ActorLogic;
using UnityEngine;


namespace Assets.Scripts.Components.BattleComponents.StageComponents {

    public class EnemyContainerComponent : MonoBehaviour {

        public IList<IEnemy> GetEnemies() {
            return GetComponentsInChildren(typeof(IEnemy)).Cast<IEnemy>().ToList();
        }

        public void Add(IEnemy enemy) {
            ((Component) enemy).transform.SetParent(transform);
        }

    }

}