using UnityEngine;
using System.Collections;

public class SoundScript : MonoBehaviour {

	public AudioClip audioClip1;
	public AudioClip audioClip2;
	AudioSource audioSource1;
	AudioSource audioSource2;

	// Use this for initialization
	void Start () {
		audioSource1 = gameObject.GetComponent<AudioSource>();
		audioSource2 = gameObject.GetComponent<AudioSource>();
		audioSource1.clip = audioClip1;
		audioSource2.clip = audioClip2;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {
		audioSource1.Stop();
		audioSource2.Play();
	}
}
