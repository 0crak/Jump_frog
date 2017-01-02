using UnityEngine;
using System.Collections;

public class frogcontroller : MonoBehaviour {

    //  public Animator anim;
    public float RotateSpeed = 22f;
    private float angle = 0;
	// Use this for initialization
	void Start () {
       // anim = GetComponent<Animation>();
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.up * RotateSpeed * Time.deltaTime);
            Debug.Log(transform);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up * RotateSpeed * Time.deltaTime);
            Debug.Log("lewo"+ transform);
        }
        if (Input.GetKey(KeyCode.W)&&angle<90)
        {
            angle += 1;
            Debug.Log(angle);
        }
        else if (Input.GetKey(KeyCode.S)&&angle>1)
        {
            angle -= 1;
            Debug.Log(angle);
        }
        if (Input.GetKeyDown("space"))
            {
          //  
            Debug.Log("skacze");
        }
	}
}
