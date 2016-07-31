using UnityEngine;
using System.Collections;

public class score_script : MonoBehaviour {

	public GameObject score;


    public void SetScore (int point)
    {
        score.GetComponent<TextMesh> ().text = point + "Pt";
    }
}
