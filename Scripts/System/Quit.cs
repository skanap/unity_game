
using UnityEngine;
using System.Collections;

public class Quit : MonoBehaviour {

  public int windowWidth = 400 ;
  public int windowHeight = 150 ;

  Rect windowRect ;
  int windowSwitch = 0 ;
  float alpha = 0 ;


  // 在Start()前準備好
  void Awake() {
    windowRect = new Rect( ( Screen.width - windowWidth ) / 2, ( Screen.height - windowHeight ) / 2, windowWidth, windowHeight ) ;
  } // Awake()


  // Update is called once per frame
  void Update() {

    if ( Input.GetKeyDown( "escape" ) ) {
      windowSwitch = 1 ;
      alpha = 0 ; // 初始化視窗的alpha值
    }

  } // Update()



  void GUIAlphaColor_0_to_1() {
    
    if ( alpha < 1 ) {
      alpha = alpha + Time.deltaTime ;
      GUI.color = new Color( 1, 1, 1, alpha ) ;
    } // if

  } // GUIAlphaColor_0_to_1()



  void OnGUI() {
    
    if ( windowSwitch == 1 ) {
      GUIAlphaColor_0_to_1() ;
      windowRect = GUI.Window( 0, windowRect, QuitWindow, "離開遊戲" ) ;
    } // if

  } // OnGUI()


  void QuitWindow( int windowID ) {
    GUI.Label( new Rect( 155, 50, 300, 30 ), "確定要離開遊戲?" ) ;

    // 當使用者點擊Button時,GUI.Button會回傳true值
    if ( GUI.Button( new Rect( 80, 110, 100, 20 ), "確定" ) ) Application.Quit() ;
    if ( GUI.Button( new Rect( 220, 110, 100, 20 ), "取消" ) ) windowSwitch = 0 ;

    GUI.DragWindow() ;  // 視窗可拖曳
  } // QuitWindow()


}
