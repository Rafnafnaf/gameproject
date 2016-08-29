using System;
using System.Collections.Generic;
using Assets.Scripts.Values;
using UnityEngine;


namespace Assets.Scripts.GameLogic.BattleLogic {

    public interface IGrid {

        IEnumerable<ICell> Cells { get; }
        ICell GetCell(Coord coord);
        bool IsCellOccupied(Coord coord);
        Coord GetCoordOf(IStageObject obj);
        void Place(Coord coord, IStageObject obj);
        void Remove(IStageObject obj);
        void Move(IStageObject obj, Coord newCoord);

    }

    public class Grid : IGrid {

        private IDictionary<Coord, ICell> cells;
        private IDictionary<IStageObject, Coord> coordMap;

        public Grid(List<ICell> cells) {
            this.cells = new Dictionary<Coord, ICell>();
            coordMap = new Dictionary<IStageObject, Coord>();
            
            foreach (ICell cell in cells) {
                this.cells[cell.Coord] = cell;
            }
        }

        public ICell this[Coord coord] {
            get {
                ValidateCoord(coord);
                return cells[coord];
            }
        }

        public Coord GetCoordOf(IStageObject obj) {
            ValidateContains(obj);
            return coordMap[obj];
        }

        public void Place(Coord coord, IStageObject obj) {
            ValidateCoord(coord);
            cells[coord].Place(obj);
        }

        public void Remove(IStageObject obj) {
            ValidateContains(obj);
            Coord coord = coordMap[obj];
            ICell cell = cells[coord];
            coordMap.Remove(obj);
            cell.Clear();
        }

        public void Move(IStageObject obj, Coord newCoord) {
            Remove(obj);
            Place(newCoord, obj);
        }

        public IEnumerable<ICell> Cells {
            get { return cells.Values; }
        }

        public ICell GetCell(Coord coord) {
            ValidateCoord(coord);
            return cells[coord];
        }

        public bool IsCellOccupied(Coord coord) {
            ValidateCoord(coord);
            return cells[coord].IsOccupied;
        }

        private void ValidateCoord(Coord coord) {
            if (!IsValid(coord)) throw new InvalidGridCoordException(coord);
        }

        private void ValidateContains(IStageObject obj) {
            if (!Contains(obj)) throw new StageObjectCoordNotFoundException(obj);
        }

        private bool Contains(IStageObject obj) {
            return coordMap.ContainsKey(obj);
        }

        private bool IsValid(Coord coord) {
            return cells.ContainsKey(coord);
        }

    }

    public class GridCellAlreadyOccupiedException : Exception {

        public GridCellAlreadyOccupiedException(Coord coord) : base(coord.ToString()) {}

    }

    public class InvalidGridCoordException : Exception {

        public InvalidGridCoordException(Coord coord) : base(coord.ToString()) {}

    }

    public class StageObjectCoordNotFoundException : Exception {

        public StageObjectCoordNotFoundException(IStageObject obj) : base(obj.ToString()) {}

    }

}