using UnityEngine;

public class TimeController : MonoBehaviour
{
    [SerializeField] private float Sec;
    [SerializeField] private float Min;
    [SerializeField] private int Period;

    [SerializeField] private float SecToMin = 60;
    [SerializeField] private float NumOfPeriod = ( int )Define.PERIOD.MAX;

    private void Awake( )
    {
        NumOfPeriod = ( int )Define.PERIOD.MAX;
        Sec = 0;
    }

    private void FixedUpdate()
    {
        Sec += Time.deltaTime;
        Min = Sec / SecToMin;
        Period = ( int )( Min % NumOfPeriod );
    }

    public float GetNowSec( )
    {
        return Sec;
    }

    public int GetNowPeriod( )
    {
        return Period;
    }

    public void loadNowSec( float secLoad )
    {
        Sec = secLoad;
    }

}
