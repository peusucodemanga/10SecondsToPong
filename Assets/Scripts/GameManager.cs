using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public System.Action onReset;
    public int pontoP1, pontoP2;
    public ScorePlayers scoreP1, scoreP2;
    public GameObject bolaPrefab; 

    public Image ColorBar;
    private List<Bola> bolasAtivas = new List<Bola>(); 

    private void Awake()
    {
        if (instancia)
            Destroy(gameObject);
        else
            instancia = this;

            
    }

    public void CriarNovaBola()
    {
        ColorBar.enabled=false;
        GameObject novaBola = Instantiate(bolaPrefab, Vector2.zero, Quaternion.identity);
        Bola bolaScript = novaBola.GetComponent<Bola>();
        bolasAtivas.Add(bolaScript);
    }

    public void TvBugada()
    {
        StartCoroutine(TvBugadaEvento());
    }


    public IEnumerator TvBugadaEvento()
    {
        ColorBar.enabled = true;
        yield return new WaitForSeconds(2f); 
        ColorBar.enabled = false;
        yield return new WaitForSeconds(1f);
        ColorBar.enabled = true;
        yield return new WaitForSeconds(2f);
        ColorBar.enabled = false;       
        yield return new WaitForSeconds(1f);
        ColorBar.enabled = true;
        yield return new WaitForSeconds(2f);
        ColorBar.enabled = false;
        yield return new WaitForSeconds(2f);
        
    }
    public void RemoverBola(Bola bola)
    {
        bolasAtivas.Remove(bola);

        if (bolasAtivas.Count == 0)
        {
            onReset?.Invoke(); 
            CriarNovaBola(); 
        }
        Destroy(bola.gameObject);
    }

    public void PontoMarcado(int id)
    {
        if (id == 1) pontoP1++;
        if (id == 2) pontoP2++;
        UpdateScores();
    }

    private void UpdateScores()
    {
        scoreP1.SetScore(pontoP1);
        scoreP2.SetScore(pontoP2);
    }
}
