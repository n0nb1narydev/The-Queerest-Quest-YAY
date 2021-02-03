﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour {

    public Text dialogText;
    public Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;
    public int currentLine;
    private bool textStarted;

    public static DialogManager instance;

    // Start is called before the first frame update
    void Start () {
        instance = this;

        // dialogText.text = dialogLines[currentLine]; for testing
    }

    // Update is called once per frame
    void Update () {

        if (dialogBox.activeInHierarchy) {
            if (Input.GetButtonUp ("Fire1")) {
                if (!textStarted) {
                    currentLine++;

                    if (currentLine >= dialogLines.Length) {

                        dialogBox.SetActive (false);
                        PlayerController.instance.canMove = true;

                    } else {
                        CheckIfName ();

                        dialogText.text = dialogLines[currentLine];

                    }
                } else {
                    textStarted = false;
                }
            }
        }
    }

    public void ShowDialog (string[] newLines) {
        dialogLines = newLines;

        currentLine = 0;

        CheckIfName ();

        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive (true);

        textStarted = true;

        PlayerController.instance.canMove = false;
    }

    public void CheckIfName () {
        if (dialogLines[currentLine].StartsWith ("n-")) {
            nameText.text = dialogLines[currentLine].Replace ("n-", "");
            currentLine++;
        }
    }

}