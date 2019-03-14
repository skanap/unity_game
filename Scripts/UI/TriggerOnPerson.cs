using UnityEngine;
using System.Collections;

public class TriggerOnPerson : MonoBehaviour {
  public GameObject Prompt;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


  void OnTriggerEnter2D(Collider2D c)
  {
    if (c.gameObject.name == "Player")
    {
      if (gameObject.name == "紀子煬" || gameObject.name == "紀梓潼" || gameObject.name == "紀子煊")
      {
        Status S = GameObject.Find("Status").GetComponent("Status") as Status;
        if(S.Chapter == "Chapter_0") {
          Prompt.gameObject.SetActive(true);
        }
      }
      else Prompt.gameObject.SetActive(true);
    } // if

  } // OnTriggerEnter2D()


  // 當Player離開電梯的碰撞範圍時,將Up物件關閉
  // 並將Alpha值歸零,確保每次觸發都是先淡入再淡出,不會隨意更動
  void OnTriggerExit2D(Collider2D c)
  {

    if (c.gameObject.name == "Player")
    {
      Prompt.gameObject.SetActive(false);
    } // if

  } // OnTriggerExit2D()


}
