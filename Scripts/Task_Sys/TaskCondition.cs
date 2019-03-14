using UnityEngine;
using System.Collections;
//using System.Collections.Generic;

public class TaskCondition {
  public int TaskID ;
  public bool isFinished ;
  public string type;

  public virtual void Check() { }
 // public virtual void Check(string name) { }
  public virtual void ChangeType() { }
} // class TaskCondition