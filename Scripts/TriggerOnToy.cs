using UnityEngine;
using System.Collections;

public class TriggerOnToy : MonoBehaviour {
  [SerializeField]
  Calculation cal;
  [SerializeField]
  GameObject HP;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}



  /// <summary>
  /// 待修
  /// 銷毀過一次即不再出現!!!!
  /// </summary>
  public void ClickToy()
  {
    Destroy(gameObject);
  }


  void OnTriggerEnter2D()
  {
    HP = GameObject.Find("HP_Value");
    cal = HP.GetComponent("Calculation") as Calculation;
    cal.Hit();

  }

  void OnTriggerExit2D()
  {

  }
}
