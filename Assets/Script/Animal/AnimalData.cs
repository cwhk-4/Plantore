using UnityEngine;

public static class AnimalData
{
    public struct AnimalBase
    {
        public int AnimalType { get; set; }
        public int TargetIndex { get; set; }
        public Vector3 OriginalPos { get; set; }
        public float StartingTime { get; set; }
        public bool CanMove { get; set; }
        public float Speed { get; set; }
    }

}
