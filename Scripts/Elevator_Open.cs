using UnityEngine;
using System.Collections;

public class Elevator_Open : MonoBehaviour {
  [SerializeField]
  bool isOpen;
  [SerializeField]
  Animator e_up, e_door, e_btn; // 電梯的樓層顯示面板, 門, 按鈕

  [SerializeField]
  GameObject Player;
  [SerializeField]
  Transform Player_t;

	// Use this for initialization
	void Start () {
    e_up = GameObject.Find("elevator_SC_0").GetComponent<Animator>();
    e_door = GameObject.Find("elevator_door").GetComponent<Animator>();
    e_btn = GameObject.Find("elevator_button").GetComponent<Animator>();
    isOpen = false;

    Player = GameObject.Find("Player");
    Player_t = Player.transform;
  }
	
	// Update is called once per frame
	void Update () {
    e_up.SetBool("Open", isOpen);
    e_door.SetBool("Open", isOpen);
    e_btn.SetBool("Open", isOpen);
	}

  void EIsOpen(string scene) {
    isOpen = true;
    if(scene == "Game_01") Player_t.position = new Vector3(200, -25, 0);
    StartCoroutine(Open());
  }

  IEnumerator Open()
  {
    //Player.SetActive(false);
    //isOpen = true;
    //yield return new WaitForSeconds(0.2f);
    //Player.SetActive(true);
   // Player_t.position = new Vector3(200, -25, 0);
    yield return new WaitForSeconds(1.2f);
    isOpen = false;
    yield return null;
  }

}
