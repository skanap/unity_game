using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class InputPwd : MonoBehaviour {
  [SerializeField]UnityEvent myEvent;
  
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void EnterPwd(Text _pwd)
  {
    if (_pwd.text == "E201") myEvent.Invoke();
  }
}
