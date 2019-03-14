using UnityEngine;
using System.Collections;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System;

public class TaskManager {
  public XDocument xmlDoc;

  public TaskManager() {
    xmlDoc = XDocument.Load(Application.dataPath + "/task.xml");
  } // TaskManager()


  //讀取xml檔轉成Task物件
  public Task ReadXml(string TaskName) {
    Debug.Log(TaskName);
    Task t = new Task();
    XElement xe = xmlDoc.Root.Element(TaskName);
    int DiaID = Convert.ToInt32(xe.Element("DiaID").Value);
    int TaskID = Convert.ToInt32(xe.Element("TaskID").Value);
    int GetDiaID = Convert.ToInt32(xe.Element("GetDiaID").Value);
    t.name = xe.Element("Name").Value;
    t.content = xe.Element("Content").Value;
    IEnumerable<XElement> tc = xe.Elements("TaskCondition");
    IEnumerable<XElement> keyname = xe.Elements("KeyName");
    IEnumerable<XElement> ObjName = xe.Elements("ObjectName");
    Debug.Log(TaskName+" " + t.name + " " + t.content);
    // IEnumerable<XElement> ****
    t.TaskID = TaskID;
    int k_i = 0;   // GetKey Index
    int c_i = 0;   // ClickObj Index
    foreach (XElement temp in tc) {
      if (temp.Value == "GetKey") {
        GetKey get_key = new GetKey(TaskID, keyname.ElementAt<XElement>(k_i).Value.ToString());
       // Debug.Log(get_key.KeyName);
        t.tc.Add( get_key );
        k_i++;
      } // if

      if (temp.Value == "ClickObject")
      {
        ClickObject clickObj = new ClickObject(TaskID, ObjName.ElementAt<XElement>(c_i).Value.ToString());
       // Debug.Log(clickObj.ObjectName);
        t.tc.Add(clickObj);
        c_i++;
      } // if
    } // foreach
   // Debug.Log("Task" + t.TaskID + " " + t.name);
    return t;
  } // ReadXml()



  // 確認任務是否完成
  public Task CheckFin( List<Task> nonfin ) {
    if (nonfin.Count == 0) return null;
    else {
      foreach (Task t in nonfin) {
      //  Debug.Log(t.TaskID + " " + t.name + t.isFinished);
        if (t.CheckIsFinished()) return t;
      } // foreach
      return null;
    } // else
  } // Check()

} // class TaskManager
