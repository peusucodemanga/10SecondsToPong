using UnityEngine;

public class Bola : MonoBehaviour
{
    public Rigidbody2D rb;
    public float maxAnguloInicio = 0.67f;
    public float maxAnguloColisao = 45f;
    public float velocidadeInicial;
    public float velocidade = 1f;
    public float maxInicioY = 4f;
    private float multiplicadorVelocidade = 1.1f;
    private float inicioX = 0f;

    void Start()
    {
        InicioPartida();
        GameManager.instancia.onReset += Reset;
    }
    private void Reset()
    {
        ResetPosicao();
        InicioPartida();
    }

    private void InicioPartida()
    {
        Vector2 pos = Random.value < 0.5f ? Vector2.left : Vector2.right;
        pos.y = Random.Range(-maxAnguloInicio, maxAnguloInicio);
        rb.linearVelocity = pos * velocidade;
    }
    private void ResetPosicao()
    {
        float posY = Random.Range(-maxInicioY, maxInicioY);
        Vector2 position = new Vector2(inicioX, posY);
        transform.position = position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Score score = collision.GetComponent<Score>();
        if(score)
            GameManager.instancia.PontoMarcado(score.id);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Raquete raquete = collision.collider.GetComponent<Raquete>();
        if(raquete)
        {
            rb.linearVelocity *= multiplicadorVelocidade;
        }
    }
}
