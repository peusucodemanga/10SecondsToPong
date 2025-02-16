using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public System.Action onReset;
    public int pontoP1, pontoP2;
    public ScorePlayers scoreP1, scoreP2;

    private void Awake()
    {
        if (instancia)
            Destroy(gameObject);
        else
            instancia = this;
    }

    public void PontoMarcado(int id)
    {
        onReset?.Invoke();
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