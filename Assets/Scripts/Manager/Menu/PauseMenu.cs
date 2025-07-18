using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool pausado = false;
    public GameObject menu;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(pausado) Continuar();
            else Pause();
        }   
    }

    public void Continuar()
    {
        menu.SetActive(false);
        Time.timeScale = 1f;
        pausado = false;
    }

    void Pause()
    {
        menu.SetActive(true);
        Time.timeScale = 0f;
        pausado = true;
    }

    public void Reiniciar()
    {
        Time.timeScale = 1f;
        GameManager.instancia.ReiniciarJogo();

    }

    public void MenuInicial()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }

    public void Sair()
    {
        Application.Quit();
    }
}
