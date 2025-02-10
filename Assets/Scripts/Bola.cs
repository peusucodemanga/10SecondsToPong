using UnityEngine;

public class Bola : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameManager gameManager;
    public float maxAnguloInicio = 0.67f;
    public float maxAnguloColisao = 45f;
    public float velocidadeInicial;
    public float velocidade = 1f;
    public float maxInicioY = 4f;
    private float multiplicadorVelocidade = 1.1f;
    private float inicioX = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InicioPartida();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InicioPartida()
    {
        Vector2 pos = Random.value < 0.5f ? Vector2.left : Vector2.right;
        pos.y = Random.Range(-maxAnguloInicio, maxAnguloInicio);
        rb.linearVelocity = pos * velocidade;
    }
    private void ResetBall()
    {
        float posY = Random.Range(-maxInicioY, maxInicioY);
        Vector2 position = new Vector2(inicioX, posY);
        transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score score = collision.GetComponent<Score>();
        if(score)
        {
            gameManager.PontoMarcado(score.id);
            ResetBall();
            InicioPartida();
        }
    }
}
