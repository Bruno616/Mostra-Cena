using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [Header("Configurações de Vida")]
    [SerializeField] private int vidaMaxima = 5;
    private int vidaAtual;

    [Header("UI")]
    [SerializeField] private Text lifeText;

    [Header("Configurações de Cenas")]
    [SerializeField] private string cenaMenu;
    [SerializeField] private string cenaGameOver;
    [SerializeField] private string cenaVitoria;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene cena, LoadSceneMode mode)
    {
        // Se a cena for uma FASE → reseta vida, trava cursor
        if (cena.name != cenaMenu && cena.name != cenaGameOver && cena.name != cenaVitoria)
        {
            vidaAtual = vidaMaxima;
            AtualizarUI();

            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            // Se for Menu, Game Over ou Vitória → cursor livre
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 1f;
        }
    }

    public void TakeDamage(int dano)
    {
        vidaAtual -= dano;
        AtualizarUI();

        if (vidaAtual <= 0)
        {
            GameOver();
        }
    }

    public void Heal(int quantidade)
    {
        vidaAtual += quantidade;
        if (vidaAtual > vidaMaxima) vidaAtual = vidaMaxima;
        AtualizarUI();
    }

    private void AtualizarUI()
    {
        if (lifeText != null)
            lifeText.text = "Vida: " + vidaAtual;
    }

    private void GameOver()
    {
        if (!string.IsNullOrEmpty(cenaGameOver))
        {
            SceneManager.LoadScene(cenaGameOver);
        }
    }

    public void Vitoria()
    {
        if (!string.IsNullOrEmpty(cenaVitoria))
        {
            SceneManager.LoadScene(cenaVitoria);
        }
    }

    public void ReiniciarCena()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Scene cena = SceneManager.GetActiveScene();
        SceneManager.LoadScene(cena.name);
    }

    public int GetVidaAtual()
    {
        return vidaAtual;
    }
}

