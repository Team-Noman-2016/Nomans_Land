using UnityEngine;
using System.Collections;

public class ResizePlayer : MonoBehaviour
{
    private GameObject triggerBox;


    private const float TRIGGER_SCALE = 0.9f;

    private const float RESIZE_RATE = 0.05f;


    private float resizeCounter;

    private int triggerCount;

    private int playerSize = 3;

    private int newSize;


    private bool isResizing;

    private bool isDead;


    public int PlayerSize
    {
        get { return playerSize; }
    }

    public bool IsDead
    {
        get { return isDead; }
    }


    void Start()
    {
        triggerBox = new GameObject();

        triggerBox.transform.SetParent(transform, false);
        triggerBox.AddComponent<BoxCollider2D>().isTrigger = true;

        Vector2 triggerScale = GetComponent<BoxCollider2D>().transform.localScale * TRIGGER_SCALE;
        triggerBox.transform.localScale = new Vector3(triggerScale.x, triggerScale.y, 1);

        transform.localScale = new Vector3(playerSize, playerSize, 1);
    }


    void OnDestroy()
    {
        Destroy(triggerBox);
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Solid")
        {
            triggerCount++;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Solid")
        {
            triggerCount = 0;
        }
    }


    public void Reset()
    {
        isDead = false;

        isResizing = false;

        resizeCounter = 0;

        triggerCount = 0;

        playerSize = 3;

        transform.localScale = new Vector3(playerSize, playerSize, 1);
    }


    public void Resize(bool isGrowing)
    {
        if (isResizing)
        {
            return;
        }

        newSize = playerSize;

        if (isGrowing)
        {
            if (newSize < 5)
            {
                newSize += 2;
                isResizing = true;
            }
        }
        else
        {
            if (newSize > 1)
            {
                newSize -= 2;
                isResizing = true;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (isResizing)
        {
            if (resizeCounter < 2.0f)
            {
                resizeCounter += RESIZE_RATE;

                if (newSize > playerSize)
                {
                    transform.localScale += new Vector3(RESIZE_RATE, RESIZE_RATE, 0);
                }
                else
                {
                    transform.localScale -= new Vector3(RESIZE_RATE, RESIZE_RATE, 0);
                }
            }
            else
            {
                playerSize = newSize;

                isResizing = false;
                resizeCounter = 0;
            }
        }


        if (triggerCount > 10 && !isDead)
        {
            isDead = true;

            //Print("Noman was crushed to death");
            //Reset ();
        }

    }
}