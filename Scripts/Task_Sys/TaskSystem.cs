using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class TaskSystem : MonoBehaviour {

  public TaskManager tm;
  public TaskButtonManager tbm;
  public Text t_name;                 // 任務名稱
  public Text t_content;              // 任務內容
  private static List<Task> finished, now;    // 已完成任務,未完成仍在任務面板上的任務
  public GameObject tw;               // 任務面板
  public GameObject tisOK_window;     // 任務完成提示視窗
  public Text ok_message;             // 任務完成訊息

	// Use this for initialization
	void Start () {
    finished = new List<Task>();
    now = new List<Task>();
    tm = new TaskManager();
  }
	
	// Update is called once per frame
  // 隨時查看是否有任務完成
  // 完成即從現有任務清單刪除並將其新增至已完成任務清單
	void Update () {
    Debug.Log("In Now Count_U:" + now.Count);
    /*
    foreach (Task t in now)
    {
      Debug.Log(t.TaskID + "   " + t.name + "   " + Time.time);
    }*/
    Debug.Log("In Fin Count_U:" + finished.Count);
    //Debug.Log("In Now Count_U:" + now[0].name);
    Task fin = tm.CheckFin( now );

    if (fin != null) {
     // Debug.Log("Task"+fin.TaskID + "It's fin.");
      finished.Add(fin);
      now.Remove(fin);
     // Debug.Log("After Remove: " + now.Count);
      ok_message.text = "\"" + fin.name + "\"任務已完成!";
      tisOK_window.SetActive(true);
    } // if
	} // Update()


  // 任務完成-->刪除任務



  // 獲得任務並新增至現有任務清單
  public void GetTask(string name) {
    // if 完成過就不再接任務

    /*
     待加....
     * if(  )
     * foreach( Task t in finished)
     *   if(t.taskID== finished[i]) return false;
     * 
     */

    bool isGetFin = false;
    foreach (Task t in finished)
    {
      if (t.TaskID.ToString() == name.Substring(4)) isGetFin = true;
      Debug.Log(name.Substring(4) + "Check重複");
    }

    foreach (Task t in now)
    {
      if (t.TaskID.ToString() == name.Substring(4)) isGetFin = true;
    }

    if (!isGetFin)
    {
      Task newTask = new Task();
      newTask = tm.ReadXml(name);
      now.Add(newTask);
    }
    //Debug.Log("In Now Count:" + now.Count);
   // Debug.Log("In Now Count:" + now[0].name);
  } // GetTask()


  // 點擊任務鍵跑出詳細任務面板
  public void clickTaskButton(GameObject Obj) {
    Text str = Obj.transform.GetChild(0).gameObject.GetComponent<Text>();
    Debug.Log("TaskName:" + str.text);
    tw.SetActive(true);
    OnTaskWindow(str.text);
  } // clickTaskButton()



  // 在任務面板顯示任務名稱跟任務內容
  public void OnTaskWindow(string taskName)
  {
    Debug.Log("In Now Count_:" + now.Count);
    foreach (Task temp in now) {
      Debug.Log("In Now:" + temp.name);
      if (temp.name == taskName) {
        t_name.text = temp.name;
        t_content.text = temp.content;
      } // if
    } // foreach

    foreach (Task temp in finished)
    {
     // Debug.Log("In Now:" + temp.name);
      if (temp.name == taskName)
      {
        t_name.text = temp.name;
        t_content.text = temp.content + "\n　 ***已完成***";
      } // if
    }
  } // OnTaskWindow()


  public List<Task> GetFin()
  {
    return finished;
  }


  public void SetFin(Task t)
  {
    finished.Add(t);
  }

  public List<Task> GetNow()
  {
    return now;
  }

  void Reset(int e)
  {
    finished.Clear();
    now.Clear();
   // Debug.Log("TS Reset is OK.");
  }


  public bool CheckSomeTask(int id)
  {
    foreach (Task t in now)
    {
      if (t.TaskID == id)
      {
        return true;
      }
    }

    return false;
  }



  public bool CheckSomeTaskFin(int id)
  {
    foreach (Task t in finished)
    {
      if (t.TaskID == id)
      {
        return true;
      }
    }

    return false;
  }
  /*
  public void SetNow(Task t)
  {
    now.Add(t);
  }
  */
} // class TaskSystem
