using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class loadgame : MonoBehaviour {
    
	public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
        
    }
    public void quit()
    {
        
        Application.Quit();
    }
}
