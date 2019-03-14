using UnityEngine;
using System.Collections;

public class Task_TV : MonoBehaviour {
  [SerializeField]
  GameObject TV_R;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void ClickAny()
  {
    TV_R.SetActive(true);
  }
}
