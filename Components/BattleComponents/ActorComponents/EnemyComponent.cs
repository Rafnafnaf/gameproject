using Assets.Scripts.GameLogic.ActorLogic;


namespace Assets.Scripts.Components.BattleComponents.ActorComponents {

    public class EnemyComponent : ActorComponent, IEnemy {

        protected IEnemy Implementation {
            get { return implementation as IEnemy; }
        }

        protected override void Awake() {
            implementation = new Enemy(Battle, name, ActionContainer);
        }

    }

}