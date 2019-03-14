using UnityEngine;
using System.Collections;

public class Fin : MonoBehaviour {
  [SerializeField] GameObject staff;
  [SerializeField] GameObject material;
  [SerializeField] GameObject fin;
  [SerializeField] AudioSource a;
  [SerializeField] bool isDown;

	// Use this for initialization
	void Awake () {
    staff.SetActive(true);
    material.SetActive(false);
    fin.SetActive(false);
    isDown = false;
	}
	
	// Update is called once per frame
	void Start() {
    StartCoroutine(Go());
	}

  void Update()
  {
    if (isDown) a.volume -= 0.01f; ;
  }

  IEnumerator Go()
  {
    yield return new WaitForSeconds(6.5f);
    staff.SetActive(false);
    yield return new WaitForSeconds(1f);
    material.SetActive(true);
    yield return new WaitForSeconds(6.3f);
    isDown = true;
    yield return new WaitForSeconds(0.2f);
    material.SetActive(false);
    fin.SetActive(true);
    yield return new WaitForSeconds(1.5f);
    Application.LoadLevel("Menu");
  }

}
