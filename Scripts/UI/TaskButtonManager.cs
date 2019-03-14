using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TaskButtonManager : MonoBehaviour {
  public GameObject sample ;
  public GameObject super ;
  public GameObject task ;
  public GameObject BN ;
  private int y = 0 ;
  private int ID = 1 ;

  [SerializeField] List<GameObject> btn;

  public TaskSystem ts;


	// Use this for initialization
	void Start () {
    //ts = new TaskSystem();
	}
	
	// Update is called once per frame
  void Update () {
  } // Update


  public void ChangeTaskButton( List<Task> now ) {
    /*
    for( int i = 1 ; i < super.transform.GetChildCount() ; i++ ){
      Destroy(super.transform.GetChild(i));
    }*/

   // Destroy(GameObject.Find("Sample(Clone)"));
    foreach( Task temp in now ) {
      task = Instantiate<GameObject>(sample);
      task.gameObject.SetActive(true);
      task.transform.SetParent(super.transform);
      task.transform.localPosition = new Vector3(0, y, 0);
      task.transform.localScale = new Vector3(1, 1, 1);
      string str = temp.name;
      Debug.Log(str);
      Text t = task.transform.GetChild(0).gameObject.GetComponent<Text>();
      t.text = str;
      y -= 30;
    }

  }





  /*
  public void Test(string name)
  {

    task = Instantiate<GameObject>(sample);
    task.gameObject.SetActive(true);
    task.transform.SetParent(super.transform);
    task.transform.localPosition = new Vector3(92, -y, 0);
    task.transform.localScale = new Vector3(1, 1, 1);
    string str = name;
    Debug.Log(str);
    Text t = task.transform.GetChild(0).gameObject.GetComponent<Text>();
    t.text = str;
    y += 30;
  }
  */
}
