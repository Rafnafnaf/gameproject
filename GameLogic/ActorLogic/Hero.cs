using System.Collections.Generic;
using System.Linq;
using Assets.Scripts.BattleUI.ActionUI;
using Assets.Scripts.GameLogic.ActionLogic;


namespace Assets.Scripts.GameLogic.ActorLogic {

    public interface IHero : IActor {

    }

    public class Hero : Actor, IHero {

        private ActionUIController actionUIContoller;

        public override void BeginTurn() {
            base.BeginTurn();
        }

        public override ICollection<IActor> GetOpponents() {
            return Battle.GetEnemies() as ICollection<IActor>;
        }

        public override ICollection<IActor> GetAllies() {
            return Battle.GetHeroes() as ICollection<IActor>;
        }

        protected Action GetDefaultAction() {
            return GetActions().FirstOrDefault();
        }

        private void OnActionConfirmed() {
            
        }

    }

}