﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour {
    
    public void StartGame(){

        SceneManager.LoadScene(1);

    }

    public void ExitGame(){
        
        Debug.Log ("QUIT!");
        Application.Quit();
    }
}