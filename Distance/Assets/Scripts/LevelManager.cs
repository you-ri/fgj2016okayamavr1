using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public PlayerController player;

    public FallingObject iwa;

    float nextSpawnTime_;
    bool gaming = false;

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<PlayerController> ();
        gaming = true;
	}
	
	// Update is called once per frame
	void Update ()
    {
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

        if (player.transform.position.y <= 10 && gaming == true) {
            EndGame ();
        }
	}

    void EndGame ()
    {
        StartCoroutine ("DoResultCheck");
        gaming = false;
        FindObjectOfType<score_script> ().SetScore(FindObjectOfType<PlayerController> ().score);
    }

    // 着地から一定時間でタイトルに戻る
    IEnumerator DoResultCheck ()
    {
        yield return new WaitForSeconds (10f);
        SceneManager.LoadScene ("Title", LoadSceneMode.Single);
    }
}
