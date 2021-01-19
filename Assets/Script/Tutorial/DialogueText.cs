using UnityEngine;

public class DialogueText : MonoBehaviour
{
    public static string getDialogue( int dialogueNum )
    {
        string str = null;

        switch( dialogueNum )
        {
            case 1:
            str = "動物箱庭にようこそ!\n\n" +
                    "動物を箱庭に招き入れて自分だけの箱庭を完成させましょう!";
            break;

            case 2:
            str = "動物はエサを求めて箱庭へやってきます\n\n" +
                    "まずはアイテムから草を配置しましょう!";
            break;

            case 3:
            str = "草を選択できたので、実際に箱庭に配置してみましょう!";
            break;

            case 4:
            str = "草が配置できました!\n\n" +
                    "あとは動物が来るのを待ちましょう!";
            break;

            case 5:
            str = "これでシマウマが箱庭に配置されました!\n\n" +
                    "一旦、様子を見てみましょう...";
            break;

            case 6:
            str = "草が枯れてしまい、ライオンも来てしまいました...\n\n" +
                    "このままでは危ないので、枯れ草をどうぐで修繕しましょう!";
            break;

            case 7:
            str = "どうぐになりましたね！\n\n" +
                    "それでは枯れた草を左クリック長押しで修繕しましょう";
            break;

            case 8:
            str = "草を修繕したことで、再びシマウマが集まりました！\n\n" +
                    "ライオンは狩りの成功率が下がったため、\n一旦引いていきます。";
            break;

            case 9:
            str = "かんきょうを置いて、新しい動物を発見して\n" +
                    "はってんさせ、たくさんの動物を発見しましょう！";
            break;
        }

        return str;
    }

}
