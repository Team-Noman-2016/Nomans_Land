using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour 
{

    public bossHealth target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            if (other.GetComponent<Player>().size == 3)
            {
                --target.health;
                Destroy(gameObject);
            }
        }

    }
}
