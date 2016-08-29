using System.Collections.Generic;
using System.Linq;


namespace Assets.Scripts.GameLogic.ActorLogic {

    public interface IEnemy : IActor {

    }

    public class Enemy : Actor, IEnemy {

        public override void BeginTurn() {
            //var action = GetActions().FirstOrDefault();  
        }

        public override ICollection<IActor> GetOpponents() {
            return Battle.GetHeroes() as ICollection<IActor>;
        }

        public override ICollection<IActor> GetAllies() {
            return Battle.GetEnemies() as ICollection<IActor>;
        }

    }

}