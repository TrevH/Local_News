using UnityEngine;
using System.Collections;

public class TextSorting : MonoBehaviour {

	public string SortingLayerName = "Jon";
	public int SortingOrder = 5;

	void Awake ()
	{
		gameObject.GetComponent<MeshRenderer> ().sortingLayerName = SortingLayerName;
		gameObject.GetComponent<MeshRenderer> ().sortingOrder = SortingOrder;
	}
}
