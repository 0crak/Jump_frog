using UnityEngine;
using System.Collections;

public class putleafs : MonoBehaviour {

    public int ilosc_lisci=0;
    public GameObject preflisc;
    public GameObject zabka;
    private Vector3 spawnpoin;
    private Vector3 l1;
    private Vector3 l2;
    private Vector3 l3;
    private Vector3 l4;
    
    private GameObject li1,li2,li3,li4;
    public static bool rob;
    public bool niszczonko;
    private GameObject tmp;

    public GameObject leaf_starter;

    private GameObject[] liscie=new GameObject[4];


    void Start ()
    {
       
        zabka = GameObject.FindGameObjectWithTag("Player");
        ustaw_liscie();
    }
	

	void Update ()
    {
       
        if (rob)
        {
         zniszcz_stare();
         niszczonko = true;
         ustaw_liscie();          
        }
       
       
    }
    void ustaw_liscie()
    {
        rob = false;
        //Debug.Log("poczatek lisci"+rob);
      
        spawnpoin.Set(zabka.transform.position.x, zabka.transform.position.y, zabka.transform.position.z);
        l1.Set((spawnpoin.x + Random.Range(-7.0f, -5.0f)),0.6f, spawnpoin.z + (Random.Range(-7.0f, 7.0f)));
        l2.Set((spawnpoin.x + Random.Range(-4.5f, 4.5f)), 0.6f, spawnpoin.z + (Random.Range(7f, 3.0f)));
        l3.Set((spawnpoin.x + Random.Range(-4.5f, 4.5f)), 0.6f, spawnpoin.z + (Random.Range(-3f, -7.0f)));
        l4.Set((spawnpoin.x + Random.Range(7.0f, 5.0f)),  0.6f, spawnpoin.z + (Random.Range(-7.0f, 7.0f)));
 

        li1 = (GameObject)Instantiate(preflisc, l1, Quaternion.identity);
        li2 = (GameObject)Instantiate(preflisc, l2, Quaternion.identity);
        li3 = (GameObject)Instantiate(preflisc, l3, Quaternion.identity);
        li4 = (GameObject)Instantiate(preflisc, l4, Quaternion.identity);

        liscie[0]=li1;
        liscie[1]=li2;
        liscie[2]=li3;
        liscie[3]=li4;

    }
 void zniszcz_stare()
 {     
    if(niszczonko==true)
     {
        // GameObject.Destroy(li1);
       //  GameObject.Destroy(li2);
       //  GameObject.Destroy(li3);
       //  GameObject.Destroy(li4);
        niszczonko = false;
     }
 }

    public void rozruchskryptu(GameObject nowyojciec)
    {
        leaf_starter = nowyojciec;

        foreach (GameObject lisc in liscie)
        {
            if (lisc.transform.position != nowyojciec.transform.position)
            {
                lisc.AddComponent<topienieiusuniecie>();
                projectileArc.follow = false;

            }
            else
                lisc.AddComponent<niszczenieliscia_ojca>();

        }
        rob = true;
    }
//
// if(li1.transform.position==nowyojciec.transform.position)
// { Debug.Log("no jest taki jeden"); }
// if (li2.transform.position == nowyojciec.transform.position)
// { Debug.Log("no jest taki jeden"); }
// if (li3.transform.position == nowyojciec.transform.position)
// { Debug.Log("no jest taki jeden"); }
// if (li4.transform.position == nowyojciec.transform.position)
// { Debug.Log("no jest taki jeden"); }
// Debug.Log("atu kto"+nowyojciec);
// Debug.Log("atu kto" + nowyojciec.transform.position);
//

    
  
}
