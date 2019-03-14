using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {
  Status s ;

  // Use this for initialization
  void Start() {
    s = GameObject.Find("Status").GetComponent("Status") as Status;
  } // Start()
	
  // Update is called once per frame
  void Update() {} // Update()

  /*
  public string LoadScene( int scene_id ) {
    // Application.LoadLevel(Application.loadedLevel); 是指重新載入此場景,可用於重玩關卡
    // loadedLevel是指當前場景
    // LoadLevel是載入指定的場景
    if ( scene_id == 0 )
      return "Game_01" ;
    else
      return ;
  } // LoadNextScene()*/
  
  public void NewGame()
  {
    GameObject obj = GameObject.Find("System");
    obj.BroadcastMessage ("Reset", 0,SendMessageOptions.RequireReceiver);
   // GameObject s = GameObject.Find("Status");
    //s.SendMessage("New", 0, SendMessageOptions.RequireReceiver);
  }


  public void Quit() {
    Application.Quit() ;
    Debug.Log( "離開遊戲" ) ;
  } // Quit()

  public void LoadData()
  {
    Status s = GameObject.Find("Status").GetComponent("Status") as Status;
    s.Load();
  } // Quit()

} // class LoadScene
