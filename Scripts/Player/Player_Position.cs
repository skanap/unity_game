using UnityEngine;
using System.Collections;

public class Player_Position : MonoBehaviour {
  Transform player_t;

  void Awake()
  {
    player_t = gameObject.transform;
  }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}


  public void TwoToOne()
  {
    GameObject obj = GameObject.Find("Status");
    obj.SendMessage("ChangePosition","Game_02");   // 發出呼叫的場景
  }

  public void OneToTwo()
  {
    GameObject obj = GameObject.Find("Status");
    obj.SendMessage("ChangePosition", "Game_01");   // 發出呼叫的場景
  }


  public void ThreeToTwo()
  {
    GameObject obj = GameObject.Find("Status");
    obj.SendMessage("ChangePosition", "Game_03");   // 發出呼叫的場景
  }


}
