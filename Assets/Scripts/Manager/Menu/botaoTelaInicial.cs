using UnityEngine;
using UnityEngine.SceneManagement;

public class botoesTela : MonoBehaviour
{

    void Start()
    {
        Time.timeScale = 0f;
    }
    public void ComecarJogo()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void ModoDificil()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(4);
    }
    public void SairJogo()
    {
        Application.Quit();

    }

}
