using UnityEngine;

public class MissionsList : MonoBehaviour
{
	[SerializeField] private SubClass[] Missions = new SubClass[5];

    private void Awake( )
    {
		Missions[0].totalNum = 3;
		Missions[0].MissionText = "どうぶつを3種類みつける";

		Missions[1].totalNum = 3;
		Missions[1].MissionText = "かんきょうを3回おく";

		Missions[2].totalNum = 3;
		Missions[2].MissionText = "かんきょうを3回なおす";

		Missions[3].totalNum = 2;
		Missions[3].MissionText = "シロサイ,カバをみつける";

		Missions[4].totalNum = 1;
		Missions[4].MissionText = "肉食動物が草食動物を狩る";

		//caution
        //Missions[5].totalNum = 1;
        //Missions[5].MissionText = "イベントをクリアする";
    }

    public void SetValue( int index, SubClass subClass )
	{
		Missions[index] = subClass;
	}

	public SubClass GetValue( int index )
	{
		return Missions[index];
	}
}

[System.Serializable]
public class SubClass
{
	public int totalNum;
	public string MissionText;
}