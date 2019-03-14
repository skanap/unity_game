using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Typewriter2 : MonoBehaviour
{

  public Text text;
  private float letterPause = 0.2f;
  public int sentencePause = 1;
  public GameObject next_btn_1, next_btn_2, fin_btn;
  public AudioSource a;
  public bool isSkip;
  // 例句
  private string sentence = "幾年後...\n發生了一場重大的意外\n機器人的強大超乎人類的預期";
  private string sentence_2 = "這樣的機器人讓人類感到害怕\n他們開始擔心起未來會被機器人改變\n因此開始有群眾提倡廢除機器人的思想";
  private string sentence_3 = "\n機器人未來將會如何......";
  // 初始化
  void Start()
  {
    StartCoroutine(Delay(sentence));
    a.Stop();
    isSkip = false;
  }


  // 每句話停頓點
  IEnumerator Delay(string str)
  {
    //yield return new WaitForSeconds(sentencePause);
    yield return StartCoroutine(TypeText(str));
  }

  // 打字機效果
  IEnumerator TypeText(string str)
  {
    string original = "";
    foreach (var word in str)
    {
      a.Play();
      text.text = original;
      text.text += word;
      text.text += "_";
      original += word;
      if (isSkip)
      {
        a.Stop();
        break;
      }
      if (!isSkip) yield return new WaitForSeconds(letterPause);
      a.Stop();
    }

    text.text = str;
    yield return new WaitForSeconds(letterPause + 0.5f);
    if (str == sentence_3) fin_btn.SetActive(true);
    else if (str == sentence) next_btn_1.SetActive(true);
    else if (str == sentence_2) next_btn_2.SetActive(true);
  }


  public void Next(int i)
  {
    isSkip = false;
    next_btn_1.SetActive(false);
    next_btn_2.SetActive(false);
    if (i == 2)
      StartCoroutine(Delay(sentence_2));
    else StartCoroutine(Delay(sentence_3));
  }

  public void Skip()
  {
    isSkip = true;
  }

}

