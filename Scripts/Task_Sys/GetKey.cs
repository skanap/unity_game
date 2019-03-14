using UnityEngine;
using System.Collections;

public class GetKey : TaskCondition {
  public string KeyName ;
  public KeyCode key;

  public GetKey( int id, string name ) {
    this.isFinished = false;
    this.TaskID = id ;
    this.KeyName = name ;
    this.ChangeType();
    this.Key();
  } // GetKey()


  // 轉換成KeyCode
  public void Key() {
    if (this.KeyName == "LeftArrow") key = KeyCode.LeftArrow;
    if (this.KeyName == "RightArrow") key = KeyCode.RightArrow;
    if (this.KeyName == "UpArrow") key = KeyCode.UpArrow;
    if (this.KeyName == "DownArrow") key = KeyCode.DownArrow;
    if (this.KeyName == "E") key = KeyCode.E;
  } // Key()


  // 確認是否有按下所要求的按鍵
  public override void Check(){
    if (Input.GetKey(key)) {
      this.isFinished = true;
    } // if
  } // Check()


  // Debug用
  // 改變子類型
  public override void ChangeType() {
    this.type = "GetKey";
  } // ChangeType()

} // class GetKey