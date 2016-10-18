using UnityEngine;
using System.Collections;

public class URLTweet : MonoBehaviour {
	private string term;

	void Start () {
		term = "newyork";
		string url = "https://s4316912-dailyplanet.uqcloud.net/search.php?term=" + term;
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}
}
