using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.GameLogic.ActorLogic;
using UnityEngine;


namespace Assets.Scripts.Components.BattleComponents.StageComponents {

    public class HeroContainerComponent : MonoBehaviour {

        public List<IHero> GetHeroes() {
            return GetComponentsInChildren(typeof(IHero)).Cast<IHero>().ToList();
        }

        public void Add(IHero hero) {
            ((Component) hero).transform.SetParent(transform);
        }

    }

}