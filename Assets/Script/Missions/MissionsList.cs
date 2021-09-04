using UnityEngine;
using System;

[Serializable]
public class SubClass
{
	public int totalNum;
	public string MissionText;
	public int level;
}

public class MissionsList : MonoBehaviour
{
	[SerializeField]private SubClass[] Missions = new SubClass[10];

	private readonly string[] MissionClearText =
		{ "草、木、岩が1つふえました！\n草原、沼がついかされました！\nマップが広くなりました！",
		  "草、木、岩、草原、沼が1つふえました！\n稲穂生える草原、大岩がついかされました！\nマップが広くなりました！",
		  "草、木、岩、草原、沼、\n稲穂生える草原、大岩が1つふえました！\n湖、岩群がついかされました！\nマップが広くなりました！"};

    private void Awake( )
    {
        #region MissionTextInitialize
        //lv1
        Missions[0].totalNum = 3;
		Missions[0].MissionText = "かんきょうを3コおく";
		Missions[0].level = 1;

		Missions[1].totalNum = 1;
		Missions[1].MissionText = "ずかんをみる";
		Missions[1].level = 1;

		//lv2
		Missions[2].totalNum = 2;
		Missions[2].MissionText = "シロサイ、カバをみつける";
		Missions[2].level = 2;

		Missions[3].totalNum = 5;
		Missions[3].MissionText = "かんきょうを5回なおす";
		Missions[3].level = 2;

		Missions[4].totalNum = 3;
		Missions[4].MissionText = "ライオンが3回狩に成功する";
		Missions[4].level = 2;

		//lv3
		Missions[5].totalNum = 10;
        Missions[5].MissionText = "かんきょうを10回なおす";
		Missions[5].level = 3;

        Missions[6].totalNum = 10;
		Missions[6].MissionText = "草食動物をみつける";
		Missions[6].level = 3;

		Missions[7].totalNum = 10;
		Missions[7].MissionText = "肉食動物が狩に成功する";
		Missions[7].level = 3;

		Missions[8].totalNum = 10;
		Missions[8].MissionText = "アメリカバッファローを10匹みつける";
		Missions[8].level = 3;

		//lv4
		Missions[9].totalNum = 12;
		Missions[9].MissionText = "ずかんを埋める";
		Missions[9].level = 4;
        #endregion
    }

    public void SetValue( int index, SubClass subClass )
	{
		Missions[index] = subClass;
	}

	public SubClass GetValue( int index )
	{
		return Missions[index];
	}

	public int GetTotalNum( int index )
	{
		return Missions[index].totalNum;
	}

	public int GetLevel( int index )
	{
		return Missions[index].level;
	}

	public string GetMissionText( int index )
	{
		return Missions[index].MissionText;
	}

	public string GetMissionClearText( int level )
	{
		return MissionClearText[level - 1];
	}
}