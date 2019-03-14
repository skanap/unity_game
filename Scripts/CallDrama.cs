using UnityEngine;
using System.Collections;

public class CallDrama : MonoBehaviour {
  GameObject drama2;
  Drama2 d;

  void Awake()
  {
    drama2 = GameObject.Find("Drama2");
    d = drama2.GetComponent("Drama2") as Drama2;
  }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  public void CallDrama2()
  {
    if (d.enabled)
    {
      if (gameObject.name == "紀子煬")
        drama2.SendMessage("TalkToOne", 1);
      else if (gameObject.name == "紀梓潼")
        drama2.SendMessage("TalkToTwo", 1);
      else if (gameObject.name == "紀子煊")
        drama2.SendMessage("TalkToThree", 1);
    }
  }

  
}
