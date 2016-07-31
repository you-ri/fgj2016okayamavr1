using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    class FoundData
    {
        public int point;
        public int id;
    }

    public TextMesh distanceText;
    public TextMesh scoreText;
    public GameObject captureingSight;
    public float maxVelocityY = 150;
    public Transform head;
    public float lockOnTime = 0.5f;

    public FallingObject targetting;
    float targettingTime_ = 0;
    public int score;

    HashSet<FallingObject> foundedObjects_ = new HashSet<FallingObject> ();
    Rigidbody rigidbody_;

	// Use this for initialization
	void Start () {
        rigidbody_ = GetComponent<Rigidbody> ();
    }
	
	// Update is called once per frame
	void Update ()
    {
        distanceText.text = "Distance:" + transform.position.y + "m";
        scoreText.text = "Score:" + score;
        RaycastHit hitInfo;

        if (Physics.Raycast( head.position, head.forward, out hitInfo, 500.0f, 1 << 9)) {
            if (hitInfo.rigidbody != null) {
                print (hitInfo.collider);
                FallingObject fo = hitInfo.rigidbody.gameObject.GetComponent<FallingObject> ();
                if (fo != targetting && fo == null) {
                    EndCapture ();
                }
                if (fo != targetting && fo != null) {
                    targettingTime_ = 0;
                    StartCapture (fo);
                }

                targetting = fo;
            }
        }
        if (targetting != null) {
            targettingTime_ += Time.deltaTime;
        }

        if (targettingTime_ > lockOnTime && targetting != null) {
            //targetting.GetComponent<Collider> ().enabled = false;
            //print ("founded " + targetting +  "  score:" + targetting.score);
            score += targetting.score;
            targetting = null;
            targettingTime_ = 0;
            foundedObjects_.Add (targetting);
        }

        // 最大速度を設定
        if (rigidbody_.velocity.y < -maxVelocityY) {
            rigidbody_.velocity = new Vector3 (0, -maxVelocityY, 0);
        }
    }

    GameObject sight_;

    void StartCapture (FallingObject target)
    {
        if (target == null) {
            EndCapture ();
            return;
        }
        targetting = target;

        sight_ = Instantiate (this.captureingSight, targetting.transform.position, targetting.transform.rotation) as GameObject;
        sight_.transform.parent = targetting.transform;
        sight_.transform.localScale = new Vector3( 10, 10, 10);

    }

    void EndCapture ()
    {
        targetting = null;
        if (sight_ != null) {
            //Destroy (sight_);
            sight_ = null;
        }
    }


}
