using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject RestartBtn;
    public GameObject Rain;

    float time = 0f;
    
    [SerializeField] private TMP_Text CurrentTimeText;
    [SerializeField] private TMP_Text BestTimeText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("MakeRain", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        CurrentTimeText.text = time.ToString("N2");
        
    }
    
    void MakeRain()
    {
        Instantiate(Rain);
    }

    public void GameOver()
    {
        Time.timeScale = 0f;
        RestartBtn.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}
