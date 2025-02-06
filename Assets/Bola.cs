using UnityEngine;

public class Bola : MonoBehaviour
{
    public Rigidbody2D rb;
    public float velocidadeInicial;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        bool posDir = UnityEngine.Random.value >= 0.5;

        float xVelocidade = -1f;

        if(posDir == true){
            xVelocidade = 1f;
        }

        float yVelocidade = UnityEngine.Random.Range(-1, 1);

        rb.linearVelocity = new Vector2(xVelocidade*velocidadeInicial, yVelocidade*velocidadeInicial);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
