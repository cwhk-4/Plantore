using UnityEngine;

public class TurnGraph : MonoBehaviour
{
    private GameObject nowAnimal;
    private float scaleX = 1;
    private bool needTurn;

    private int maxScaleX = 1;
    private int minScaleX = -1;

    private void Start( )
    {
        nowAnimal = this.gameObject;
    }
    void Update( )
    {
        turn( );
        getAnimalType( );
    }

    private void turn( )
    {
        if ( needTurn )
        {
            if ( scaleX > minScaleX )
            {
                scaleX -= 0.02f;
                nowAnimal.transform.localScale = new Vector3( scaleX, 1, 0 );
            }
        }else
        {
            if ( scaleX < maxScaleX )
            {
                scaleX += 0.02f;
                nowAnimal.transform.localScale = new Vector3( scaleX, 1, 0 );
            }
        }
    }

    private void getAnimalType( )
    {
        switch ( this.gameObject.tag )
        {
            case "lion":
                needTurn = LION._lion.needTurn;
                break;
            case "zebra":
                needTurn = ZEBRA._zebra.needTurn;
                break;
            case "giraffe":
                needTurn = GIRAFFE._giraffe.needTurn;
                break;
            case "impala":
                needTurn = IMPALA._impala.needTurn;
                break;
            case "spottedhyena":
                needTurn = SPOTTEDHYENA._spottedhyena.needTurn;
                break;
            case "africanwilddog":
                needTurn = AFRICANWILDDOG._africanwilddog.needTurn;
                break;
            case "bluewildebeest":
                needTurn = BLUEWILDEBEEST._bluewildebeest.needTurn;
                break;
            case "whiterhino":
                needTurn = WHITERHINO._whiterhino.needTurn;
                break;
        }
    }
}
