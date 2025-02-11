using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class botoesTela : MonoBehaviour
{
    public void comecarJogo(){
        SceneManager.LoadSceneAsync(0);
    }

    public void sairJogo(){
        Application.Quit();

    }
}
