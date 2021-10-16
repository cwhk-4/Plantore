using UnityEngine;

public static class AnimalData
{
    public struct AnimalBase
    {
        public int AnimalType { get; set; }
        public int TargetIndex { get; set; }
        public int TargetType { get; set; }
        public Vector3 OriginalPos { get; set; }
        public float CDStartingTime { get; set; }
        public bool CoolDown { get; set; }
        public bool DecisionMade { get; set; }
        public float Speed { get; set; }
        public int[] Territory { get; set; }
    }

}
