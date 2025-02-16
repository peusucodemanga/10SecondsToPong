using UnityEngine;

public class Raquete : MonoBehaviour
{
    public Rigidbody2D rb;
    public int id;
    public float velocidadeMovimento = 5f;
    private Vector3 posicaoInicial;

    private void Start()
    {
        posicaoInicial = transform.position;
        GameManager.instancia.onReset += Reset;
    }
    private void Reset()
    {
        transform.position = posicaoInicial;
    }

    private void Update()
    {
        float movimento = Entrada();
        Mover(movimento);
    }
    private float Entrada()
    {
        float movimento = 0f;
        switch (id)
        {
            case 1:
                movimento = Input.GetAxis("Player1");
                break;
            case 2:
                movimento = Input.GetAxis("Player2");
                break;
        }
        return movimento;
    }
    private void Mover(float movimento)
    {
        Vector2 veloc = rb.linearVelocity;
        veloc.y = velocidadeMovimento * movimento;
        rb.linearVelocity = veloc;
    }
}
