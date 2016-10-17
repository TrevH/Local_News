using UnityEngine;
using System.Collections;

public class TouchObject : MonoBehaviour {
	public GUIText texty;
	TouchPhase touchPhaseMoving = TouchPhase.Moved;
	int touchesnum = 0;
	public float speed = 1.0F;
	private GameObject block;
	private ArrayList beguntouch = new ArrayList();
	private float offsetx;
	private float offsety;

	void Start() {
		texty = GameObject.Find("displaytouches").GetComponent<GUIText>();
		print("test up");
		texty.text = "new build2";
	}

	void Update () 
	{
		//Touch myTouch = Input.GetTouch(0);
		Touch[] myTouches = Input.touches;
		for (int i = 0; i < Input.touchCount; i++) {
			// Do something with the touches
			Touch touch = Input.GetTouch(i);
			Debug.Log(i);
			touchesnum++;
			//if (Input.GetTouch (i).phase == touchPhase) {
				// end of touch
				//Ray ray = Camera.main.ScreenPointToRay (Input.GetTouch (i).position);

			RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(touch.position), -Vector2.up);
				//Debug.Log("reached end of tap");
			if (hit.collider != null) {
				//texty.text = "Touch on object " + beguntouch.Count;

				if (touch.phase == TouchPhase.Began) {
					Vector2 touchPosition = Camera.main.ScreenToWorldPoint (new Vector2 (touch.position.x, touch.position.y));
					beguntouch.Add (touch.fingerId);
					beguntouch.Add (hit.collider.name);
					beguntouch.Add (touchPosition);
					//texty.text = "added " + touch.fingerId + " " + hit.collider.name + " " + touchPosition;
				}

			    if (touch.phase == TouchPhase.Moved) {
					//Vector2 touchPosition = Camera.main.ScreenToWorldPoint (new Vector2 (touch.position.x, touch.position.y));
					//block = GameObject.Find(hit.collider.name);
					//block.transform.position = Vector2.Lerp (block.transform.position, touchPosition, Time.deltaTime*1);
					block = GameObject.Find (hit.collider.name);
					Vector2 touchPosition = Camera.main.ScreenToWorldPoint (new Vector2 (touch.position.x, touch.position.y));
					offsetx = block.transform.position.x - touchPosition.x;
					offsety = block.transform.position.y - touchPosition.y;
					Vector2 offsettp = new Vector2 (touchPosition.x + offsetx, touchPosition.y + offsety);
					block.transform.position = offsettp;
					texty.text = hit.collider.name + " moving";
				}
//
//				if (touch.phase == TouchPhase.Stationary) {
//					texty.text = hit.collider.name + " stationary";
//				}
				if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled) {
					//texty.text = hit.collider.name + " ended";
					for (int u = 0; u < beguntouch.Count / 3; u++) {
						int finger = (int)beguntouch [u*3];
						if (touch.fingerId == finger) {	
							beguntouch.RemoveAt (u*3);
							beguntouch.RemoveAt ((u*3)+1);
							beguntouch.RemoveAt ((u*3)+2);
							texty.text = "removed " + beguntouch[u*3] + " " + beguntouch[u*3+1] + " " + beguntouch[u*3+2];
						}
					}
				}

//				for (int u = 0; u < beguntouch.Count / 3; u++) {
//					int finger = (int)beguntouch [u*3];
//					string objectname = beguntouch [(u*3)+1].ToString ();
//					Vector2 pos = (Vector2)beguntouch [(u*3)+2];
//					if (touch.fingerId == finger) {	
//						    //texty.text = hit.collider.name + " reached";
//							block = GameObject.Find (objectname);
//							Vector2 touchPosition = Camera.main.ScreenToWorldPoint (new Vector2 (touch.position.x, touch.position.y));
//						    offsetx = block.transform.position.x - touchPosition.x;
//						    offsety = block.transform.position.y - touchPosition.y;
//						    Vector2 offsettp = new Vector2 (touchPosition.x + offsetx, touchPosition.y + offsety);
//						    block.transform.position = touchPosition;
//					}
//				}


//				for (int u = 0; u < 10; u++) {
//				    if (hit.collider.tag == "holder" + u.ToString()) {
//						block = GameObject.Find("holder" + u.ToString());
//                        texty.text = hit.collider.name;
//						if (Input.GetTouch (i).phase == touchPhaseMoving) {
//							texty.text = hit.collider.name + " moving";
//							Vector3 touchPosition = Camera.main.ScreenToWorldPoint (new Vector3 (touch.position.x, touch.position.y, 10));   
//							block.transform.position = Vector3.Lerp (block.transform.position, touchPosition, Time.deltaTime*1);
//						} 
//					}
//				}
			}
		}
		if (touchesnum > 0) {
			//texty.text = "Number of touches: " + touchesnum.ToString();
		}
		touchesnum = 0;
	}
}
