using Assets.Scripts.GameLogic.ActorLogic;


namespace Assets.Scripts.Components.BattleComponents.ActorComponents {

    public class HeroComponent : ActorComponent, IHero {

        private IHero Implementation {
            get { return implementation as IHero; }
        }

        protected override void Awake() {
            implementation = new Hero(Battle, name, ActionContainer);
        }

    }

}