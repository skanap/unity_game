using UnityEngine;
using System.Collections;

public class TriggerOnElevator : MonoBehaviour {

  public GameObject Prompt;         // Prompt(提示),取得電梯按鍵視窗物件
  public SpriteRenderer sprite;     // 取得Up物件SpriteRenderer屬性,對材質中的Alpha值作設定
  public GameObject ToOneFloor;     // 是否去1F的詢問視窗

  public bool Up_Active = false;    // 判斷Up是否被觸發
  public float Alpha = 0.0f;        // 淡出淡入的設定值

  float a = -0.01f;                 // a為透明度的變化速度
  public bool isUp;                 // 判斷電梯的觸發
  bool isOnTrigger;




  /* Awake比Start早一步執行(開始遊戲的一瞬間就已經做好Awake裡的事情)
   * 若Awake Function中的物件並非處於繳活狀態,Start就不會執行
   * 於此用來抓取Up物件,並將Up物件隱藏起來
   * 遊戲一開始看不到Up物件
   */
  void Awake()
  {
    Prompt.gameObject.SetActive(Up_Active);         // 將Up物件的繳活狀態改為關閉(false)
    sprite = Prompt.GetComponent<SpriteRenderer>();   // 抓取Up物件的SpriteRenderer元件
    ToOneFloor.SetActive(false);
    isOnTrigger = false;

  } // Awake()


  void Start()
  {

  }


  // Update is called once per frame
  /* 判斷寶箱是否有被開啟
   * 若被開啟 -> 顯示寶箱開啟的圖片 & 關閉Up物件
   * 沒被開啟 & Up物件被繳活 -> Alpha跟a不斷相加或相減並重新指定給color進行透明度的變更
   * Alpha數值範圍介於0.0f ~ 1.0f之間  [浮點數]
   * 當Alpha值大於1.0f時 -> a值設為-0.01f
   * 當Alpha值小於1.0f時 -> a值設為+0.01f
   * 使Alpha值永遠介於0.0f ~ 1.0f之間,達到淡出淡入的效果
   */
  void Update()
  {

    if (isOnTrigger && Application.loadedLevelName == "Game_01" && Input.GetKey(KeyCode.E))
    {
      isUp = true;
      ToOneFloor.SetActive(true);
      Prompt.gameObject.SetActive(false);
    } // if

    else if (isOnTrigger && Application.loadedLevelName == "Game_02" && Input.GetKey(KeyCode.E))
    {
      isUp = true;
      ToOneFloor.SetActive(true);
      Prompt.gameObject.SetActive(false);
    } // if

    else
    {
      // 如果Up物件繳活的話執行
      if (Up_Active)
      {
        Alpha = Alpha + a;                                        // 讓Alpha值不斷改變
        sprite.material.color = new Color(1f, 1f, 1f, Alpha);   // 取代材質原本的color
        
        if (Alpha >= 1.0f)
          a = -0.01f;
        if (Alpha <= 0.0f)
          a = 0.01f;
        
      } // if
    } // else

  } // Update()




  // 當Player與電梯發生碰撞時,將Up物件繳活
  void OnTriggerEnter2D(Collider2D c)
  {
    if (c.gameObject.name == "Player")
    {
      isOnTrigger = true;
      Up_Active = true;
      Prompt.gameObject.SetActive(Up_Active);
    } // if

  } // OnTriggerEnter2D()


  // 當Player離開電梯的碰撞範圍時,將Up物件關閉
  // 並將Alpha值歸零,確保每次觸發都是先淡入再淡出,不會隨意更動
  void OnTriggerExit2D(Collider2D c)
  {

    if (c.gameObject.name == "Player")
    {
      Up_Active = false;
      isOnTrigger = false;
      Prompt.gameObject.SetActive(Up_Active);
      Alpha = 0.0f;
    } // if

  } // OnTriggerExit2D()

}
