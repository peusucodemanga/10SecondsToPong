using UnityEngine;

public class Player1 : MonoBehaviour
{
    public float velocidadeMovimento;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool botaoCima = Input.GetKey(KeyCode.W);
        bool botaoBaixo = Input.GetKey(KeyCode.S);

        if(botaoCima){
            transform.Translate(Vector2.up * Time.deltaTime*velocidadeMovimento);
        }

        if(botaoBaixo){
            transform.Translate(Vector2.down * Time.deltaTime*velocidadeMovimento);
        }
    }
}
