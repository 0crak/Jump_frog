using UnityEngine;
using System.Collections;

public class arrowrot : MonoBehaviour {
    private float actual_angle = 40f;
    public GameObject strzalka;
    private Renderer material_strzalki;
    public float max_top = 120f;
    public float max_bot = 30f;
    public Color color = Color.green;
    public static float arrowColor;
    public GameObject parent;
	// Use this for initialization
	void Start () {
        //transform.rotation = parent.transform.rotation;
        material_strzalki= strzalka.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(arrowColor);
        material_strzalki.material.color = new Color(arrowColor, 1 - arrowColor,0, 1);
       // material_strzalki.material.color;
        
            //  transform.rotation = parent.transform.rotation;
            if (Input.GetKey(KeyCode.DownArrow) && actual_angle > max_bot)
            {
                transform.Rotate(Vector3.up);
                actual_angle -= 1;
            }
            if (Input.GetKey(KeyCode.UpArrow) && actual_angle < max_top)
            {

            transform.Rotate(Vector3.down);
                actual_angle += 1;
            }
        
    }
}
