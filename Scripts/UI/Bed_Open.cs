using UnityEngine;
using System.Collections;

public class Bed_Open : MonoBehaviour {

  Animator Bed_Animator;
  [SerializeField]
  AudioSource a;
  [SerializeField] bool isOpen, isClosed;
  [SerializeField] GameObject Player;
  Transform Player_t;
  EdgeCollider2D bottom;
  [SerializeField] Calculation cal;
  [SerializeField] GameObject HP;
	// Use this for initialization
	void Start () {
    Bed_Animator = gameObject.GetComponent<Animator>();
    isOpen = false;
    bottom = gameObject.GetComponent<EdgeCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
    Bed_Animator.SetBool("Open", isOpen);
    Bed_Animator.SetBool("Close", isClosed);
    //if( Input.Get )
	}

  public void Click()
  {
    Player = GameObject.Find("Player");
    HP = GameObject.Find("HP_Value");
    Player_t = Player.transform;
    isOpen = true;
    StartCoroutine(PlayerOnBed());
  }


  public IEnumerator PlayerOnBed()
  {
    yield return new WaitForSeconds(1.3f);
    Player_t.position = new Vector3(-447, -63, 0);
    Player_t.rotation = Quaternion.Euler(0f, 0f, -90f);
    bottom.isTrigger = false;
    StartCoroutine(PlayerUnderBed());
  }

  public IEnumerator PlayerUnderBed()
  {
    yield return new WaitForSeconds(1.1f);
    isClosed = true;
    yield return new WaitForSeconds(1.3f);
    a.Play();
    yield return new WaitForSeconds(1.4f);
    cal = HP.GetComponent("Calculation") as Calculation;
    cal.Treat();
    isClosed = false;
    yield return new WaitForSeconds(1.3f);
    Player_t.rotation = Quaternion.Euler(0f, 0f, 0f);
    bottom.isTrigger = true;
    yield return new WaitForSeconds(1.3f);
    //Player_t.position = new Vector3(-447, -65, 0);
    isOpen = false;
  }

  void OnTriggerExit2D()
  {
    isOpen = false;
  }
}
