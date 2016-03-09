using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class boolCheck : MonoBehaviour 
{
    public Transform start; //Where we go back if fail.

    public bool Win; //Lets us know if we win.



	// Use this for initialization
	void Start () 
    {
        Win = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Win)
            {
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }

            else
                other.transform.position = start.position;

        }
    }
}
