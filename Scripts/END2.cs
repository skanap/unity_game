using UnityEngine;
using System.Collections;

public class END2 : MonoBehaviour
{
  [SerializeField]
  DialogueSystem DS;
  [SerializeField]
  TaskSystem TS;
  [SerializeField]
  Status S;
  [SerializeField]
  GameObject Obj;

  [SerializeField]
  bool Run;

  [SerializeField]
  bool FatherDestroy;


  [SerializeField]
  int nowDiaID;
  [SerializeField]
  int nowTaskID;
  [SerializeField]
  int f;


  void Start()
  {
    DS = GameObject.Find("DialogueSystem").GetComponent("DialogueSystem") as DialogueSystem;
    TS = GameObject.Find("TaskSystem").GetComponent("TaskSystem") as TaskSystem;
    S = GameObject.Find("Status").GetComponent("Status") as Status;
    StartCoroutine(Wait1());
  }

  // Update is called once per frame
  void Update()
  {
    //  Debug.Log(nowDiaID + " Dia");
    //  Debug.Log(nowTaskID + " Task");

  }



  IEnumerator Wait1()
  {
    DS.Talking(17, 6, TS.GetFin());
    nowDiaID = 17;
    yield return StartCoroutine(DiaIsFin());
    yield return StartCoroutine(IsEnd());
  }

  IEnumerator DiaIsFin()
  {
    yield return new WaitUntil(CheckDia);
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
    //yield return new WaitUntil(CheckTask);
    yield return new WaitForSeconds(3f);
    Application.LoadLevel("Staff");
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
