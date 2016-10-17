using UnityEngine;
using System.Collections;

public class touching : MonoBehaviour {
	public GUIText texti;
	int touchesnum = 0;
	void Start() {
		texti = GameObject.Find("displaytouches").GetComponent<GUIText>();
		print("test up");
	}
	void Update () 
	{
		//Touch myTouch = Input.GetTouch(0);
		Touch[] myTouches = Input.touches;
		for (int i = 0; i < Input.touchCount; i++) {
			print (i);
			touchesnum++;
			//Do something with the touches
		}
		if (touchesnum > 0) {
			texti.text = "Number of touches: " + touchesnum.ToString();
		}
		touchesnum = 0;
	}
}
