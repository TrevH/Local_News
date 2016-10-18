using UnityEngine;
using System.Collections;

public class TextSorting : MonoBehaviour {

	public string SortingLayerName = "four";
	public int SortingOrder = 10;

	void Awake ()
	{
		gameObject.GetComponent<MeshRenderer> ().sortingLayerName = SortingLayerName;
		gameObject.GetComponent<MeshRenderer> ().sortingOrder = SortingOrder;
	}

}
