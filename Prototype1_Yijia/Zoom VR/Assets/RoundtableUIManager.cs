using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundtableUIManager : MonoBehaviour
{
    public Button button;
    public GameObject UI;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(gameobjectview);
    }

    private void gameobjectview()
    {
       UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
