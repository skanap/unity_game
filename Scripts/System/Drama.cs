using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drama : MonoBehaviour {
  [SerializeField]
  DialogueSystem DS;
  [SerializeField]
  TaskSystem TS;
  [SerializeField]
  Status S;
  [SerializeField]
  GameObject Father;

  [SerializeField]
  bool Run;

  [SerializeField]
  bool FatherDestroy;


  [SerializeField]
  int nowDiaID;
  [SerializeField]
  int nowTaskID;

  void Awake()
  {
    FatherDestroy = false;
  }

  void OnEnable()
  {
    DS = GameObject.Find("DialogueSystem").GetComponent("DialogueSystem") as DialogueSystem;
    TS = GameObject.Find("TaskSystem").GetComponent("TaskSystem") as TaskSystem;
    S = GameObject.Find("Status").GetComponent("Status") as Status;
    StartCoroutine(Wait1());
  }

  /*
	// Use this for initialization
	void Start () {
    DS = GameObject.Find("DialogueSystem").GetComponent("DialogueSystem") as DialogueSystem;
    TS = GameObject.Find("TaskSystem").GetComponent("TaskSystem") as TaskSystem;
    S = GameObject.Find("Status").GetComponent("Status") as Status;
    StartCoroutine(Wait1());
    //StartCoroutine(Wait2());
    //StartCoroutine(DiaIsFin("Task1",1));
    //StartCoroutine(TaskIsFin(3,1));
    //StartCoroutine(DiaIsFin("Task2",2));
   // StartCoroutine(TaskIsFin(4, 2));
   // StartCoroutine(DiaIsFin("Task3",3));
   // StartCoroutine(TaskIsFin(5, 3));
   // StartCoroutine(DiaIsFin("Task4",4));
    //Debug.Log("1223");
    //TS.GetTask("Task1");

	}*/
	
	// Update is called once per frame
	void Update () {
  //  Debug.Log(nowDiaID + " Dia");
  //  Debug.Log(nowTaskID + " Task");
    if (Application.loadedLevelName == "Game_01" && FatherDestroy)
    {
      Father = GameObject.Find("紀宇文");
      Destroy(Father);
    }
  }



  IEnumerator Wait1(){
    DS.Talking(2, 0, TS.GetFin());
    nowDiaID = 2;
    yield return StartCoroutine(DiaIsFin("Task1", 1));
    yield return StartCoroutine(TaskIsFin(3, 1));
    yield return StartCoroutine(DiaIsFin("Task2", 2));
    yield return StartCoroutine(TaskIsFin(4, 2));
    FatherDestroy = true;
    /*
    Father.transform.position = new Vector3(0, -800, 0);
    CheckClick c = Father.GetComponent("CheckClick") as CheckClick;
    c.isClicked = false;*/
    yield return StartCoroutine(DiaIsFin("Task3", 3));
    yield return StartCoroutine(TaskIsFin(5, 3));
    yield return StartCoroutine(DiaIsFin("Task4",4));
    yield return StartCoroutine(TaskIsFin(6, 4));
    yield return StartCoroutine(DiaIsFin("Task5", 5));
    yield return StartCoroutine(TaskIsFin(7, 5));
    yield return StartCoroutine(DiaIsFin("Task6", 6));
    yield return StartCoroutine(TaskIsFin(8, 6));
    yield return StartCoroutine(IsEnd());
  }

  IEnumerator DiaIsFin(string t_name,int t_ID)
  {
    yield return new WaitUntil(CheckDia);
    TS.GetTask(t_name);
    nowTaskID = t_ID;
  }

  IEnumerator TaskIsFin(int _DiaID, int _TaskID)
  {
    //Debug.Log(CheckTask()+"***");
    yield return new WaitUntil(CheckTask);
    DS.Talking(_DiaID, _TaskID, TS.GetFin());
    nowDiaID = _DiaID;
  }


  IEnumerator IsEnd()
  {
    //Debug.Log(CheckTask() + "***");
    yield return new WaitUntil(CheckTask);
    yield return new WaitForSeconds(3f);
    
    Application.LoadLevel("Accident");
    S.SendMessage("SetChapter", "Chapter_0");
    S.SendMessage("DramaIsEnd", 0, SendMessageOptions.DontRequireReceiver);
  }

  bool CheckDia()
  {
    foreach (int i in DS.GetFin())
    {
      if (i == nowDiaID) return true;
    }
    return false;
  }

  void Reset(int e)
  {
    nowDiaID = -1;
    nowTaskID = -1;
    FatherDestroy = false;
  //  Debug.Log("Drama Reset is OK.");
  }



  bool CheckTask()
  {
    foreach (Task i in TS.GetFin())
    {
    //  Debug.Log("FIN: "+i.name);
      if (i.TaskID == nowTaskID) return true;
    }
    return false;
  }
}
