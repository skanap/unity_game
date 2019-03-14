using UnityEngine;
using System.Collections;

public class ClickIcon : MonoBehaviour {

  public GameObject oMission ;
  public GameObject oBackpack ;
  [SerializeField] int t_count;
  private bool IsOpen = false ;


  void Awake() {
    oMission = GameObject.Find( "Mission2" ) ;
    oMission.gameObject.SetActive( IsOpen ) ;
  } // Awake()


	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
  void Update() {
    oMission.gameObject.SetActive( IsOpen ) ;
  /*  
    if (IsOpen /*&& t.GetNow().Count != t_count)
    {
      Debug.Log("fdf"+t.GetNow().Count+" " + Time.time);
      t_script = btn_manager.GetComponent("TaskButtonManager") as TaskButtonManager;
      Debug.Log("ddd" + t.GetNow().Count + " " + Time.time);
      t_script.ChangeTaskButton(t.GetNow());
      Debug.Log("dfffd" + t.GetNow().Count + " " + Time.time);
      //t_count = t.GetNow().Count;
    }*/
  } // Update()

  public void Click() {
    if ( IsOpen == false ) IsOpen = true ;
    else IsOpen = false ;
  } // Click
    

}
