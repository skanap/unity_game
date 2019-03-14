using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CheckClick : MonoBehaviour {
  public bool isClicked;
  TaskSystem TS;
  Status S;
  SpriteRenderer r;
	// Use this for initialization
	void Start () {
    TS = GameObject.Find("TaskSystem").GetComponent("TaskSystem") as TaskSystem;
    S = GameObject.Find("Status").GetComponent("Status") as Status;
    r = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void Click()
  {
    bool isChecking = false ; 
    List<Task> now = TS.GetNow();
    foreach (Task t in now)
    {
      List<TaskCondition> tc_list = t.tc;
      foreach (TaskCondition tc in tc_list)
      {
        if (tc.type == "ClickObject")
        {
          ClickObject c = (ClickObject)tc;
          if (c.ObjectName == gameObject.name)
          {
            isChecking = true;
          }
        }
      }
    }

    if (isChecking)
    {
      isClicked = true;
      if (S.Chapter == "Chapter_0") r.transform.position = new Vector3(1000, -1000, 0);
     //   r.sortingLayerName = "Default";
    }
  }
}
