using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
    public Vector3 offset;
    Vector3 newPosition;

    public float ClosZ;
    public float NormZ = -15f;
    public float FaraZ;

    public float MinX, MaxX;
    public float MinY, MaxY;

    GameObject play;
    Player pl;

    TimeManager tim;

    void Start()
    {
        tim = GameObject.Find("Manager").GetComponent<TimeManager>();

        play = GameObject.Find("Player");
        pl = play.GetComponent<Player>();

        offset = transform.position - play.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        newPosition = offset + play.transform.position;

        if (newPosition.x < MinX)
        {
            newPosition.x = MinX;
            if(play.transform.position.x < (MinX - 20))
                tim.Died();
        }
        if (newPosition.x > MaxX)
        {
            newPosition.x = MaxX;
            if (play.transform.position.x > (MaxX + 20))
                tim.Died();
        }
        if (newPosition.y < MinY)
        {
            newPosition.y = MinY;
            if (play.transform.position.y < (MinY - 20))
                tim.Died();
        } 
        if (newPosition.y > MaxY)
        {
            newPosition.y = MaxY;
            if (play.transform.position.y > (MaxY + 20))
                tim.Died();
        }

        transform.position = newPosition;
	}
}
