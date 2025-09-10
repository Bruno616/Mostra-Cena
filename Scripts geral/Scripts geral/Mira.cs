using UnityEngine;

public class Mira : MonoBehaviour
{
    [Header("Mira")]
    public Texture2D crosshairTexture; // opcional: imagem da mira
    public float size = 32f;           // tamanho da mira em pixels
    public Color crossColor = Color.white; // cor do "+" se não tiver textura

    void OnGUI()
    {
        float x = (Screen.width - size) / 2;
        float y = (Screen.height - size) / 2;

        if (crosshairTexture != null)
        {
            GUI.DrawTexture(new Rect(x, y, size, size), crosshairTexture);
        }
        else
        {
            // Desenha um "+" simples no centro da tela
            GUIStyle style = new GUIStyle(GUI.skin.label);
            style.normal.textColor = crossColor;
            style.alignment = TextAnchor.MiddleCenter;
            style.fontSize = Mathf.RoundToInt(size / 2);

            GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height / 2 - 10, 20, 20), "+", style);
        }
    }
}
