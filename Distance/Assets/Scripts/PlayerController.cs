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
    public GameObject lockOn;
    public GameObject speedLine;
    public float maxVelocityY = 150;
    public Transform head;
    public float lockOnTime = 0.5f;

    public FallingObject targetting;
    float targettingTime_ = 0;
    public int score;

    HashSet<FallingObject> foundedObjects_ = new HashSet<FallingObject> ();
    Rigidbody rigidbody_;
    LevelManager levelManager_;

    // Use this for initialization
    void Start () {
        rigidbody_ = GetComponent<Rigidbody> ();
    }

    // Update is called once per frame
    void Update ()
    {
        distanceText.text = "Distance:" + transform.position.y + "m";
        scoreText.text = "Score:" + score;

        if (levelManager_ == null) {
            levelManager_ = FindObjectOfType<LevelManager> ();
        }
        if (levelManager_ != null && levelManager_.gaming == false) {
            return;
        }

        RaycastHit hitInfo;

        if (Physics.Raycast( head.position, head.forward, out hitInfo, 500.0f, 1 << 9)) {
            if (hitInfo.rigidbody != null) {
                FallingObject fo = hitInfo.rigidbody.gameObject.GetComponent<FallingObject> ();
                if (fo != targetting && fo == null) {
                    EndCapture ();
                }
                if (fo != targetting && fo != null) {
                    StartCapture (fo);
                }
            }
        }
        if (targetting != null) {
            targettingTime_ += Time.deltaTime;
        }

        if (targettingTime_ > lockOnTime && targetting != null) {
            AddCaptured (targetting);
            //targetting.GetComponent<Collider> ().enabled = false;
            //print ("founded " + targetting +  "  score:" + targetting.score);
            targetting = null;
            targettingTime_ = 0;
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
        targettingTime_ = 0;
    }

    void EndCapture ()
    {
        targetting = null;
        if (sight_ != null) {
            //Destroy (sight_);
            sight_ = null;
        }
    }

    void AddCaptured (FallingObject fo)
    {
        if (foundedObjects_.Contains (fo)) return;

        score += fo.score;

        print ("captred");
        sight_ = Instantiate (this.captureingSight, fo.transform.position, fo.transform.rotation) as GameObject;
        sight_.transform.parent = fo.transform;
        sight_.transform.localScale = new Vector3 (10, 10, 10);

        foundedObjects_.Add (fo);

        Instantiate (this.lockOn, fo.transform.position, fo.transform.rotation);
    }

    public void EndGame ()
    {
        Destroy (speedLine);
    }

}
