using System.Linq;
using Assets.Scripts.GameLogic.BattleLogic;
using Assets.Scripts.Values;
using UnityEngine;


namespace Assets.Scripts.Components.BattleComponents.StageComponents {

    public abstract class StageObjectComponent : TransformableComponent, IStageObject {

        protected IStageObject implementation;

        protected IBattle Battle {
            get { return (IBattle) GetComponentInParent(typeof(IBattle)); }
        }

        public Coord Coord {
            get { return implementation.Coord; }
        }

        public string Name {
            get { return implementation.Name; }
        }

        private void Start() {
            OccupyClosestCell();
        }

        private void OccupyClosestCell() {
            var position = GlobalPosition;
            ITransformable closestCell = null;
            float closestDistance = 0;
            
            foreach (var cell in Battle.Grid.Cells) {
                var cellPosition = ((ITransformable) cell).GlobalPosition;
                var distance = Vector3.Distance(position, cellPosition);

                if ((closestCell == null || distance < closestDistance) && !cell.IsOccupied) {
                    closestCell = ((ITransformable) cell);
                    closestDistance = distance;
                }
            }

            if (closestCell != null) {
                transform.position = closestCell.GlobalPosition;
                ((ICell) closestCell).Place(this);
            }
        }

    }

}