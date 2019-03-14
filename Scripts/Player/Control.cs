using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Control : MonoBehaviour {

  Animator Main_Animator ;             // 宣告控制Player的Animator
  Transform Player ;                   // 宣告Player物件
  [SerializeField] public bool IsBoundary ;
  [SerializeField]
  public bool CanWalk;
  [SerializeField]
  bool CanDown;
  [SerializeField]
  bool CanUp;
  public bool Walk ;                   
    // Jump, Injured ; 
  public float MoveSpeed ;             // 儲存角色移動速度

  [SerializeField]
  UnityEvent GoToKitchen;
  [SerializeField]
  UnityEvent GoToLivingRoom;

  // Use this for initialization
  void Start () {
    
    Player = gameObject.transform ;               // 取得玩家物件本身
    Main_Animator = GetComponent<Animator>() ;    // 取得動畫控制元件
    MoveSpeed = 90f ;                             // 設定移動速度值為10
    IsBoundary = false ;
    CanWalk = true;
    CanUp = true;
    CanDown = true;
  } // Start()
    

  /*
   * Update is called once per frame
   * 偵測鍵盤事件的發生以進行動畫之切換
   * GetKeyDown will happen once when you hit the key
   * GetKey will continue to happen while you are holding the key
   * GetKeyUp happens once when you release key
   */
  void Update () {
    
	// 跟動畫控制器的變數做連結
    Main_Animator.SetBool( "Walk", Walk ) ;
  //  Main_Animator.SetBool( "Jump", Jump ) ;
  //  Main_Animator.SetBool( "Injured", Injured ) ;

    // 按鍵控制-----左
    if ( Input.GetKey( KeyCode.LeftArrow ) && IsBoundary == false && CanWalk ) {
      Player.eulerAngles = Vector3.zero ;                        // 物件水平旋轉180度
      Player.Translate( -MoveSpeed * Time.deltaTime, 0, 0 ) ;    // 物件移動
      Walk = true ;                                              // 開啟Walk動畫
    } // if
      
    // 按鍵控制-----右
    if ( Input.GetKey( KeyCode.RightArrow ) && IsBoundary == false && CanWalk ) {
      Player.eulerAngles = new Vector3( 0, 180, 0 ) ;            // 物件旋轉值歸零
      Player.Translate( -MoveSpeed * Time.deltaTime, 0, 0 ) ;    // 物件移動
      Walk = true ;                                              // 開啟Walk動畫
    } // if

    if (Input.GetKey(KeyCode.UpArrow) && IsBoundary == false && CanWalk && CanUp)
    {
      //Player.eulerAngles = Vector3.zero;                        // 物件水平旋轉180度
      Player.Translate(0, MoveSpeed * Time.deltaTime, 0);    // 物件移動
      Walk = true;                                              // 開啟Walk動畫
    } // if

    if (Input.GetKey(KeyCode.DownArrow) && IsBoundary == false && CanWalk && CanDown)
    {
      //Player.eulerAngles = Vector3.zero;                        // 物件水平旋轉180度
      Player.Translate(0, -MoveSpeed * Time.deltaTime, 0);    // 物件移動
      Walk = true;                                              // 開啟Walk動畫
    } // if

    // 左鍵或右鍵放開,從走路回歸站立
    if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow) ||
        Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
      Walk = false ;
    /*
    // 按鍵控制-----按向上鍵跳躍
    if ( Input.GetKeyDown( KeyCode.UpArrow ) ) {
      // 判斷是否處於跳躍狀態,防止連續跳躍
      if ( Jump == false ) {
        transform.GetComponent<Rigidbody2D>().AddForce( Vector2.up * 1500 ) ;  // 使用Rigidbody增加力的Function增加一向上力矩
        Jump = true ;                                                         // 開啟Jump動畫
      } // if
    } // if
    */
  } // Update()


  /*
   * 判斷碰撞的發生
   * 偵測主角和地板是否發生碰撞
   * 若踩在地上則關閉Jump動畫
   */
  void OnCollisionEnter2D( Collision2D c ) {
    
    // 判斷有沒有碰到地板
    
    if ( c.gameObject.name == "Floor" )
      CanDown = false ;
    if (c.gameObject.name == "Ceiling")
      CanUp = false;

    if (c.gameObject.name == "Lab" || c.gameObject.name == "Living_room" || c.gameObject.name == "Kitchen")
    {
      IsBoundary = true ;     // Jump動畫關閉,就可以再次進行Jump
      Player.Translate( 10, 0, 0 ) ;    // 物件移動
    } // if

    if (c.gameObject.name == "ToKitchen")
      GoToKitchen.Invoke();

    if (c.gameObject.name == "ToLivingRoom")
      GoToLivingRoom.Invoke(); 
    
  } // OnCollisionEnter2D()

  void OnCollisionExit2D(Collision2D c)
  {
    if (c.gameObject.name == "Lab" || c.gameObject.name == "Living_room" || c.gameObject.name == "Kitchen")
      IsBoundary = false ;
    if (c.gameObject.name == "Floor")
      CanDown = true;
    if (c.gameObject.name == "Ceiling")
      CanUp = true; 

  } // OnCollisionExit2D()

  /*
  // 觸發物件時所要執行的動作
  void OnTriggerStay2D( Collider2D c ) {

    // 觸發陷阱
    if ( c.gameObject.tag == "Trap" ) {
      float time = Time.time ;                // 取得現在時間
      if ( Mathf.Abs( time ) % 2 == 0 ) {     // 每次時間的絕對值除以2整除時執行(每兩秒偵測一次)
        print( "中毒了!!" ) ;
        Injured = true ;                      // 開啟中毒動畫
      } // if
    } // if

    // 觸發寶箱
    if ( c.gameObject.name == "TreasuresBox" ) {
      if ( Input.GetKeyDown( KeyCode.UpArrow ) ) {
        Debug.Log( "恭喜你獲得寶藏!" ) ;
        c.gameObject.GetComponent<My_TreasuresBox>().isOpen = true ;
      } // if
    } // if

  } // OnTriggerStay2D()


  // 離開觸發點時所要執行的動作
  void OnTriggerExit2D() {
    
    Injured = false ;

  } // OnTriggerExit2D()
  */
} // class Control