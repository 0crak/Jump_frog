using UnityEngine;
using System.Collections;


public class pasek : MonoBehaviour
{
    public bool zawracamy = false;
    public float barDisplay; //current progress
    
    public Vector2 pos = new Vector2(300, 400);
    public Vector2 size = new Vector2(300, 20);
    public Texture2D emptyTex;
    private float wysoko, szero;
    public Texture2D fullTex;
    public float speed=1f;
    public static bool stopscript = false;
    
    void OnGUI()
    {
        szero=Screen.width;
        wysoko=Screen.height;
        //draw the background:
        GUI.BeginGroup(new Rect(wysoko-wysoko/3,szero/2, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(-20,-20,340,100), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    void Update()
    {
        if (stopscript == false)
        {

       
            if (zawracamy == false)
        {
            barDisplay +=(speed/100);
            if (barDisplay >1)
            { zawracamy = true;
            }
        }
        else
        {
            barDisplay -= (speed / 100);
            if (barDisplay < 0)
            {
                zawracamy = false;
            }

           
            
        }
        liniaskoku.myVelocityPrzelicznik = (barDisplay+0.02f);
            arrowrot.arrowColor = barDisplay;
    }
         }
}