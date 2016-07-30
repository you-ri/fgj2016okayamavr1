using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {


    public PlayerController player;

    public FallingObject iwa;

    float nextSpawnTime_;

    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {

        nextSpawnTime_ -= Time.deltaTime;
        if (nextSpawnTime_ <= 0) {
            FallingObject iwao = Instantiate (iwa, player.transform.position + Vector3.up * -500, Quaternion.identity) as FallingObject;
            float rad = Random.Range (0, 360) * Mathf.Deg2Rad;
            float distance = 10;
            float addforcex = Mathf.Sin (rad) * distance;
            float addforcey = Mathf.Cos (rad) * distance;
            iwao.transform.position = iwao.transform.position + new Vector3 (addforcex, 0f, addforcey);
            nextSpawnTime_ = 1;
        }

	}
}
