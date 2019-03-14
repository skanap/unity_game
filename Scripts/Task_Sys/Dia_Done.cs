using UnityEngine;
using System.Collections;

public class Dia_Done : TaskCondition {
  public string name ;
  public string DiaName ;

  public Dia_Done(int id, string name, string dName) {
    this.TaskID = id ;
    this.name = name ;
    this.DiaName = dName;
  }


  public override void Check(){
    
  }

}
