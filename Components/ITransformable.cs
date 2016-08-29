using UnityEngine;


namespace Assets.Scripts.Components {

    public interface ITransformable {

        Vector3 GlobalPosition { get; set; }
        Vector3 LocalPosition { get; set; }
        Vector3 LocalScale { get; set; }
    }

}