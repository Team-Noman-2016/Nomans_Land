using UnityEngine;
using System.Collections;

public class InventoryOperator : MonoBehaviour
{
    public string op;

    Vector3 child = new Vector3(0,2,0);

    // Use this for initialization
    void Start()
    {

        GetComponent<TextMesh>().text = op;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player items = GameObject.Find("Player").GetComponent<Player>();

        if (other.tag == "Player" && !items.carrying)
        {
            transform.parent = other.transform;

            transform.localPosition = child;

            items.carrying = this;


            GetComponent<Collider2D>().enabled = false;
        }
    }
}
