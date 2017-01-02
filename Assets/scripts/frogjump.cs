using UnityEngine;
using System.Collections;

public class frogjump : MonoBehaviour {
    public static bool dawajDalej=false;
    public GameObject glownyskryptolol;
    public GameObject strzalka;
    public GameObject skryptyskoku;
    public GameObject zabka;
    private Animation zabky;
    public float speed_of_jump = 2.0f;
    private LineRenderer fuker;
	// Use this for initialization
	void Start () {
        zabky = zabka.GetComponent<Animation>();
        zabky["jump_land"].speed = speed_of_jump;
        dawajDalej = true;
    }
	
	// Update is called once per frame
	void Update ()
    {

        if (dawajDalej == true)
        {
            //int foe = 10;
           
            Destroy(skryptyskoku.GetComponent<liniaskoku>());
            Destroy(glownyskryptolol.GetComponent<projectileArc>());

            fuker = skryptyskoku.GetComponent<LineRenderer>();
            fuker.SetWidth(0,1);
            skryptyskoku.AddComponent<liniaskoku>();
            glownyskryptolol.AddComponent<projectileArc>();
            dawajDalej = false;
            strzalka.SetActive(true);
            pasek.stopscript = false;
            liniaskoku.stopscript = false;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            pasek.stopscript = true;
            liniaskoku.stopscript = true;
          //  CAMERA_FOLLOW_FROG.sledzenie_zabki = true;
            niszczenieliscia_ojca.skok_sie_odbyl_zniszcz_liscia = true;

            
            zabky.Play("jump_land");
            strzalka.SetActive(false);
            
        }
	    
    }
}
