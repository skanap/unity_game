using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour {

	// Use this for initialization
  void Start()
  {
    Object[] initsObjects = GameObject.FindObjectsOfType(typeof(GameObject));
    foreach (Object go in initsObjects)
    {
      DontDestroyOnLoad(go);
    }



    Application.LoadLevel("Menu");
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
