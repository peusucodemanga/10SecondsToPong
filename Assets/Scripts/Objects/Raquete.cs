using UnityEngine;
using UnityEngine.SceneManagement;

public class Raquete : MonoBehaviour
{
    public Rigidbody2D rb;
    public int id;
    public float velocidadeMovimento;// = 5f;
    private Vector3 posicaoInicial;
    private string NomeModo;
    

    private void Start()
    {
        posicaoInicial = transform.position;
        NomeModo = SceneManager.GetActiveScene().name;
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
                movimento += Input.GetAxis("Player1");
                movimento += Input.GetAxis("Player1Joystick");
                break;
            case 2:
                movimento += Input.GetAxis("Player2");
                movimento += Input.GetAxis("Player2Joystick");
                break;
        }
        return movimento;
    }
    private void Mover(float movimento)
    {
        if (NomeModo == "HARDPong") velocidadeMovimento = 11f;
        else velocidadeMovimento = 7f;

        Vector2 veloc = rb.linearVelocity;
        veloc.y = velocidadeMovimento * movimento;
        rb.linearVelocity = veloc;
    }
}
