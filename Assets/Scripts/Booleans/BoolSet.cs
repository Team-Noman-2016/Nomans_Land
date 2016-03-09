using UnityEngine;
using System.Collections;

public class BoolSet : MonoBehaviour 
{
    public int comparisionType;

    public boolCheck Parent;


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
            switch (comparisionType)
            {
                case 1:
                    Parent.Win = true;
                    break;
                case 2:
                    Parent.Win = false;
                    break;
                case 3:
                    Parent.Win = !Parent.Win;
                    break;

            }

        }
    }
}
