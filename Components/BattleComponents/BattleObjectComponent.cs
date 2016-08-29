using Assets.Scripts.GameLogic.BattleLogic;


namespace Assets.Scripts.Components.BattleComponents {

    public abstract class BattleObjectComponent : BaseComponent {

        protected IBattle Battle {
            get { return GetComponentInParent(typeof(IBattle)) as IBattle; }
        }

    }

}