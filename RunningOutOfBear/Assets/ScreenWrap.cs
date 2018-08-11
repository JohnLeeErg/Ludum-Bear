using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour {

    public ScreenWrap other;
    public Transform spawner;
    public bool horizontal, goodDir;
    private List<GameObject> collided = new List<GameObject>();


	void Update () {
        MoveObejct();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Vector3 objDir = collision.GetComponent<BulletMovement>().dir;
        print(objDir.x);
        if (horizontal)
        {
            if (goodDir && objDir.x > 0)
            {
                print("hello");
                collided.Add(collision.gameObject);
            }
            else if (!goodDir && objDir.x < 0)
            {
                print("hello");
                collided.Add(collision.gameObject);
            }
        }
        else {
            if (goodDir && objDir.y > 0)
                collided.Add(collision.gameObject);
            else if (!goodDir && objDir.y < 0) 
             collided.Add(collision.gameObject);
        }
    }

    //make public if wanna include this in game loop
    private void MoveObejct() {
        for (int i = 0; i < collided.Count; i++)
        {
            if (horizontal)
            {
                collided[i].transform.position = new Vector3(other.spawner.position.x, collided[i].transform.position.y, collided[i].transform.position.z);
            }
            else
            {
                collided[i].transform.position = new Vector3(collided[i].transform.position.x, other.spawner.position.y, collided[i].transform.position.z);
            }
        }
        collided.Clear();
    }
}
