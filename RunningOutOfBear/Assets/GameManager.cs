using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float fps;

    public GameManager otherPlayer;
    public GameObject player;



    public List<BulletMovement> bulletList = new List<BulletMovement>();

    bool gameOver;

    // Use this for initialization
    private void Start()
    {
        fps = 100;
        StartCoroutine("GameLoop") ;


    }	

	void Update () {


    }



    IEnumerator GameLoop()
    {
        do
        {
            float currentRate = 1 / fps;
            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].MoveBullet(currentRate);
            }
            yield return new WaitForSeconds(currentRate);
        } while (!gameOver);
        yield return null;
    }

    private void ChangeFPSOne(float lag)
    {
        fps += lag;
    }
}
