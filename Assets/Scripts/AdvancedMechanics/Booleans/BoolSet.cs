using UnityEngine;
using System.Collections;

public class BoolSet : MonoBehaviour 
{
    public int comparisionType;

    public boolCheck Parent;

    public GameObject myGate;
    public GameObject othGate;

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            transform.GetComponent<Collider2D>().enabled = false;

            if(myGate)
               myGate.SetActive(true);
            if (othGate)
                othGate.SetActive(true);


            switch (comparisionType)
            {
                case 1:
                    Parent.Win = true;
                    break;
                case 2:
                    Parent.Win = false;
                    break;
                    /*
                case 3:
                    Parent.Win = !Parent.Win;
                    break;
                case 4:
                    Parent.Win = Parent.Win;
                    break;
                case 5:
                    if(Parent.Win)

                    break;
                case 6:

                    break;

                    */
            }

        }
    }
}
