using TMPro;
using UnityEngine;

public class MissionControl : MonoBehaviour
{
    [SerializeField] private TMP_Text mission1Num;
    [SerializeField] private TMP_Text mission2Num;
    [SerializeField] private TMP_Text mission3Num;

    [SerializeField] private int AnimalFound = 0;
    [SerializeField] private int ItemPlaced = 0;
    [SerializeField] private int ItemFixed = 0;
    [SerializeField] private int HippoRhinoFound = 0;
    [SerializeField] private int Hunting = 0;

    private int NowStartingMission = 0;

    public void SetNowStartingMission( int num )
    {
        NowStartingMission = num;
    }

    public void PlacedItem( )
    {
        ItemPlaced++;
        if( NowStartingMission == 0 )
        {
            mission2Num.text = ItemPlaced.ToString( );
        }
    }

    public void FixedItem( )
    {
        ItemFixed++;
        if( NowStartingMission == 0 )
        {
            mission3Num.text = ItemFixed.ToString( );
        }
    }
}
