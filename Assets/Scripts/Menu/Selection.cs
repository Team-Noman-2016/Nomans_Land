using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Selection : MonoBehaviour 
{
    LevelBlock selected;


    public float bestTime;


    public Text best;


	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if(selected)
        {
            bestTime = PlayerPrefs.GetFloat(selected.levelName);

            if(bestTime > 1 && bestTime < 900)
            best.text = "Best Time: " + bestTime.ToString("F2");
        }
        else
        {
            best.text = "Level Incomplete";
        }



        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.transform.name);
                if(selected && selected.transform == hit.transform)
                {
                    SceneManager.LoadScene(selected.levelName);
                }

                selected = hit.transform.GetComponent<LevelBlock>();
            }
        }
	
	}
}
