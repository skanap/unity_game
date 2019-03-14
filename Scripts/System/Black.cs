using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Black : MonoBehaviour {
  public UnityEvent my_Event;
  [SerializeField] DialogueSystem d;
  [SerializeField] GameObject ds;
  [SerializeField] TaskSystem t;
  [SerializeField] GameObject ts;


  [SerializeField]
  GameObject d_frame;
  [SerializeField] AudioSource a;
  [SerializeField]
  bool _isfinOK;
  [SerializeField]
  bool _isStart;

  void Awake()
  {
    ds = GameObject.Find("DialogueSystem");
    ts = GameObject.Find("TaskSystem");
  }
	// Use this for initialization
	void Start () {
    d = ds.GetComponent("DialogueSystem") as DialogueSystem;
    t = ts.GetComponent("TaskSystem") as TaskSystem;
    Task init = new Task();
    init.TaskID = 0;
    t.SetFin(init); 
    d.Talking(1, 0, t.GetFin());
    _isfinOK = false;
    _isStart = false;
    //StartCoroutine(Wait());
	}
	
	// Update is called once per frame
	void Update () {
   // Debug.Log(d.dia.Count);
    if (d.dia == null/*d.dia!= null && d.dia.Count == 0*/)
    {
      if (Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.KeypadEnter))
      {
        d_frame = GameObject.Find("Dialogue");
        a.Play();
        _isStart = true;
      }
    }
    if (_isStart && !a.isPlaying)
    {
      _isfinOK = true ;
    }
    if (_isfinOK && !d.isTalk)
    {
     // d_frame.SetActive(false);
      StartCoroutine(Wait());
    }
	}

  IEnumerator Wait()
  {
    GameObject s = GameObject.Find("Status");
    s.SendMessage("SetChapter", "Teaching");
    Application.LoadLevel("Game_01");
    yield return null; 
  }

}
