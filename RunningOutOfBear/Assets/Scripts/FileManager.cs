using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileManager : MonoBehaviour {

    public GameManager gameManager;

    public List<Image> fileList;

    public bool playerOne, finished;


    private int selected;
	// Use this for initialization
	void Start () {
        selected = 0;
        HighlightText();
    }

    private void HighlightText() {
        for (int i = 0; i < fileList.Count; i++) {
            if(selected == i)
                fileList[i].color = new Color(.25f, .35f, .95f, 1);
            else
                fileList[i].color = new Color(1f, 1f, 1f, 1);
        }
    }

    private void SelectFile() {
        fileList[selected].color = new Color(.35f, .45f, 1f, 1);
        gameManager.abilities.Add(fileList[selected].transform.GetChild(0).GetComponent<Text>().text);
        fileList.RemoveAt(selected);
        if (selected >= fileList.Count)
            selected = fileList.Count - 1;
        print(fileList.Count);
        HighlightText();
    }

    private void MoveUp() {
        selected--;
        if (selected < 0)
            selected = fileList.Count - 1;
        HighlightText();
    }

    private void MoveDown()
    {
        selected++;
        if (selected == fileList.Count)
            selected = 0;
        HighlightText();
    }

    void Update() {

        if (fileList.Count > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                MoveUp();

            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                MoveDown();

            }
            else if (Input.GetKeyDown(KeyCode.E))
            {
                SelectFile();

            }
            print(selected);
        }
        else
            finished = true;
    }
}
