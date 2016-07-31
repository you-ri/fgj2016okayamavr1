using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public bool isStarting = false;
    public PlayerController player;

    void Awake ()
    {
        if (!SceneManager.GetSceneByName ("Game").IsValid ()) {
            SceneManager.LoadScene ("Game", LoadSceneMode.Additive);
        }
    }

    // Use this for initialization
    void Start ()
    {
        player = FindObjectOfType<PlayerController> ();
        isStarting = false;
    }
	
	// Update is called once per frame
	void Update () {

        // 下を向くとゲームスタート
        if (player.head.forward.y <= -0.8f && !isStarting) {
            StartGame ();
        }
	}

    void StartGame ()
    {
        {
            Scene gameScene = SceneManager.GetSceneByName ("Game");
            foreach (var groot in gameScene.GetRootGameObjects ()) {
                groot.SetActive (true);
            }
        }
        {
            Scene gameScene = SceneManager.GetSceneByName ("Level1");
            foreach (var groot in gameScene.GetRootGameObjects ()) {
                groot.SetActive (true);
            }
        }
        isStarting = true;
    }
}
