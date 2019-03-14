using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Typewriter : MonoBehaviour {

  public Text text;
  private float letterPause = 0.2f;
  public int sentencePause = 1;
  public GameObject next_btn_1, next_btn_2, fin_btn;
  public AudioSource a;
  public bool isSkip;
  // 例句
  private string sentence = "這是個發生在2025年的故事\n那時候的社會因科技發達而研發出了機器人\n它們不只是為生活帶來便利性的工具\n更擁有人工智慧能與人相處、共事";
  private string sentence_2 = "紀宇文是陪伴型機器人的發明者\n因常年專注於工作\n導致夫妻失和、妻子離家\n於是帶回一個機器人讓它照顧年幼的孩子們";
  private string sentence_3 = "\n當機器人開始參與人類的生活時\n會發生什麼樣的故事呢......";
  // 初始化
  void Start() {
    StartCoroutine(Delay(sentence));
    a.Stop();
    isSkip = false;
  }


  // 每句話停頓點
  IEnumerator Delay(string str) {
    //yield return new WaitForSeconds(sentencePause);
    yield return StartCoroutine(TypeText(str));
  }

  // 打字機效果
  IEnumerator TypeText(string str) {
    string original = "";
    foreach (var word in str) {
      a.Play();
      text.text = original;
      text.text += word;
      text.text += "_";
      original += word;
      if (isSkip) {
        a.Stop();
        break;
      } 
      if(!isSkip)yield return new WaitForSeconds(letterPause);
      a.Stop();
    }

    text.text = str;
    yield return new WaitForSeconds(letterPause+0.5f);
    if( str == sentence_3 )fin_btn.SetActive(true);
    else if (str == sentence)next_btn_1.SetActive(true);
    else if (str == sentence_2) next_btn_2.SetActive(true);
  }


  public void Next(int i)
  {
    isSkip = false;
    next_btn_1.SetActive(false);
    next_btn_2.SetActive(false);
    if(i==2)
      StartCoroutine(Delay(sentence_2));
    else StartCoroutine(Delay(sentence_3));
  }

  public void Skip()
  {
    isSkip = true; 
  }

}
