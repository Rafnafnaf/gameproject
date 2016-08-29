using System.Collections.Generic;
using Assets.Scripts.GameLogic.BattleLogic;


namespace Assets.Scripts.GameLogic.ActorLogic {

    public interface IEnemy : IActor {

    }

    public class Enemy : Actor {

        public Enemy(IBattle battle, string name, IActionContainer actionContainer) : base(battle, name, actionContainer) {}

        public override ICollection<Actor> GetOpponents() {
            return Battle.Stage.GetHeroes() as ICollection<Actor>;
        }

        public override ICollection<Actor> GetAllies() {
            return Battle.Stage.GetEnemies() as ICollection<Actor>;
        }

    }

}