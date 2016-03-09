using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/* Code for anything that kills you.
TimeManager tim;

    void Start()
    {
        tim = GameObject.Find("Manager").GetComponent<TimeManager>();
 * }
 * tim.Died();
*/


public class TimeManager : MonoBehaviour 
{
    public static float Timer;

    public static bool died;

    public Text TimerText;
    public Text StatusText;

    public bool done;

    // Use this for initialization
    void Start()
    {
        if (!died)
            Timer = 0;
        else died = false;

        Debug.Log(Timer);        
    }

    // Update is called once per frame
    void Update()
    {
        if(done)
        {
            Time.timeScale = 0;

            if (Input.anyKeyDown)
            {
                Scene scene = SceneManager.GetActiveScene();

                if (Timer < PlayerPrefs.GetFloat(scene.name) || PlayerPrefs.GetFloat(scene.name) < 3)
                {
                    PlayerPrefs.SetFloat(scene.name, Timer);
                }
                SceneManager.LoadScene("Selection");
            }
        }

        Timer += Time.deltaTime;

        if(Time.timeScale == 1)
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                Time.timeScale = 0;
            }

            TimerText.text = " ";
            StatusText.text = " ";
        }

        if(Time.timeScale == 0)
        {
            if (Input.anyKeyDown && !done)
            {
                Time.timeScale = 1;
            }

            TimerText.text = Timer.ToString("F2");
            if (!done)
                StatusText.text = "Press Any key to Continue";
            else
                StatusText.text = "You Win!";
        }

        if (Input.GetKeyUp(KeyCode.R))
            Died();

    }

    public void Win()
    {
        done = true;
    }

    public void Died()
    {
        died = true;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
