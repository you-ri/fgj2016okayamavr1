using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// 依存しているシーンの定義
// 初期化時にシーンを追加で読み込む
public class DependSceneLoader : MonoBehaviour
{
    public string sceneName;

    void Awake ()
    {
        if (!SceneManager.GetSceneByName (sceneName).IsValid()) {
            SceneManager.LoadScene (sceneName, LoadSceneMode.Additive);
        }
    }
}
