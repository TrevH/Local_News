using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text.RegularExpressions;

public class mastercontroller : MonoBehaviour {

	//public GameObject NewsBox;
	public static GameObject[] selectorArrNewsBox;
	public static GameObject[] selectorArrTweeterBox;
	public static string term;
	public static string geocode;
	public static string city;
	public static Boolean NewsChoosen = false;
	public static Boolean RefreshNews = false;
	public static string newsSource = "abc-news-au";
	private List<string> tweets;
	private List<string> newsArticles;
	private List<Texture2D> icons;
	private Boolean done = false;
	private int indexOfNewsTitle;
	private int indexOfNewsDesc;
	private int indexOfNewsImage;
	private Boolean tweetBegun = false;
	// Use this for initialization
	void Start () {
		tweets = new List<string>();
		newsArticles = new List<string> ();
		icons = new List<Texture2D> ();
		indexOfNewsTitle = -1;
		indexOfNewsDesc = -1;
		indexOfNewsImage = -1;
		//term = "election";
		//string newsSource = "abc-news-au";
		getNewsData (newsSource);
//		string url = "https://newsapi.org/v1/articles?source="+ newsSource+ "&apiKey=" + "015941290283434faa7a32ec94c6b87e";
//
//		WWW www = new WWW(url);
//		StartCoroutine(NewWaitForRequest(www));
//		term = "election";
//		geocode = "-27.497168,153.011441,100mi";
//		url = "https://s4316912-dailyplanet.uqcloud.net/search.php?term=" + term + "&geocode=" + geocode;
//	    www = new WWW(url);
//		StartCoroutine(WaitForRequest(www));
		// end of html
	}

	void getNewsData(string newsSourceL){
		string url = "https://newsapi.org/v1/articles?source="+ newsSourceL+ "&apiKey=" + "015941290283434faa7a32ec94c6b87e";
		WWW www = new WWW(url);
		StartCoroutine(NewWaitForRequest(www));
	}

	void getTweetData(string term, string geocode){
		string url = "https://s4316912-dailyplanet.uqcloud.net/search.php?term=" + term + "&geocode=" + geocode;
		WWW www = new WWW(url);
		StartCoroutine(WaitForRequest(www));
	}

	void spawnTweetObjects(){
		selectorArrTweeterBox = new GameObject[7];
		//int tweetssize = tweets.Count;
		Boolean rotatelock = false;
		Debug.Log (geocode);
		for (int i = 0; i < 7; i++) {
			GameObject hold;
//			Transform usericont;
//			Transform usertext;
			Transform twitterperson;
//			Texture2D test;
			string twittertext = getElement (i * 3 +1);
			if (rotatelock) {
				hold = Instantiate (Resources.Load ("TwitterHolder"), new Vector3 (1.21f, 3.4f - (0.8f * i), 7), Quaternion.Euler (0, 0, 0)) as GameObject;
				rotatelock = false;
			} else {
				hold = Instantiate (Resources.Load ("TwitterHolder"), new Vector3 (-1.21f, 3.4f - (0.8f * i), 7), Quaternion.Euler (0, 0, 0)) as GameObject;
				rotatelock = true;
			}
			//icon
			//						test = icons.ElementAt (i);
			//						Rect rec = new Rect(0, 0, test.width, test.height);
			//						Sprite hello = Sprite.Create(test, rec, new Vector2(0, 0), 1);
			//						usericont = hold.transform.GetChild (1);
			//						usericont.GetComponent<SpriteRenderer> ().sprite = hello;
			//
			twitterperson = hold.transform.GetChild (0);
			twitterperson.GetComponent<TextMesh> ().text = getElement (i * 3);
			twitterperson = hold.transform.GetChild (3);
			twitterperson.GetComponent<TextMesh> ().text = sortString(twittertext);
			selectorArrTweeterBox [i] = hold;
		}
	}

	void spawnObjects(){
		selectorArrNewsBox = new GameObject[6];
		Boolean rotatelock = false;
		for (int i = 0; i < 6; i++) {
			GameObject hold;
			Transform newscard;
			if (rotatelock) {
				hold = Instantiate (Resources.Load ("NewsHolder"), new Vector3 (-6.21f, 3.4f - (1.2f * i), 7), Quaternion.Euler (0, 0, 0)) as GameObject;
				rotatelock = false;
			} else {
				hold = Instantiate (Resources.Load ("NewsHolder"), new Vector3 (6.21f, 3.4f - (1.2f * i), 7), Quaternion.Euler (0, 0, 0)) as GameObject;
				rotatelock = true;
			}
			newscard = hold.transform.GetChild (1);
			newscard.GetComponent<TextMesh> ().text = sortNewsStringTitle(getNewsTitle(i));
			newscard = hold.transform.GetChild (0);
			newscard.GetComponent<TextMesh> ().text = sortNewsString(getNewsStory(i));

//			WWW www = new WWW (getNewsImage(i));
//			GrabIcon (www, hold);


			selectorArrNewsBox [i] = hold;

		}
	}

	IEnumerator WaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			Debug.Log("WWW Ok!: " + www.text);
			sortResponse (www);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}

	IEnumerator NewWaitForRequest(WWW www)
	{
		yield return www;

		// check for errors
		if (www.error == null)
		{
			sortNewsResponse (www);
			Debug.Log("WWW Ok!: " + www.text);
		} else {
			Debug.Log("WWW Error: "+ www.error);
		}    
	}

	private string sortString(string data){
		string lineSeparator = ((char) 0x2028).ToString();
		string paragraphSeparator = ((char)0x2029).ToString();
		String modified = data.Replace("\r\n", string.Empty).Replace("\n", string.Empty).Replace("\r", string.Empty).Replace(lineSeparator, string.Empty).Replace(paragraphSeparator, string.Empty);
		modified = Regex.Replace(modified, @"((([A-Za-z]{3,9}:(?:\/\/)?)(?:[-;:&=\+\$,\w]+@)?[A-Za-z0-9.-]+|(?:www.|[-;:&=\+\$,\w]+@)[A-Za-z0-9.-]+)((?:\/[\+~%\/.\w-_]*)?\??(?:[-\+=&;%@.\w_]*)#?(?:[\w]*))?)", string.Empty);
		int length = modified.Length;
		if(length>35){
			modified = modified.Insert (35, System.Environment.NewLine);
			if (length > 57) {
				modified = modified.Insert (57, System.Environment.NewLine);
				if (length > 79) {
					modified = modified.Insert (79, System.Environment.NewLine);
					if (length > 101) {
						modified = modified.Insert (101, System.Environment.NewLine);
						if (length > 123) {
							modified = modified.Insert (123, System.Environment.NewLine);
						}
					}
				}
			}
		}
		return modified;
	}

	private string sortNewsString(string data){
		String modified = data;


		int length = modified.Length;
		if(length>45){
			modified = modified.Insert (45, System.Environment.NewLine);
			if (length > 90) {
				modified = modified.Insert (90, System.Environment.NewLine);
				if (length > 135) {
					modified = modified.Insert (135, System.Environment.NewLine);
					if (length > 170) {
						modified = modified.Insert (170, System.Environment.NewLine);
						if (length > 205) {
							modified = modified.Insert (205, System.Environment.NewLine);
						}
					}
				}
			}
		}
		return modified;
	}

	private string sortNewsStringTitle(string data){
		String modified = data;


		int length = modified.Length;
		if(length>38){
			modified = modified.Insert (38, System.Environment.NewLine);
			if (length > 76) {
				modified = modified.Insert (76, System.Environment.NewLine);
			}
		}
		return modified;
	}

	private void sortResponse(WWW data){
		tweets = new List<string>();
		string text = data.text;
		string[] hold = text.Split (new string[] { " :? " }, StringSplitOptions.None); 
		tweets = hold.ToList();
		tweets.RemoveAt (0);
		foreach (string item in tweets) {
			//Debug.Log (item);
		}
		spawnTweetObjects ();
		//for (int i = 0; i < 6; i++) {
			//WWW www = new WWW (tweets.ElementAt (0 * 3));
			//GrabIcon (www);
		//}
	}

	private void sortNewsResponse(WWW data){
		string text = data.text;
		string split1 = '"'.ToString() + "," + '"'.ToString();
		text = text.Substring(text.IndexOf(":[{") + 3);
		text = text.Replace("}]}", "");
		string[] hold = text.Split (new string[] { "},{", split1, "\":\"" }, StringSplitOptions.None); 
		newsArticles = hold.ToList();
		while (newsArticles.Contains ("\"author\":null,\"title")) {
			int indexNews = newsArticles.IndexOf ("\"author\":null,\"title");
			newsArticles.RemoveAt (indexNews);
			newsArticles.Insert (indexNews, "title");
		}
		//newsArticles.RemoveAll(item => item.Contains("\"author"));
		foreach (string item in newsArticles) {
			//Debug.Log (item);
		}
		done = true;
	}

	IEnumerator GrabIcon(WWW www, GameObject hold){
		yield return www;
		icons.Add (www.texture);
		Texture2D test;

		test = www.texture;
		Rect rec = new Rect(0, 0, test.width, test.height);
		Sprite hello = Sprite.Create(test, rec, new Vector2(0, 0), 1);
		Transform newscard = hold.transform.GetChild (3);
		newscard.GetComponent<SpriteRenderer> ().sprite = hello;
		newscard.GetComponent<MeshRenderer> ().sortingLayerName = "Jon";
		newscard.GetComponent<MeshRenderer> ().sortingOrder = 5;
	}

	string getElement(int i){
		return tweets.ElementAt (i);
	}

	string getNewsTitle(int i){
		indexOfNewsTitle = newsArticles.IndexOf ("title", indexOfNewsTitle+1);
		return newsArticles.ElementAt(indexOfNewsTitle+1);
	}

	string getNewsStory(int i){
		indexOfNewsDesc = newsArticles.IndexOf ("description", indexOfNewsDesc+1);
		return newsArticles.ElementAt(indexOfNewsDesc+1);
	}

	string getNewsImage(int i){
		indexOfNewsImage = newsArticles.IndexOf ("urlToImage", indexOfNewsImage+1);
		return newsArticles.ElementAt(indexOfNewsImage+1);
	}

	void FixedUpdate(){
		if (done) {
			spawnObjects ();
			done = false;
		}
		if (NewsChoosen) {
			if (tweetBegun) {
				for (int i = 0; i < 7; i++) {
					Destroy(selectorArrTweeterBox[i]);
				}
			}
			getTweetData (city, geocode);
			NewsChoosen = false;
			tweetBegun = true;
		}
		if (RefreshNews) {
			for (int i = 0; i < 6; i++) {
				Destroy(selectorArrNewsBox[i]);
			}
			getNewsData (newsSource);
			RefreshNews = false;
		}
	}
}