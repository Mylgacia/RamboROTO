using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [Header("PUNTOS")]
    public int score = 0;
    public TextMeshProUGUI textpuntos;

    [Header("VIDAS")]
    public int vidas;
    public TextMeshProUGUI textvidas;

    [Header("MENUS")]
    public GameObject panelGameOver;
    public GameObject panelPausa;
    public GameObject botonPausa;

    public JohnMovement scriptRambo;
    public GameObject player;
    public GameObject fol;

    [Header("RESPAWNEAR")]
    public Transform respawn;

    private void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
            DontDestroyOnLoad(gameObject);


        }
        else
        {
            Destroy(gameObject);
        }




    }

    // Start is called before the first frame update
    void Start()
    {
        addVidas(5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addScore(int puntos)
    {
        score = score + puntos; // score += puntos
        textpuntos.text = "" + score.ToString();
    }

    public void addVidas(int vidasActuales)
    {
        vidas = vidasActuales; 
        textvidas.text = "" + vidas.ToString();
    }

    public void Pause()
    {
        panelPausa.SetActive(true);
        botonPausa.SetActive(false);
        Time.timeScale = 0f;
    }

    public void VolverPause()
    {
        panelPausa.SetActive(false);
        botonPausa.SetActive(true);
        Time.timeScale = 1f;
    }

    public void gameOver() //hemos creado panel de GameOver con un Botón de retry
    {
        panelGameOver.SetActive(true);
        panelPausa.SetActive(false);
        botonPausa.SetActive(false);
        Time.timeScale = 0f;

        player.SetActive(false);
    }

    public void Retry()
    {
       // scriptRambo.enabled = true;
       
        Time.timeScale = 1f;

        panelGameOver.SetActive(false);
        botonPausa.SetActive(true);
        player.SetActive(true);
        player.transform.position = respawn.position;
        fol.transform.position = respawn.position;

        addVidas(5);
        scriptRambo.Health = 5;



    }

    
}
