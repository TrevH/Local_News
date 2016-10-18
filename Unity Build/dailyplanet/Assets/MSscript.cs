using UnityEngine;
using System.Collections;

public class MSscript : MonoBehaviour {
	//public GameObject NewsBox;
	public static GameObject[] selectorArrNewsBox;
	public static GameObject[] selectorArrTweeterBox;
	// Use this for initialization
	void Start () {
		selectorArrNewsBox = new GameObject[6];
		selectorArrTweeterBox = new GameObject[6];
		for (int i = 0; i < 6; i++) {
			GameObject hold = Instantiate (Resources.Load ("NewsBox"), new Vector3 (-5.21f, 3.4f-(1.2f*i), 7), Quaternion.Euler (0, 0, 0)) as GameObject;
			selectorArrNewsBox [i] = hold;
			hold = Instantiate (Resources.Load ("TweeterBox"), new Vector3 (6.21f, 3.4f-(1.2f*i), 7), Quaternion.Euler (0, 0, 0)) as GameObject;
			selectorArrTweeterBox [i] = hold;
//			Instantiate (Resources.Load ("NewsBox"), new Vector3 (-5.21f, 3.4f, 7), Quaternion.Euler (0, 0, 0));
//			Instantiate (Resources.Load ("NewsBox"), new Vector3 (-5.21f, 2.2f, 7), Quaternion.Euler (0, 0, 0));
//			Instantiate (Resources.Load ("NewsBox"), new Vector3 (-5.21f, 1.0f, 7), Quaternion.Euler (0, 0, 0));
//			Instantiate (Resources.Load ("NewsBox"), new Vector3 (-5.21f, -0.2f, 7), Quaternion.Euler (0, 0, 0));
//			Instantiate (Resources.Load ("NewsBox"), new Vector3 (-5.21f, -1.4f, 7), Quaternion.Euler (0, 0, 0));
//			Instantiate (Resources.Load ("NewsBox"), new Vector3 (-5.21f, -2.6f, 7), Quaternion.Euler (0, 0, 0));
		}

//		Instantiate(Resources.Load("TweeterBox"), new Vector3(6.21f, 3.4f, 7), Quaternion.Euler(0, 0, 0));
//		Instantiate(Resources.Load("TweeterBox"), new Vector3(6.21f, 2.2f, 7), Quaternion.Euler(0, 0, 0));
//		Instantiate(Resources.Load("TweeterBox"), new Vector3(6.21f, 1.0f, 7), Quaternion.Euler(0, 0, 0));
//		Instantiate(Resources.Load("TweeterBox"), new Vector3(6.21f, -0.2f, 7), Quaternion.Euler(0, 0, 0));
//		Instantiate(Resources.Load("TweeterBox"), new Vector3(6.21f, -1.4f, 7), Quaternion.Euler(0, 0, 0));
//		Instantiate(Resources.Load("TweeterBox"), new Vector3(6.21f, -2.6f, 7), Quaternion.Euler(0, 0, 0));
	}

	// Update is called once per frame
	void Update () {
	
	}
}
