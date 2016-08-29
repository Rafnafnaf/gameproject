using Assets.Scripts.GameLogic.BattleLogic;
using Assets.Scripts.Values;
using UnityEngine;


namespace Assets.Scripts.Components.BattleComponents.GridComponents {

    public delegate void ClickEvent(CellComponent cell);

    public delegate void MouseEnterEvent(CellComponent cell);

    public delegate void MouseExitEvent(CellComponent cell);

    public class CellComponent : TransformableComponent, ICell {

        public event ClickEvent ClickEvent;
        public event MouseEnterEvent MouseEnterEvent;
        public event MouseExitEvent MouseExitEvent;

        public bool Highlighted;

        private ICell implementation;

        private SpriteRenderer Image {
            get { return GetComponentInChildren<SpriteRenderer>(); }
        }

        public Vector3 GlobalPosition {
            get { return transform.position; }
        }

        public Coord Coord {
            get { return implementation.Coord; }
        }

        public bool IsOccupied {
            get { return implementation.IsOccupied; }
        }

        public IStageObject Occupant {
            get { return implementation.Occupant; }
        }

        public void Place(IStageObject obj) {
            implementation.Place(obj);
        }

        public void Clear() {
            implementation.Clear();
        }

        public void Initialize(Coord coord, Vector3 position) {
            implementation = new Cell(coord);
            transform.localPosition = position;
            transform.localScale = Vector3.one;
        }

        private void OnMouseUpAsButton() {
            if (ClickEvent != null) ClickEvent(this);
        }

        private void OnMouseEnter() {
            if (MouseEnterEvent != null) MouseEnterEvent(this);
        }

        private void OnMouseExit() {
            if (MouseExitEvent != null) MouseExitEvent(this);
        }

        private void Update() {
            Image.color = Highlighted ? Color.yellow : Color.white;
            Image.transform.localScale = Highlighted ? new Vector3(1.1f, 1.1f, 1) : Vector3.one;
        }

    }

}