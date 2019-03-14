using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DialogueSystem : MonoBehaviour {

  public DialogueManager dm;
  private static List<int> finished;    // 已執行過的對話ID
  public GameObject d;          // 對話介面
  public GameObject frame ;     // 對話框
  public GameObject f_name;     // 名字框
  public List<Dialogue> dia;    // 要進行的對話
  public int NowDiaID;          // 現在進行的對話ID
  public bool isTalk;

	// Use this for initialization
	void Start () {
    dm = new DialogueManager();
    finished = new List<int>();
    NowDiaID = -1;
    //isTalk = true;
	} // Start()
	
	// Update is called once per frame
	void Update () {
    if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
      if (dia != null && dia.Count != 0)
        dm.NextDia(dia, frame, f_name);
      else if (dia != null && dia.Count == 0)
      {
        d.SetActive(false);
        isTalk = false;
        finished.Add(NowDiaID);
        dia = null;
      //  Debug.Log(dia);
      //  Debug.Log(NowDiaID);
      } // else
  } // Update()


  public void Talking(int DiaID, int TaskID, List<Task> fin)
  {
    if (GetDialogue(DiaID, TaskID, fin))
    {
      NowDiaID = dia[0].DiaID;
      d.SetActive(true);
      isTalk = true;
      dm.NextDia(dia, frame, f_name);
    } // if
  } // Talking()


  // 載入對話
  // 若已進行過此對話則不再次進行對話
  // 若未進行過但未完成觸發對話的條件也不進行對話
  public bool GetDialogue(int DiaID, int TaskID, List<Task> fin) {
    bool TaskIsFin = false ;
    for(int i = 0 ; i < finished.Count ; i++) if(DiaID == finished[i]) return false;
 //   if (dm == null) Debug.Log("fd"); 
    dia = dm.ReadXml("Dia"+DiaID);
    if( dia[0].TaskID == 0 ) TaskIsFin = true;
    else {
      for(int i = 0 ; i < fin.Count ; i++)
        if(TaskID == fin[i].TaskID) TaskIsFin = true;
    } // else

    if(TaskIsFin) return true ;
    else return false ;
  } // GetDialogue()


  /*
  public List<int> GetNow()
  {
    return now;
  }
  */
  public List<int> GetFin()
  {
    return finished;
  }

  public int GetNow()
  {
    return NowDiaID;
  }

  public void SetFin(int d)
  {
    finished.Add(d);
  }


  void Reset(int e)
  {
    NowDiaID = -1;
    finished.Clear();
   // Debug.Log("DS Reset is OK.");
  }
} // class DialogueSystem
