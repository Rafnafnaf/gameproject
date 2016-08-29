using System.Collections.Generic;
using Assets.Scripts.GameLogic.BattleLogic;


namespace Assets.Scripts.GameLogic.ActorLogic {

    public interface IHero : IActor {

    }

    public class Hero : Actor {

        public Hero(IBattle battle, string name, IActionContainer actionContainer) : base(battle, name, actionContainer) {}

        public override void BeginTurn() {
            base.BeginTurn();
        }

        public override ICollection<Actor> GetOpponents() {
            return Battle.Stage.GetEnemies() as ICollection<Actor>;
        }

        public override ICollection<Actor> GetAllies() {
            return Battle.Stage.GetHeroes() as ICollection<Actor>;
        }

        private void OnActionConfirmed() {}

    }

}