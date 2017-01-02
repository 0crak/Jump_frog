using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class count_points : MonoBehaviour {

    public Text score;
    private int punkty=0;
    public static bool dodaj = false;
	// Use this for initialization
	void Start () {
        punkty = 0;
        score.text = "SCORE" + punkty.ToString();
        PlayerPrefs.SetInt("round score", punkty);
        dodaj = false;

    }
	
	// Update is called once per frame
	void Update () {
     //   Debug.Log(punkty);
	if(dodaj==true)
        {
            punkty += 50;
            score.text = "SCORE" + punkty.ToString();
            dodaj = false;
            PlayerPrefs.SetInt("round score", punkty);
        }
	}

}
