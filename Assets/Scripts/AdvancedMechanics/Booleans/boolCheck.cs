using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class boolCheck : MonoBehaviour 
{   

    public bool Win; //Lets us know if we win.

    TimeManager tim;

    void Start()
    {
        tim = GameObject.Find("Manager").GetComponent<TimeManager>();

        Win = false;
    }




    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (Win)
                tim.Win();

            else
                tim.Died();
        }
    }
}
