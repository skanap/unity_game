using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Events;

public class Calculation : MonoBehaviour {

  [SerializeField] float MaxHp ;
  [SerializeField] public float Hp ;
  private bool IsDead = false ;
  public GameObject player ;
 // [SerializeField] GameObject LoadScene;
 // [SerializeField] LoadingScene load;
  //[SerializeField]public UnityEvent Dead;

  // Use this for initialization
  void Start () {
    this.MaxHp = 100 ;
    this.Hp = 100 ;
    player = GameObject.Find( "Player" ) ;
  } // Start
	
  // Update is called once per frame
  void Update () {
    if ( Hp >= 96 ) Hp = 100 ;
    if ( Hp <= 1 ) Hp = 0 ;
    this.transform.localPosition = new Vector3( ( -261 + 243 * ( Hp / MaxHp ) ), 2, 0 ) ;

    // Change Color
    if ( Hp > 61 )
      this.GetComponent<Image>().color = new Color32(3, 227, 33,255);
    if ( Hp < 61 && Hp > 25 )
      this.GetComponent<Image>().color = new Color32(255, 215, 32, 255);
    if ( Hp < 25 )
      this.GetComponent<Image>().color = Color.red ;



    if (Hp == 0)
    {
      StartCoroutine(Dead());
    }

  } // Update()
  
  /*
  void OnGUI () //按鈕控制血量增加和減少
  {
    if(GUI.Button (new Rect (Screen.width/2+50,Screen.height/2+50,80,50), "加血"))
    {
      if ( Hp == 0 ) Hp = 12.2f ;
      else if ( Hp == 60.2f ) Hp += 12.4f ;
      else Hp += 12 ;
    }

    if(GUI.Button (new Rect (Screen.width/2-100,Screen.height/2+50,80,50), "扣血"))
    {
      if ( Hp == 100 ) Hp = 84.6f ;
      else if ( Hp == 72.6f ) Hp -= 12.4f ;
      else Hp -= 12 ;
    }
  }*/
  

  // 扣血
  public void Hit(){
    if (Hp == 100) Hp = 84.6f;
    else if (Hp == 72.6f) Hp -= 12.4f;
    else Hp -= 12;
  }


  // 加血
  public void Treat()
  {
    if (Hp == 0) Hp = 12.2f;
    else if (Hp == 60.2f) Hp += 12.4f;
    else Hp += 12;
  }

  IEnumerator Dead()
  {
    yield return new WaitForSeconds(1f);
    Application.LoadLevel("GameOver");
  }


  // New Game
  void Reset(int e)
  {
    this.Hp = 100;
   // Debug.Log("fdfd");
  }
}
