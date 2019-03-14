using UnityEngine;
using System.Collections;

public class Grave : MonoBehaviour {
  [SerializeField]
  DialogueSystem DS;
  [SerializeField]
  TaskSystem TS;
  [SerializeField]
  Status S;
  [SerializeField]
  int nowDiaID;
  [SerializeField]
  int f;
  [SerializeField]
  bool isFinOK;
  [SerializeField]
  GameObject Obj;
	// Use this for initialization
	void Start () {
    DS = GameObject.Find("DialogueSystem").GetComponent("DialogueSystem") as DialogueSystem;
    S = GameObject.Find("Status").GetComponent("Status") as Status;
    TS = GameObject.Find("TaskSystem").GetComponent("TaskSystem") as TaskSystem;
    S.SendMessage("SetChapter", "After");
    Obj.SetActive(false);
    isFinOK = false;
    DS.Talking(15, 6, TS.GetFin());
	}
	


  // Update is called once per frame
  void Update()
  {
    if (DS.dia == null)
    {
      if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
        isFinOK = true;
    }

    if (isFinOK && !DS.isTalk)
    {
      StartCoroutine(DiaIsFin());
    }
  }


  IEnumerator DiaIsFin()
  {
    // yield return new WaitUntil(CheckDia);
    yield return new WaitForSeconds(2f);
    Obj.SetActive(true);
    //Application.LoadLevel("Staff");
  }

  public void ClickFin()
  {
    f = S.Favorability;
    if (f > 90) Application.LoadLevel("End1");
    else if (f < 90) Application.LoadLevel("End3");
    else Application.LoadLevel("End2");
  }

}
