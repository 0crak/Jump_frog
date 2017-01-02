using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class koniecgry : MonoBehaviour
{
    public Texture2D fadeOutTexture; //image na caly ekran 
    public float fadeSpeed = 0.2f; //Predkosc
    public static bool odpalamy;
    private int drawDepth = -1000;
    private float alpha = 0.0f;
    private int fadeDir = 1;
    public static string nextlvl="restart";
    void Start()
    {
        nextlvl = "restart";
    }
    void OnGUI()
    {
        //fade out/in the alpha value.
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        //zmiana alphy na 0 lub 1
        alpha = Mathf.Clamp01(alpha);

        //set color of our GUI
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        GUI.depth = drawDepth;
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }
    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed);
    }
    void Update()
    {
        if (alpha==1)
        {
            SceneManager.LoadScene(nextlvl);
        }
   //     Debug.Log(alpha);
    }
  
}
