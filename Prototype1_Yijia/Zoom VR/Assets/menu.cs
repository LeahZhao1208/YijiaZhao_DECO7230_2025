using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    public Button fold;
    public Button nofold;
    public GameObject nofold1;
    public GameObject menu1;
    public Button exit;
    public GameObject exit1,exit2,exit3,exit4;
    public GameObject roundcamera;
    public GameObject chooseUI;
    // Start is called before the first frame update
    void Start()
    {
        fold.onClick.AddListener(openmenu);
        nofold.onClick.AddListener(closemenu);
        exit.onClick.AddListener(exitgame);
    }

    private void exitgame()
    {
        exit1.SetActive(false);
        exit2.SetActive(false);
        exit3.SetActive(false);
        exit4.SetActive(false);
        roundcamera.SetActive(false);
        chooseUI.SetActive(true);
        nofold1.SetActive(false);
        menu1 .SetActive(false);
    }

    private void closemenu()
    {
        menu1.SetActive(false);
        nofold1.SetActive(true);
    }

    private void openmenu()
    {
        menu1.SetActive(true);
        nofold1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
