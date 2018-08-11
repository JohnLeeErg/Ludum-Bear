using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBounce : MonoBehaviour
{

    public bool horizontal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "bullet")
        {
            Vector3 objDir = collision.gameObject.GetComponent<BulletMovement>().dir;
            if (horizontal)
            {
                    collision.gameObject.GetComponent<BulletMovement>().dir = new Vector3(-objDir.x, objDir.y, objDir.z);
            }
            else
            {
                collision.gameObject.GetComponent<BulletMovement>().dir = new Vector3(objDir.x, -objDir.y, objDir.z);
            }
        }
    }
}
