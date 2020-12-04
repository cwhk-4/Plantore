using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class animalsCollection : MonoBehaviour
{

    public static GameObject[ ] animals = new GameObject[ 2 ];

    public struct animalsSystem
    {
        public  GameObject animals;
        public int predationProbability;
        public int fightProbability;
        public int Minus;
        public float timeOut;
        public float startTime;
        public float moveSpeed;
        public bool fightEachOther;
    };
    public static animalsSystem allAnimals = new animalsSystem( );

    //肉食動物
    public enum PREDATOR
    {
        LION,             //ライオン    //狮子
        SPOTTED_HYENA,     //ブチハイエナ//斑点猎犬
        PANTHER,          //ヒョウ      //豹
        AFRICAN_WILDDOG,   //リカオン    //非洲野犬
        NONE,
    };
    public static PREDATOR _predator = PREDATOR.NONE;

    //素食動物
    public enum PREY
    {
        ZEBRA,　　　　　　//シマウマ              //斑马　　　
        GIRAFFE,          //キリン                //长颈鹿
        BLUE_WILDEBEEST,   //オグロヌー            //斑纹角馬
        IMPALA,           //インパラ              //高角羚
        AFRICAN_BUFFALO,   //アフリカバッファロー  //非洲水牛
        HIPPO,            //カバ                  //河馬
        WHITE_RHINO,       //シロサイ              //犀牛
        ELEPHANT,         //ゾウ                  //象
        NONE,
    }
    public static PREY _prey = PREY.NONE;

    void Start( )
    {

    }

    void Update( )
    {

    }

    //void animalsType( )
    //{
    //        switch ( _type )
    //        {
    //            case "LION":
    //                _predator = PREDATOR.LION;
    //                break;
    //            case "ZEBRA":
    //                _prey = PREY.ZEBRA;
    //                break;
    //        }
    //
    //    //PREDATOR
    //    switch ( _predator )
    //    {
    //        case PREDATOR.LION:
    //            thisGame.moveSpeed = 5.0f;
    //            thisGame.animalsTarget[ 0 ] = animals[ 0 ];
    //            break;
    //    }
    //    //PREY
    //    switch( _prey )
    //    {
    //        case PREY.ZEBRA:
    //            thisGame.moveSpeed = 3.0f;
    //            thisGame.animalsTarget[ 1 ] = animals[ 1 ];
    //            break;
    //    }
    //}
}