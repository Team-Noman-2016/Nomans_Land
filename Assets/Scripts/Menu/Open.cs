using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Open : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {
            //Scene scene = SceneManager.GetActiveScene();
            

            

        }

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                

                if(hit.transform.name == "New")
                {
                    
                }

            }
        }
	
	}

    public void New()
    {
        SceneManager.LoadScene("Selection");
        PlayerPrefs.SetFloat("Testing", 0);
        //all go to 0;
    }

    public void Continue()
    {
        SceneManager.LoadScene("Selection");
    }
}
