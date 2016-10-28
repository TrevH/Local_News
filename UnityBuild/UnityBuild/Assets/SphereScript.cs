using UnityEngine;
using System.Collections;

public class SphereScript : MonoBehaviour {

	private string brisbane = "-27.497168,153.011441,100mi";
	private string london = "51.507351,-0.127758,200mi";
	private string copenhagen = "55.676091,12.568337,200mi";
	private string bundaberg = "-24.866974,152.35097,100mi";
	private string beijing = "37.482423,114.693426,200mi";
	private string toronto = "43.655226,-79.883184,200mi";
	private string islamabad = "33.729388,73.093146,100mi";
	private string mumbai = "19.075984,72.877656,100mi";
	private string newyork = "40.712784,-74.005941,100mi";


	void OnMouseDown()
	{
		if (this.transform.name == "Brisbane") {
			mastercontroller.geocode = brisbane;
			mastercontroller.city = "Brisbane";
			mastercontroller.newsSource = "abc-news-au";
		} else if (this.transform.name == "London") {
			mastercontroller.geocode = london;
			mastercontroller.city = "London";
			mastercontroller.newsSource = "daily-mail";
		} else if (this.transform.name == "Copenhagen") {
			mastercontroller.geocode = copenhagen;
			mastercontroller.city = "Copenhagen";
		} else if (this.transform.name == "Bundaberg") {
			mastercontroller.geocode = bundaberg;
			mastercontroller.city = "Bundaberg";
			mastercontroller.newsSource = "abc-news-au";
		} else if (this.transform.name == "NewYork") {
			mastercontroller.geocode = newyork;
			mastercontroller.city = "NewYork";
			mastercontroller.newsSource = "the-wall-street-journal";
		} else if (this.transform.name == "Mumbai") {
			mastercontroller.geocode = mumbai;
			mastercontroller.city = "Mumbai";
			mastercontroller.newsSource = "the-times-of-india";
		} else if (this.transform.name == "Islamabad") {
			mastercontroller.geocode = islamabad;
			mastercontroller.city = "Islamabad";
			mastercontroller.newsSource = "the-times-of-india";
		} else if (this.transform.name == "Toronto") {
			mastercontroller.geocode = toronto;
			mastercontroller.city = "Toronto";
			mastercontroller.newsSource = "the-wall-street-journal";
		} else if (this.transform.name == "Beijing") {
			mastercontroller.geocode = beijing;
			mastercontroller.city = "Beijing";
		} else {
			mastercontroller.geocode = brisbane;
			mastercontroller.city = "Brisbane";
			mastercontroller.newsSource = "abc-news-au";
			Debug.Log ("no city");
		}
		Application.LoadLevel ("newmainInterface");
	}
}
