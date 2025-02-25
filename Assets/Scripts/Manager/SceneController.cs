using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instancia;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void MudarParaScene(int cena, float tempo)
    {
        StartCoroutine(TrocarCena(cena, tempo));
    }

    private IEnumerator TrocarCena(int cena, float tempo)
    {
        int cenaAnterior = SceneManager.GetActiveScene().buildIndex;
        yield return SceneManager.LoadSceneAsync(cena);
        yield return new WaitForSeconds(0.1f);
        GameObject chuvisco = GameObject.Find("Chuvisco");

        if (chuvisco != null)
        {
            chuvisco.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            chuvisco.SetActive(false);
        }

        yield return new WaitForSeconds(tempo);
        yield return SceneManager.LoadSceneAsync(cenaAnterior);
    }
}