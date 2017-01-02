using UnityEngine;
using System.Collections;

public class savepointsandload : MonoBehaviour {
   // private float coss = 2f;
    private int gamescore;
    private int roundscore;
    void Start()
    {
        gamescore = PlayerPrefs.GetInt("Player Score");
        roundscore = PlayerPrefs.GetInt("round score");

    }
    void Update()
    {
        roundscore = PlayerPrefs.GetInt("round score");
        if (roundscore>gamescore+1)
        {
            PlayerPrefs.SetInt("Player Score", roundscore);
            koniecgry.nextlvl = "enteryounick";
        }
       
    }
    
}

