using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnArea : MonoBehaviour
{
    void Awake ()
    {
        foreach( Transform obj in transform) {
            obj.gameObject.SetActive (false);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            print ("spawn " + this.name);
            foreach (Transform obj in transform) {
                obj.gameObject.SetActive (true);
            }
        }
    }

}
