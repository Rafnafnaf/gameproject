using Assets.Scripts.Values;


namespace Assets.Scripts.GameLogic.BattleLogic {

    public interface ICell {

        Coord Coord { get; }
        bool IsOccupied { get; }
        IStageObject Occupant { get; }
        void Place(IStageObject obj);
        void Clear();

    }

    public class Cell : ICell {

        private Coord coord;
        private IStageObject occupant;

        public Cell(Coord coord) {
            this.coord = coord;
        }

        public bool IsOccupied {
            get { return occupant != null; }
        }

        public IStageObject Occupant {
            get { return occupant; }
        }

        public Coord Coord {
            get { return coord; }
        }

        public void Place(IStageObject obj) {
            if (occupant != null) throw new GridCellAlreadyOccupiedException(coord);
            occupant = obj;
        }

        public void Clear() {
            occupant = null;
        }

    }

}