using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class EffectManager : MonoBehaviour
{
    public static EffectManager instancia;
    public Image ColorBar;
    public Image Noise;
    private Coroutine bugEventoCoroutine;
    public Volume PretoBranco;
    private ColorAdjustments colorAdjustments;

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
            return;
        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ColorBar = GameObject.Find("ColorBar")?.GetComponent<Image>();
        Noise = GameObject.Find("Noise")?.GetComponent<Image>();
        PretoBranco = GameObject.Find("PretoBranco")?.GetComponent<Volume>();

        if (ColorBar != null) ColorBar.enabled = false;
        if (Noise != null) Noise.enabled = false;
        if (PretoBranco != null) PretoBranco.enabled = false;

    }

    public void TvBugada(float[] interrupcoes)
    {
        StartCoroutine(TvBugadaEvento(interrupcoes));
    }

    public IEnumerator TvBugadaEvento(float[] interrupcoes)
    {
        if (ColorBar == null)
            yield break;

        ColorBar.enabled = true;
        foreach (float interrupcao in interrupcoes)
        {
            yield return new WaitForSeconds(interrupcao);
            ColorBar.enabled = !ColorBar.enabled;
        }

        ColorBar.enabled = false;
    }

    public void BugCentro()
    {
        if (bugEventoCoroutine != null)
        {
            StopCoroutine(bugEventoCoroutine);
            bugEventoCoroutine = null;
        }
        bugEventoCoroutine = StartCoroutine(BugEvento());
    }

    public IEnumerator BugEvento()
    {
        if (Noise == null)
            yield break;

        Noise.enabled = true;
        yield return new WaitForSeconds(9f);
        Noise.enabled = false;
        bugEventoCoroutine = null;
    }

    public void AtivarPretoEBranco(float tempo)
    {
        StartCoroutine(PretoEBrancoEfeito(tempo));
    }

    private IEnumerator PretoEBrancoEfeito(float tempo)
    {
        if (PretoBranco == null)
            yield break;

        PretoBranco.enabled = true;
        yield return new WaitForSeconds(tempo);
        PretoBranco.enabled = false;
    }
}
