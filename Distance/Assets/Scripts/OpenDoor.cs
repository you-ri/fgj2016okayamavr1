using UnityEngine;
using System.Collections;

public class OpenDoor : MonoBehaviour {
	float z = 0f;					//z軸の回転
	public int code = 1;			//回転の方向、符号
	public float count = 0f;		//回転時間

    TitleManager title;

	// Use this for initialization
	void Start () {
        title = FindObjectOfType<TitleManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		//スタート画面の演出、扉の開閉
		//本来はレイキャストで処理するが、テストのためにSpaceキーによる処理
		if (title.isStarting && count < 1.7f) {
			transform.Rotate (new Vector3 (0, 0, z));
			z += Time.deltaTime * code;
			count += Time.deltaTime * 1f;
		} else {
			//countが一定以上になると、開閉をしなくなる
			z += 0f;
		}
	}
}
