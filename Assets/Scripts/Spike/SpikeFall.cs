using UnityEngine;
using System.Collections;

public class SpikeFall : MonoBehaviour 
{
    Vector3 startingPos;

    public Transform respawn;


	// Use this for initialization
	void Start () 
    {
        startingPos = transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Fall()
    {
        GetComponent<Rigidbody2D>().gravityScale = 4;
        GetComponent<Rigidbody2D>().isKinematic = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "None")
        {

            

            if (other.gameObject.tag == "Player")
            {

                other.transform.position = respawn.position;
            }

            transform.position = startingPos;
            GetComponent<Rigidbody2D>().isKinematic = true;

        }
    }
}
