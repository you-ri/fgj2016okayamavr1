using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public bool isIdling = true;
    public PlayerController player;


    // Use this for initialization
    void Start () {
        player = FindObjectOfType<PlayerController> ();
        isIdling = true;

    }
	
	// Update is called once per frame
	void Update () {

        // 下を向くとゲームスタート
        if (player.head.forward.y <= -0.8f && isIdling) {
            StartGame ();

        }
	}

    void StartGame ()
    {
        SceneManager.LoadScene ("Game", LoadSceneMode.Additive);
        isIdling = false;
    }
}
