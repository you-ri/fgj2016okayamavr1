using UnityEngine;
using System.Collections;

public class value_script : MonoBehaviour {

	public GameObject value;
	int i = 3000;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (i < 1000) {
			value.GetComponent<TextMesh> ().text = "まだまだだね";
		} else if (i < 2000) {
			value.GetComponent<TextMesh> ().text = "悪くはないと思う";
		} else if (i < 3000) {
			value.GetComponent<TextMesh> ().text = "なかなかやるね";
		} else if (i < 4000) {
			value.GetComponent<TextMesh> ().text = "素晴らしい！";
		} else if (i >= 4000) {
			value.GetComponent<TextMesh> ().text = "あなたが神か";
		}
	}
}
