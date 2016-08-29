using System.Collections.Generic;
using Assets.Scripts.Components.BattleComponents.PathComponents;
using Assets.Scripts.GameLogic.BattleLogic;
using Assets.Scripts.Values;
using UnityEngine;


namespace Assets.Scripts.Components.BattleComponents.GridComponents {

    public class GridComponent : BattleObjectComponent, IGrid {

        public CellComponent CellPrefab;

        public int Height = 3;
        public int Width = 10;
        private Grid implementation;

        private CellContainerComponent CellContainer {
            get { return GetComponentInChildren<CellContainerComponent>(); }
        }

        private PathComponent Path {
            get { return GetComponentInChildren<PathComponent>(); }
        }

        public bool IsCellOccupied(Coord coord) {
            return implementation.IsCellOccupied(coord);
        }

        public Coord GetCoordOf(IStageObject obj) {
            return implementation.GetCoordOf(obj);
        }

        public void Place(Coord coord, IStageObject obj) {
            implementation.Place(coord, obj);
        }

        public void Remove(IStageObject obj) {
            implementation.Remove(obj);
        }

        public void Move(IStageObject obj, Coord newCoord) {
            implementation.Move(obj, newCoord);
        }

        public IEnumerable<ICell> Cells {
            get { return implementation.Cells; }
        }

        public ICell GetCell(Coord coord) {
            return implementation.GetCell(coord);
        }

        protected override void Awake() {
            var cells = new List<ICell>();

            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    CellComponent cell = Instantiate(CellPrefab);
                    CellContainer.Add(cell);
                    cells.Add(cell);

                    Coord coord = new Coord(x, y);
                    Vector3 position = new Vector3(0.5f + x, 0.5f + y, 0);
                    cell.Initialize(coord, position);

                    cell.ClickEvent += OnClickCell;
                    cell.MouseEnterEvent += OnMouseEnterCell;
                    cell.MouseExitEvent += OnMouseExitCell;
                }
            }

            implementation = new Grid(cells);
        }

        private void OnClickCell(CellComponent cell) {
            Path.AddWaypoint(cell.GlobalPosition);
        }

        private void OnMouseEnterCell(CellComponent cell) {
            cell.Highlighted = true;
        }

        private void OnMouseExitCell(CellComponent cell) {
            cell.Highlighted = false;
        }

    }

}