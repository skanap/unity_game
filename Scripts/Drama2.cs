using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Drama2 : MonoBehaviour
{
  [SerializeField] DialogueSystem DS;
  [SerializeField] TaskSystem TS;
  [SerializeField] Status S;
  [SerializeField] GameObject One;       // 紀子煬
  [SerializeField] GameObject Two;       // 紀梓潼
  [SerializeField] GameObject Three;     // 紀子煊
  [SerializeField] bool OneDestroy;
  [SerializeField] bool TwoDestroy;
  [SerializeField] bool ThreeDestroy;

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
    DS = GameObject.Find("DialogueSystem").GetComponent("DialogueSystem") as DialogueSystem;
    TS = GameObject.Find("TaskSystem").GetComponent("TaskSystem") as TaskSystem;
    S = GameObject.Find("Status").GetComponent("Status") as Status;
  }

  
  void OnEnable()
  {
    OneDestroy = false;
    TwoDestroy = false;
    ThreeDestroy = false;
    DS.Talking(9, 6, TS.GetFin());
  }
  

 
  // Update is called once per frame
  void Update()
  {
    //  Debug.Log(nowDiaID + " Dia");
    //  Debug.Log(nowTaskID + " Task");
    if (Application.loadedLevelName == "Game_02" && OneDestroy)
    {
      One = GameObject.Find("紀子煬");
      Destroy(One);
    }

    if (Application.loadedLevelName == "Game_02" && TwoDestroy)
    {
      Two = GameObject.Find("紀梓潼");
      Destroy(Two);
    }

    if (Application.loadedLevelName == "Game_02" && ThreeDestroy)
    {
      Three = GameObject.Find("紀子煊");
      Destroy(Three);
    }
  } // Update


  void TalkToOne(int e)
  {
    StartCoroutine(Drama_One());
  }

  IEnumerator Drama_One()
  {
    DS.Talking(10, 6, TS.GetFin());
    nowDiaID = 10;
    yield return StartCoroutine(DiaIsFin("Task7"));
    yield return StartCoroutine(DiaIsFin("Task8"));
    yield return new WaitForSeconds(0.3f);
    OneDestroy = true;
  }


  void TalkToTwo(int e)
  {
    StartCoroutine(Drama_Two());
  }

  IEnumerator Drama_Two()
  {
    DS.Talking(11, 6, TS.GetFin());
    nowDiaID = 11;
    yield return StartCoroutine(DiaIsFin("Task9"));
    yield return StartCoroutine(DiaIsFin("Task10"));
    yield return new WaitForSeconds(0.3f);
    TwoDestroy = true;
  }


  void TalkToThree(int e)
  {
    StartCoroutine(Drama_Three());
  }

  IEnumerator Drama_Three()
  {
    DS.Talking(12, 6, TS.GetFin());
    nowDiaID = 12;
    yield return StartCoroutine(DiaIsFin("Task11"));
    yield return StartCoroutine(DiaIsFin("Task12"));
    yield return new WaitForSeconds(0.3f);
    ThreeDestroy = true;
  }



  IEnumerator DiaIsFin(string t_name)
  {
    yield return new WaitUntil(CheckDia);
    TS.GetTask(t_name);
  }

  IEnumerator TaskIsFin(int _DiaID, int _TaskID)
  {
    //Debug.Log(CheckTask()+"***");
    yield return new WaitUntil(CheckTask);
    DS.Talking(_DiaID, _TaskID, TS.GetFin());
    nowDiaID = _DiaID;
  }

  /*
  IEnumerator IsEnd()
  {
    //Debug.Log(CheckTask() + "***");
    yield return new WaitUntil(CheckTask);
    yield return new WaitForSeconds(3f);

    Application.LoadLevel("Accident");
    S.SendMessage("SetChapter", "Chapter_0");
    S.SendMessage("DramaIsEnd", 0, SendMessageOptions.DontRequireReceiver);
  }*/

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
