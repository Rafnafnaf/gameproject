using System.Collections.Generic;
using Assets.Scripts.GameLogic.ActorLogic;


namespace Assets.Scripts.GameLogic.BattleLogic {

    public interface IStage {

        IList<IActor> GetActors();
        IList<IEnemy> GetEnemies();
        IList<IHero> GetHeroes();
        IProp[] GetProps();
        IStageObject[] GetStageObjects();

        void Add(IActor actor);
        void Add(IProp prop);

    }

}