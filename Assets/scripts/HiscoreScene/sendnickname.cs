using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sendnickname : MonoBehaviour {
    public InputField inpucik;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (inpucik.text != "" && Input.GetKeyDown(KeyCode.Return))
        {
            PlayerPrefs.SetString("nick", inpucik.text);
            inpucik.text = "";
            SceneManager.LoadScene("restart");
        }
    }
}
