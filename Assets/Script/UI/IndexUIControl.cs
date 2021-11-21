﻿using UnityEngine;
using UnityEngine.UI;

public class IndexUIControl : MonoBehaviour
{
    [SerializeField] private GameObject IndexUI;
    [SerializeField] private GameObject IndexContent;
    [SerializeField] private MissionControl MissionControl;
    [SerializeField] private GameObject[] AnimalButton = new GameObject[( int )Define.ANIMAL.TOTAL_NUM];
    [SerializeField] private Sprite[] AnimalIndex = new Sprite[( int )Define.ANIMAL.TOTAL_NUM];

    void Start( )
    {
        InitAnimalButton( );
        CloseIndexUI( );
        CloseContent( );
    }

    public void CloseIndexUI( )
    {
        CloseContent( );
        IndexUI.SetActive( false );
        Time.timeScale = 1;
    }

    public void OpenIndexUI( )
    {
        CheckAnimal( );

        IndexUI.SetActive( true );
        Time.timeScale = 0;
    }

    private void InitAnimalButton( )
    {
        for( int i = 0; i < ( int )Define.ANIMAL.TOTAL_NUM; i++ )
        {
            AnimalButton[i].SetActive( false );
        }
    }

    private void CheckAnimal( )
    {
        for( int i = 0; i < ( int )Define.ANIMAL.TOTAL_NUM; i++ )
        {
            bool flag = MissionControl.GetAnimalFound( i );
            AnimalButton[i].SetActive( flag );
        }
    }

    public void CloseContent( )
    {
        IndexContent.SetActive( false );
    }

    public void OpenContent( )
    {
        IndexContent.SetActive( true );
    }

    public void AnimalClicked( int index )
    {
        IndexContent.GetComponent<Image>( ).sprite = AnimalIndex[index];
        OpenContent( );
    }
}
