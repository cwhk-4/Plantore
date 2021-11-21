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
	[SerializeField] private SubClass[] Missions = new SubClass[9];

	private readonly string[] MissionClearText =
		{ "草、木、岩が1つふえました！\n草原、沼がついかされました！\nマップが広くなりました！",
		  "草、木、岩、草原、沼が1つふえました！\n稲穂生える草原、大岩がついかされました！\nマップが広くなりました！",
		  "草、木、岩、草原、沼、\n稲穂生える草原、大岩が1つふえました！\n湖、岩群がついかされました！\nマップが広くなりました！"};

    private void Awake( )
    {
        #region MissionTextInitialize
        //lv1
        Missions[0].totalNum = 3;
		Missions[0].MissionText = "かんきょうを3つおく";
		Missions[0].level = 1;

		Missions[1].totalNum = 5;
		Missions[1].MissionText = "かんきょうを5かいなおす";
		Missions[1].level = 1;

		Missions[2].totalNum = 1;
		Missions[2].MissionText = "ずかんをみる";
		Missions[2].level = 1;

		//lv2
		Missions[3].totalNum = 1;
		Missions[3].MissionText = "ゾウかサイをみつける";
		Missions[3].level = 2;

		Missions[4].totalNum = 3;
		Missions[4].MissionText = "ライオンが\"かり\"を3かいする";
		Missions[4].level = 2;

		Missions[5].totalNum = 15;
        Missions[5].MissionText = "かんきょうを15かいなおす";
		Missions[5].level = 2;

		//lv3
        Missions[6].totalNum = 10;
		Missions[6].MissionText = "そうしょくどうぶつをみつける";
		Missions[6].level = 3;

		Missions[7].totalNum = 10;
		Missions[7].MissionText = "どうぶつどうしがあらそう";
		Missions[7].level = 3;

		Missions[8].totalNum = 8;
		Missions[8].MissionText = "ずかんをうめる";
		Missions[8].level = 3;

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