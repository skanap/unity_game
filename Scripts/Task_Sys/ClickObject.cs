using UnityEngine;
using System.Collections;

public class ClickObject : TaskCondition {
  public string ObjectName ;
  public GameObject obj;

  public ClickObject(int id, string name) {
    this.isFinished = false;
    this.TaskID = id ;
    this.ObjectName = name ;
    this.ChangeType();
  } // ClickObject()


  // 確認是否有按下所要求的按鍵
  public override void Check(){
    obj = GameObject.Find(ObjectName);
    CheckClick check = null;
    if(obj != null ) check = obj.GetComponent("CheckClick") as CheckClick;
    if (check != null && check.isClicked)
    {
      this.isFinished = true;
    }

  } // Check()


  // Debug用
  // 改變子類型
  public override void ChangeType() {
    this.type = "ClickObject";
  } // ChangeType()

}
