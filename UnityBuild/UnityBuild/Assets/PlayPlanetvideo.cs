using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayPlanetvideo : MonoBehaviour {

	public MovieTexture movie;


	void Start () {
		GetComponent<RawImage> ().texture = movie as MovieTexture;
		movie.loop = true;
		movie.Play();
	}

	void Update () {
    	if (Input.GetMouseButtonDown (0)) {
			Application.LoadLevel ("earthview");
		}
	}
}
