using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public TextMesh text;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        text.text = "Distance:" + transform.position.y + "m";
	}
}
