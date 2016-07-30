using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// 依存しているシーンの定義
// 初期化時にシーンを追加で読み込む
public class DependSceneLoader : MonoBehaviour
{
    public string sceneName;
    public bool initalDeactive = false;

    void Awake ()
    {
        if (!SceneManager.GetSceneByName (sceneName).IsValid()) {
            SceneManager.LoadScene (sceneName, LoadSceneMode.Additive);
        }
    }

    void Start ()
    {
        if (initalDeactive) {
            Scene gameScene = SceneManager.GetSceneByName (sceneName);
            foreach (var groot in gameScene.GetRootGameObjects ()) {
                groot.SetActive (false);
            }
        }
    }
}
