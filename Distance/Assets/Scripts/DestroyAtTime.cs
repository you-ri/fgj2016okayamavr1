using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DestroyAtTime : MonoBehaviour
{
    public float time;

    void Awake ()
    {
    }

     void Update ()
    {
        time -= Time.deltaTime;
        if (time < 0 ) {
            Destroy (this.gameObject);
        }
    }
}
