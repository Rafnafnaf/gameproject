using System.Collections.Generic;
using Assets.Scripts.Values;
using UnityEngine;


namespace Assets.Scripts.BattleUI.BattleGrid {

    public interface IGrid {

        ICell this[Coord coord] { get; }

    }

    public class Grid : MonoBehaviour, IGrid {

        public Cell cellPrefab;
        public int Height = 3;
        public int Width = 10;

        private IDictionary<Coord, ICell> cells;


        public ICell this[Coord coord] {
            get { return cells[coord]; }
        }


        private void Awake() {
            cells = new Dictionary<Coord, ICell>();

            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    CreateCell(x, y);
                }
            }
        }


        private void CreateCell(int x, int y) {
            Cell newCell = Instantiate(cellPrefab);
            PlaceCell(newCell, x, y);
        }


        private void PlaceCell(Cell cell, int x, int y) {
            cells[new Coord(x, y)] = cell;
            cell.transform.localPosition = new Vector3(0.5f + x, 0.5f + y, 0);
        }

    }

}