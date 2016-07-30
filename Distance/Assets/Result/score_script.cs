using UnityEngine;
using System.Collections;

public class score_script : MonoBehaviour {

	public GameObject score;
	int i = 10;

	// Use this for initialization
	void Start () {
		score.GetComponent<TextMesh>().text = i + "Pt";
	}

	// Update is called once per frame
	void Update () {
		score.GetComponent<TextMesh>().text = i + "Pt";
	}
}
