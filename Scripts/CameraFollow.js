#pragma strict
private var range : Vector2 = Vector2( -293.5, 293.5 ) ;
var target : Transform ;
var isOk;
function Start () {
  isOk = false;
  yield WaitForSeconds(0.02f);
  target = GameObject.Find("Player").transform;
  isOk = true;
}

function Update () {
  if(isOk){
    transform.position.x = target.position.x;
    transform.position.x = Mathf.Clamp( transform.position.x, range.x, range.y ) ;
  }
}