using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float fps;


    public Vector3 screenWrapOffset;

    public GameManager otherPlayer;

    
    public Text playerFPScounter, otherFPScounter;
    public GameObject screenWrap, walls;

    public List<BulletMovement> bulletList = new List<BulletMovement>();

    public List<string> abilities = new List<string>();

    private Vector3 screenWrapOrigional;
    private Dictionary<string, int> files = new Dictionary<string, int>();
    private bool gameOver;

    // Use this for initialization
    private void Start()
    {
        screenWrapOrigional = screenWrap.transform.position;
        fps = 100;
        FillDictionary();
        StartCoroutine("GameLoop");

    }


    private void FillDictionary() {
        files.Add("fps", 0);
        files.Add("screenWrap", 1);
        updateFiles();
    }

    void Update() {


    }



    IEnumerator GameLoop()
    {
        do
        {
            float currentRate = 1 / fps;

            updateFiles();

            for (int i = 0; i < bulletList.Count; i++)
            {
                bulletList[i].MoveBullet(currentRate);
            }
            yield return new WaitForSeconds(currentRate);
        } while (!gameOver);
        yield return null;
    }

    public void RemoveFile(string file) {
        if (files[file] == 0)
            return;
        files[file]--;
        updateFiles();
    }


    public void AddFile(string file) {
        if (files[file] == 2)
            return;
        files[file]++;
        updateFiles();
    }

    private void updateFiles() {
        //updates appropriate variables
        playerFPScounter.text = "" + ((int)fps);
        otherFPScounter.text = "" + 11;//((int)otherPlayer.fps);

        FPScounter(files["fps"]);
        ScreenWrapCounter(files["screenWrap"]);
    }

    private void FPScounter(int count) {


        if (count == 0)
        {
            playerFPScounter.enabled = false;
            otherFPScounter.enabled = false;
        }
        else if (count == 1)
        {
            playerFPScounter.enabled = true;
            otherFPScounter.enabled = false;
        }
        else if (count == 2)
        {
            playerFPScounter.enabled = true;
            otherFPScounter.enabled = true;
        }
    }


    //WILL HAVE TO MAKE WALLS AT ONE POINT (or player position checker)
    private void ScreenWrapCounter(int count) {
        print("here");
        if (count == 0)
        {
            screenWrap.SetActive(false);
            screenWrap.transform.position = screenWrapOrigional;
            walls.SetActive(true);
        }
        else if (count == 1)
        {
            screenWrap.SetActive(true);
            screenWrap.transform.position = screenWrapOrigional;
            walls.SetActive(false);
        }
        else if (count == 2)
        {
            screenWrap.SetActive(true);
            screenWrap.transform.position = screenWrapOrigional+screenWrapOffset;
            walls.SetActive(false);

        }
    }


    public void ChangeFPSOne(float lag)
    {
        fps += lag;
    }
}
