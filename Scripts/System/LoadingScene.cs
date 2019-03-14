using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScene : MonoBehaviour {

  //public string scene_name ;
  public Slider LoadingSlider ;
  private AsyncOperation async;
  public Text T_progress ;
  
  public GameObject loading_screen ;
  public GameObject panel ;
  string scene;
  void Awake() {
    loading_screen.SetActive( false ) ;
    //panel.SetActive( false ) ;
  }

  // Use this for initialization
  void Start () {
  }
	
  // Update is called once per frame
  void Update () {
  }


  public void click( string scene_name ){
    StartCoroutine(loadScene( scene_name ));
    loading_screen.SetActive( true ) ;
  }

  IEnumerator loadScene( string name )
  {
    int displayProgress = 0;
    int toProgress = 0;
    LoadingSlider.value = 0 ;
    async = Application.LoadLevelAsync(name);
    async.allowSceneActivation = false;


    while (async.progress < 0.9f)
    {
      toProgress = (int)async.progress * 100;
      while (displayProgress < toProgress)
      {
        ++displayProgress;
        SetLoadingSlider(displayProgress);
        yield return new WaitForEndOfFrame();
      }
    }
    toProgress = 100;
    while (displayProgress < toProgress)
    {
      ++displayProgress;
      SetLoadingSlider(displayProgress);
      yield return new WaitForEndOfFrame();
    }
    async.allowSceneActivation = true ;

  }

  void SetLoadingSlider(int progress)
  {
    float tmp = (float)( (float)progress / 100 ) ;
    T_progress.text = progress+"%";
    LoadingSlider.value = tmp;
  }

}
