using UnityEngine;
using UnityEngine.SceneManagement;

public class botoesTela : MonoBehaviour
{

    void Start()
    {
        Time.timeScale=0f;
    }
    public void comecarJogo(){
        SceneManager.LoadSceneAsync(1);
    }

    public void sairJogo(){
        Application.Quit();

    }
}
