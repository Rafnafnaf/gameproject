using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.GameLogic.ActorLogic;
using UnityEngine;


namespace Assets.Scripts.Components.BattleComponents.StageComponents {

    public class ActorContainerComponent : MonoBehaviour {

        private EnemyContainerComponent EnemyContainer {
            get { return GetComponentInChildren<EnemyContainerComponent>(); }
        }

        private HeroContainerComponent HeroContainer {
            get { return GetComponentInChildren<HeroContainerComponent>(); }
        }

        public IList<IActor> GetActors() {
            return GetComponentsInChildren(typeof(IActor)).Cast<IActor>().ToList();
        }

        public IList<IEnemy> GetEnemies() {
            return EnemyContainer.GetEnemies();
        }

        public IList<IHero> GetHeroes() {
            return HeroContainer.GetHeroes();
        }

        public void Add(IActor actor) {
            if (actor is IEnemy)
                EnemyContainer.Add((IEnemy) actor);

            if (actor is IHero)
                HeroContainer.Add((IHero) actor);
        }

    }

}