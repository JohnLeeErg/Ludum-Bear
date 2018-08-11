using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour {

    public GameManager gameManager;

    public Vector3 dir;
    public float moveSpeed;

    private void Start()
    {
        gameManager.bulletList.Add(gameObject.GetComponent<BulletMovement>());
    }

    public void MoveBullet(float fps) {
        transform.position = transform.position + dir * moveSpeed*fps;
    }

    public void DestroyBullet() {
        gameManager.bulletList.Remove(gameObject.GetComponent<BulletMovement>());
        Destroy(gameObject);
    }
}
