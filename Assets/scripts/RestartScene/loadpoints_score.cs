using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class loadpoints_score : MonoBehaviour
{
    public Text score;
    public Text hiscore_and_nick;
    private string nick;
    private int round_score;
    private int hi_score;

    // Use this for initialization
    void Start()
    {
        SceneManager.UnloadScene("_main");
        round_score = PlayerPrefs.GetInt("round score");
        hi_score = PlayerPrefs.GetInt("Player Score");
        nick = PlayerPrefs.GetString("nick");
        settext();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            
            SceneManager.LoadScene("_main");

        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Application.Quit();
        }
    }
    void settext()
    {
        
        score.text = "Score:      " + round_score;
        hiscore_and_nick.text = "Best Score: " + hi_score + " by: " + nick;

    }
}