using UnityEngine;
using TMPro;

public class TextoLegenda : MonoBehaviour
{
    float larguraTexto;
    float pixelPorSegundo;
    RectTransform rt;
    TextMeshProUGUI textoUI;

    public float GetXPos { get { return rt.anchoredPosition.x; } }
    public float GetLargura { get { return rt.rect.width; } }

    public void Inicializar(float larguraTexto, float pixelPorSegundo, string texto)
    {
        rt = GetComponent<RectTransform>();
        textoUI = GetComponent<TextMeshProUGUI>();

        this.larguraTexto = larguraTexto;
        this.pixelPorSegundo = pixelPorSegundo;

        textoUI.text = texto;
    }

    void Update()
    {
        rt.position += Vector3.left * pixelPorSegundo * Time.deltaTime;

        if (GetXPos <= -GetLargura)
        {
            Destroy(gameObject);
        }
    }
}
