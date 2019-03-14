using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class TaskThings : MonoBehaviour {
  TaskSystem TS;
  GameObject Obj;
  UnityEvent my_Event;
  CheckClick click;
  [SerializeField]
  GameObject Task_Btn;
  [SerializeField]
  GameObject File1;
  [SerializeField]
  GameObject File2;
  [SerializeField]
  GameObject File3;


  [SerializeField]
  GameObject Toy1;
  [SerializeField]
  GameObject Toy2;
  [SerializeField]
  GameObject Toy3;

  [SerializeField]
  GameObject TV_1;
  [SerializeField]
  GameObject TV_2;
  [SerializeField]
  GameObject TV_3;
  [SerializeField]
  GameObject TV_4;
  [SerializeField]
  GameObject TV_F;

  [SerializeField]
  GameObject Train;
  [SerializeField]
  GameObject Ribbon;

  void Awake()
  {
    TS = GameObject.Find("TaskSystem").GetComponent("TaskSystem") as TaskSystem;
  }

	// Use this for initialization
	void Start () {
    //gameObject.SetActive(false);
	}
	
	// Update is called once per frame
  void Update() {
    if (Application.loadedLevelName == "Game_01")
    {
      if (TS.CheckSomeTask(8)) Task_Btn.SetActive(true);
    }

    if (Application.loadedLevelName == "Game_02")
    {
      if (TS.CheckSomeTask(7))
      {
        File1.SetActive(true);
        File2.SetActive(true);
        File3.SetActive(true);
      } // if

      if (TS.CheckSomeTask(12))
      {
        Toy1.SetActive(true);
        Toy2.SetActive(true);
        Toy3.SetActive(true);
      } // if

      if (TS.CheckSomeTask(10))
      {
        TV_1.SetActive(true);
        TV_2.SetActive(true);
        TV_3.SetActive(true);
        TV_4.SetActive(true);
      } // if
      if (TS.CheckSomeTaskFin(10)) TV_F.SetActive(true);
    }

    if (Application.loadedLevelName == "Game_03")
    {
      if (TS.CheckSomeTask(11)) Train.SetActive(true);
      if (TS.CheckSomeTask(9)) Ribbon.SetActive(true);
    }
  }

}
