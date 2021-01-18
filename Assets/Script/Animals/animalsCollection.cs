using UnityEngine;

public class animalsCollection : MonoBehaviour
{
    public struct animalsSystem
    {
        public  GameObject animals;
        public bool canMove;
        public int animalsNUM;
        public int Minus;
        public int predationProbability;
        public int fightProbability;
        public int startPredationProbability;

        public float moveSpeed;
        public float timeToMove;

        public bool canPredation;
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

}