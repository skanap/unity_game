using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
  //GUIStyle myStyle;
  int roundSeconds;
  int txtSeconds;
  int txtMinutes;
  string text;
  public float timer;
  public Text t;
  [SerializeField]
  Status S;
  void Awake()
  {
    timer = 105;
    S = GameObject.Find("Status").GetComponent("Status") as Status;
  }
	// Use this for initialization
	void Start () {
	  
	}

	
	// Update is called once per frame
	void Update () {

    timer = timer - Time.deltaTime;
    if (timer <= 0) timer = 0;
    if (timer == 0) S.SendMessage("Drama2IsEnd", 1, SendMessageOptions.DontRequireReceiver);
    roundSeconds = Mathf.CeilToInt(timer);
    txtSeconds = roundSeconds % 60;
    txtMinutes = roundSeconds / 60;
    text = txtMinutes.ToString() + ":" + txtSeconds.ToString();
    t.text = text;
    
	}

  IEnumerator CountDown()
  {
    yield return new WaitForSeconds(timer);
   // Debug.Log("fdfddadasda");
   // S.SendMessage("Drama2IsEnd", 1, SendMessageOptions.DontRequireReceiver);
    //Application.LoadLevel("Menu");   //************
  }

  public float GetTime()
  {
    return timer;
  }

}
