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


    public FallingObject targetting;
    float targettingTime_ = 0;
    public int score;

    HashSet<FallingObject> foundedObjects_ = new HashSet<FallingObject> ();


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        distanceText.text = "Distance:" + transform.position.y + "m";
        scoreText.text = "Score:" + score;
        RaycastHit hitInfo;
        if (Physics.Raycast (new Ray (transform.position, transform.forward), out hitInfo)) {
            FallingObject fo = hitInfo.rigidbody.gameObject.GetComponent<FallingObject> ();
            if (fo != targetting && targetting == null) {
                EndCapture ();
            }
            if (fo != targetting && targetting != null) {
                targettingTime_ = 0;
                StartCapture (fo);
            }

            print (fo);
            targetting = fo;
        }
        if (targetting != null) {
            targettingTime_ += Time.deltaTime;
        }

        if (targettingTime_ > 2 && targetting != null) {
            //targetting.GetComponent<Collider> ().enabled = false;
            //print ("founded " + targetting +  "  score:" + targetting.score);
            score += targetting.score;
            targetting = null;
            targettingTime_ = 0;
            foundedObjects_.Add (targetting);
        }
    }

    GameObject sight_;

    void StartCapture (FallingObject target)
    {
        targetting = target;

        sight_ = Instantiate (this.captureingSight, target.transform.position, target.transform.rotation) as GameObject;
        sight_.transform.parent = targetting.transform;
        sight_.transform.localScale = new Vector3( 10, 10, 10);

    }

    void EndCapture ()
    {
        targetting = null;
        if (sight_ != null) {
            Destroy (sight_);
            sight_ = null;
        }
    }


}
