using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Task {
  public int TaskID;
  public string name;
  public string content;
  public List<TaskCondition> tc;
  public bool isFinished;

  public Task() {
    this.isFinished = false;
    tc = new List<TaskCondition>();
  } // Task()


  // 確認任務是否完成
  public bool CheckIsFinished() {
    int i = 1;  // test用
    foreach ( TaskCondition t in tc ) {
      t.Check();
      if (!t.isFinished) {
       // Debug.Log(this.name+ t.type + " NO");  // test用
        isFinished = false;
        return false;
      } // if
    //  Debug.Log(this.name + t.type + " OK");  // test用
      i++;  // test用
    } // foreach

    return true;
  } // CheckIsFinished()

} // class Task
