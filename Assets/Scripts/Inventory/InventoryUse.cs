using UnityEngine;
using System.Collections;

public class InventoryUse : MonoBehaviour
{
    public GameObject door;

    public string Needed;

    // Use this for initialization
    void Start()
    {
        GetComponent<TextMesh>().text = "?";
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Player items = GameObject.Find("Player").GetComponent<Player>();

        if (other.tag == "Player" && items.carrying)
        {
            if (items.carrying.op == Needed)
            {
                GetComponent<TextMesh>().text = items.carrying.GetComponent<TextMesh>().text;
                Destroy(items.carrying.gameObject);

                Destroy(door);

                GetComponent<Collider2D>().enabled = false;
            }
        }
    }
}
