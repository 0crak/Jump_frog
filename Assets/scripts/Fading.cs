using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Fading : MonoBehaviour
{
    public Texture2D fadeOutTexture; //image na caly ekran 
    public float fadeSpeed = 0.8f; //Predkosc

    private int drawDepth = -1000;
    private float alpha = 1.0f;
    private int fadeDir = -1;
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

}
