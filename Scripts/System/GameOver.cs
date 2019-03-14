using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {

	// Use this for initialization
	void Start () {
    StartCoroutine(ToMenu());
	}
	
	// Update is called once per frame
	void Update () {
	
	}


  IEnumerator ToMenu()
  {
    yield return new WaitForSeconds(1.5f);
    Application.LoadLevel("Menu");
  }
}
