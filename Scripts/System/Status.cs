using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System.Collections.Generic;
using System.Xml.Linq;

public class Status : MonoBehaviour
{

  public string SceneName;
  public string Chapter;
  public int Scene1;
  public int Scene2;
  [SerializeField]
  Drama drama;
  [SerializeField]
  Drama2 drama2;
  [SerializeField]
  TaskThings tt;

  [SerializeField]
  GameObject Icon_Task;
  [SerializeField]
  float player_hp;
  [SerializeField]
  bool isLoad;
  [SerializeField]
  bool isReset;
  [SerializeField]
  GameObject Player;
  Transform player_t;


  [SerializeField]
  GameObject tw;
  [SerializeField]
  GameObject t_ok;
  [SerializeField]
  GameObject Dia;

  [SerializeField]
  GameObject Mission;
  [SerializeField]
  GameObject User_Canvas;
  [SerializeField]
  GameObject Timer;

  [SerializeField]
  DialogueSystem DS;
  [SerializeField]
  TaskSystem TS;
  [SerializeField]bool isCountdown;
  
  [SerializeField]GameObject s1;
  [SerializeField]
  GameObject s2;
  [SerializeField]
  GameObject s3;
  [SerializeField]
  GameObject s4;
  [SerializeField]
  GameObject s5;
  [SerializeField]
  GameObject s6;

  [SerializeField]
  public int Favorability;  // 存取好感度

  public bool IsTalking;
  public bool HaveTask;
  Calculation hp_script;

  //public Save save;
  //public Load load;
  //public Sound sound;

  [SerializeField]
  Event OnLoad;
  void Awake()
  {
   // SceneName = "initialization";
  }


  // Use this for initialization
  void Start()
  {
    Scene1 = 0;
    Scene2 = 0;
    isLoad = false;
    isReset = false;
    Favorability = 0;
    IsTalking = false;
    HaveTask = false;
    isCountdown = false;
    DS = GameObject.Find("DialogueSystem").GetComponent("DialogueSystem") as DialogueSystem;
    TS = GameObject.Find("TaskSystem").GetComponent("TaskSystem") as TaskSystem;
    drama = GameObject.Find("Drama").GetComponent("Drama") as Drama;
    drama2 = GameObject.Find("Drama2").GetComponent("Drama2") as Drama2;
    Icon_Task = GameObject.Find("Task");
    //Timer = GameObject.Find("Timer");
  }

  // Update is called once per frame
  void Update()
  {

    SceneName = Application.loadedLevelName;
    
    if (Application.loadedLevelName == "Game_01" || Application.loadedLevelName == "Game_02" || Application.loadedLevelName == "Game_03")
    {
      User_Canvas.SetActive(true);
      Player = GameObject.Find("Player");
      player_t = Player.transform;
     // Drama drama = gameObject.AddComponent<Drama>() as Drama;
      //Player.SetActive(true);
      
      if (!drama.enabled && Chapter == "Teaching")
      {
        drama.enabled = true;
      }

      if (!drama2.enabled && Chapter == "Chapter_0")
      {
        drama2.enabled = true;
      }
        /*
      else
      {
        Scene2++;
      }
      */
      if (isLoad)
      {
        /*
        GameObject g = GameObject.Find("Drama");
        Destroy(g);*/
        GameObject value = GameObject.Find("HP_Value");
        hp_script = value.GetComponent("Calculation") as Calculation;
        hp_script.Hp = PlayerPrefs.GetFloat("Player_HP");
        player_t.position = new Vector3(PlayerPrefs.GetFloat("Position_x"), PlayerPrefs.GetFloat("Position_y"), PlayerPrefs.GetFloat("Position_z"));
        if (PlayerPrefs.HasKey("Time"))
        {
          Timer t = Timer.GetComponent("Timer") as Timer;
          t.timer = PlayerPrefs.GetFloat("Time");
        }
        isLoad = false;
      }


      if (isReset)
      {
        GameObject u = GameObject.Find("User");
        u.BroadcastMessage("Reset", 0, SendMessageOptions.RequireReceiver);
        isReset = false;
      }
    }
    else if (Application.loadedLevelName == "Black")
    {
      PrintFinDiaTask(DS.GetFin(), TS.GetFin());
      Dia.SetActive(DS.isTalk);
    }
    else
    {
      tw.SetActive(false);
      t_ok.SetActive(false);
      User_Canvas.SetActive(false);
      if (Application.loadedLevelName != "Grave" && Application.loadedLevelName != "End1" && Application.loadedLevelName != "End2" && Application.loadedLevelName != "End3")
        Dia.SetActive(false);
    }

    if (Chapter != "Chapter_0") {
      Timer.SetActive(false);
      drama2.enabled = false;
      Icon_Task.SetActive(false);
      /*
      if (Application.loadedLevelName == "Game_01")
      {
        CloseThing(Task_Btn);

      }*/
      

    }


    if (DS.isTalk && Player != null)
    {

      Control player_c = Player.GetComponent("Control") as Control;
      player_c.CanWalk = false;
    } // if
    else if (!DS.isTalk && Player != null)
    {
      Control player_c = Player.GetComponent("Control") as Control;
      player_c.CanWalk = true;
    }



    if (Chapter == "Chapter_0")
    {
     
      //TS.tm.xmlDoc = XDocument.Load(Application.dataPath + "/task2.xml");
      GameObject Father = GameObject.Find("紀宇文");
      GameObject Father2 = GameObject.Find("紀宇文_2");
      Destroy(Father);
      Destroy(Father2);
      if(Application.loadedLevelName=="Game_02")ChangePeople();
      if (TS.GetNow().Count != 0)
      {
        Icon_Task.SetActive(true);
        if (!isCountdown)
        {
          DS.Talking(13,6,TS.GetFin());
          Timer.SetActive(true);
          isCountdown = true;
        }

      } // if

      if (TS.CheckSomeTask(7) || TS.CheckSomeTaskFin(7))s1.SetActive(true);
      else s1.SetActive(false);

      if (TS.CheckSomeTask(8) || TS.CheckSomeTaskFin(8)) s2.SetActive(true);
      else s2.SetActive(false);

      if (TS.CheckSomeTask(9) || TS.CheckSomeTaskFin(9)) s3.SetActive(true);
      else s3.SetActive(false);

      if (TS.CheckSomeTask(10) || TS.CheckSomeTaskFin(10)) s4.SetActive(true);
      else s4.SetActive(false);

      if (TS.CheckSomeTask(11) || TS.CheckSomeTaskFin(11)) s5.SetActive(true);
      else s5.SetActive(false);

      if (TS.CheckSomeTask(12) || TS.CheckSomeTaskFin(12)) s6.SetActive(true);
      else s6.SetActive(false);

      if (TS.CheckSomeTaskFin(10) && Application.loadedLevelName == "Game_02")
        if (GameObject.Find("TV_F") != null) GameObject.Find("TV_F").SetActive(true);
    } // if



  }


  public void Save()
  {
    GameObject value = GameObject.Find("HP_Value");
    hp_script = value.GetComponent("Calculation") as Calculation;
    Debug.Log(hp_script.Hp);
    PlayerPrefs.SetFloat("Player_HP", hp_script.Hp);
    PlayerPrefs.SetString("Scene_Name", SceneName);
    PlayerPrefs.SetString("Chapter", Chapter);
    //if (Chapter == "Teaching")
    //{
      PlayerPrefs.SetInt("DiaID", DS.GetFin()[DS.GetFin().Count - 1]);
      PlayerPrefs.SetInt("TaskID", TS.GetFin()[TS.GetFin().Count - 1].TaskID);
      //PlayerPrefs.SetInt("DiaID", DS.GetFin()[DS.GetFin().Count - 1]);
      //test***
      if (TS.GetNow().Count != 0) PlayerPrefs.SetInt("NowTaskID", TS.GetNow()[0].TaskID);
      if (DS.GetNow() != -1) PlayerPrefs.SetInt("NowDiaID", DS.GetNow());
    //}
      /*
    else if (Chapter == "Chapter_0")
    {

       for(int i = 0 ; i < 19;i++){
          if(PlayerPrefs.HasKey("FinDia"+i)) {
            PlayerPrefs.DeleteKey("FinDia" + i);
          }
        }

        for(int i = 0 ; i < 12;i++){
          if(PlayerPrefs.HasKey("FinTask"+i)) {
            PlayerPrefs.DeleteKey("FinTask" + i);
          }
        }

        //PlayerPrefs.SetInt("NowDia", DS.GetNow());

        for (int i = 0; i < 12; i++)
        {
          if (PlayerPrefs.HasKey("NowTask" + i))
          {
            PlayerPrefs.DeleteKey("NowTask" + i);
          }
        }
      foreach (int i in DS.GetFin())
      {
        PlayerPrefs.SetInt("FinDia"+i, i);
      }

      foreach (Task i in TS.GetFin())
      {
        PlayerPrefs.SetInt("FinTask" + i.TaskID, i.TaskID);
      }

      //PlayerPrefs.SetInt("NowDia", DS.GetNow());

      foreach (Task i in TS.GetNow())
      {
        PlayerPrefs.SetInt("NowTask" + i.TaskID, i.TaskID);
      }
    }*/

    PlayerPrefs.SetFloat("Position_x", player_t.position.x);
    PlayerPrefs.SetFloat("Position_y", player_t.position.y);
    PlayerPrefs.SetFloat("Position_z", player_t.position.z);
   // Timer = GameObject.Find("Timer");
      Timer t = Timer.GetComponent("Timer") as Timer;
    if(t!=null){
      PlayerPrefs.SetFloat("Time", t.GetTime());
    }
    

    PlayerPrefs.Save();
  }


  public void Load()
  {/*
    SceneName = PlayerPrefs.GetString("Scene_Name");
    if (SceneName != "")
    {*/
      isLoad = true;
      SceneName = PlayerPrefs.GetString("Scene_Name");
      Chapter = PlayerPrefs.GetString("Chapter");
      Debug.Log(Chapter);
      //if (Chapter == "Teaching")
      //{
        int _DiaID = PlayerPrefs.GetInt("DiaID");
        int _TaskID = PlayerPrefs.GetInt("TaskID");
        int _NowTaskID = PlayerPrefs.GetInt("NowTaskID");
        int _NowDiaID = PlayerPrefs.GetInt("NowDiaID");
        for (int i = 1; i <= _DiaID; i++) DS.SetFin(i);
        for (int i = 0; i <= _TaskID; i++)
        {
          Task t = new Task();
          t.TaskID = i;
          TS.SetFin(t);
        }

        if (_NowTaskID != 0) TS.GetTask("Task" + _NowTaskID.ToString());
        if (_NowDiaID != 0 && Chapter == "Teaching") DS.Talking(_NowDiaID, _NowDiaID - 2, TS.GetFin());
        _NowTaskID = 0;
        _NowDiaID = 0;
      //}
    /*
      else if (Chapter == "Chapter_0")
      {
        for(int i = 0 ; i < 19;i++){
          if(PlayerPrefs.HasKey("FinDia"+i)) {
            DS.SetFin(i);
            //PlayerPrefs.DeleteKey("FinDia" + i);
          }
        }

        for(int i = 0 ; i < 12;i++){
          if(PlayerPrefs.HasKey("FinTask"+i)) {
            Debug.Log("HasKey");
            Task t = new Task();
            t.TaskID = i;
            TS.SetFin(t);
            //PlayerPrefs.DeleteKey("FinTask" + i);
          }
        }

        //PlayerPrefs.SetInt("NowDia", DS.GetNow());

        for (int i = 0; i < 12; i++)
        {
          if (PlayerPrefs.HasKey("NowTask" + i))
          {
            TS.GetTask("Task" + i);
            //PlayerPrefs.DeleteKey("NowTask" + i);
          }
        }
      }*/
      Application.LoadLevel(SceneName);
   // } // if
  /*
    else
    {
      GameObject NoSave = GameObject.Find("NonSaveData");
      NoSave.SetActive(true);
    }*/
  }



  void ChangePeople()
  {
    GameObject a = GameObject.Find("紀子煬");
    if (a != null) a.transform.position = new Vector3(186, 38, 0);

    GameObject b = GameObject.Find("紀梓潼");
    if(b!=null)b.transform.position = new Vector3(-63, 25, 0);

    GameObject c = GameObject.Find("紀子煊");
    if (c != null) c.transform.position = new Vector3(22, -88, 0);
  }



  void PrintFinDiaTask(List<int> dia, List<Task> task)
  {
    foreach (int d in dia)
    {
      Debug.Log("Dia : " + d);
    }
    foreach (Task t in task)
    {
      Debug.Log("Task : " + t.TaskID);
    }
  }

  public int GetScene(string name)
  {
    if (name == "Game_01") return Scene1;
    else if (name == "Game_02") return Scene2;
    else return 0;
  }

  void DramaIsEnd(int e)
  {
    drama.enabled = false;
  }


  void Drama2IsEnd(int e)
  {
    drama2.enabled = false;
    Debug.Log("Drama2 is Fin.");
    /*
    Control player_c = Player.GetComponent("Control") as Control;
    player_c.CanWalk = false;*/
    DS.Talking(14, 6, TS.GetFin());

    if (CheckDia(14)) Application.LoadLevel("Grave");
   // SetChapter("After");

    //foreach ()
  }

  bool CheckDia(int id)
  {
    foreach (int i in DS.GetFin())
    {
      if (i == id) return true;
    }
    return false;
  }

  IEnumerator ToGrave()
  {
    yield return new WaitForSeconds(1f);
    Application.LoadLevel("Grave");
  }


  void SetChapter(string c)
  {
    Chapter = c;
  }


  void Reset(int e)
  {
    Chapter = null;
    isLoad = false;
    IsTalking = false;
    HaveTask = false;
    drama.enabled = false;
    drama2.enabled = false;
    isReset = true;
    s1.SetActive(false);
    s2.SetActive(false);
    s3.SetActive(false);
    s4.SetActive(false);
    s5.SetActive(false);
    s6.SetActive(false);
    Mission.SetActive(false);
    Timer t = Timer.GetComponent("Timer") as Timer;
    t.timer = 105;
    Debug.Log("Status Reset is OK.");
  }


  void ChangePosition(string scene)
  {
    StartCoroutine(WaitScene(scene));
  }

  IEnumerator WaitScene(string scene)
  {
    if (scene == "Game_02")     // Game_02 -> Game_01
    {
      yield return new WaitUntil(IsLab);
      GameObject e = GameObject.Find("Elevator");
      e.SendMessage("EIsOpen", "Game_01");
    }

    if (scene == "Game_01")     // Game_01 -> Game_02
    {
      yield return new WaitUntil(IsLivingRoom);
      GameObject e = GameObject.Find("Elevator");
      e.SendMessage("EIsOpen", "Game_02");
    }

    if (scene == "Game_03")     // Game_03 -> Game_02
    {
      yield return new WaitUntil(IsLivingRoom);
      player_t = GameObject.Find("Player").transform;
      player_t.position = new Vector3(260,12,0);
    }
  }

  bool IsLab()
  {
    if (Application.loadedLevelName == "Game_01") return true;
    else return false;
  }

  bool IsLivingRoom()
  {
    if (Application.loadedLevelName == "Game_02") return true;
    else return false;
  }


  void CloseThing(string name)
  {
    GameObject temp;
    temp = GameObject.Find(name);
    temp.SetActive(false);
  }

}