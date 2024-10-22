using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public partial class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject CanvasImage;
    public GameObject Rain;

    

    float time = 0f;
    
    [SerializeField] private TMP_Text CurrentTimeText;
    [SerializeField] private TMP_Text BestTimeText;
    [SerializeField] private TMP_Text TimeText;

    bool isPlay = true;

    string key = "BestTimeText";

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
        Time.timeScale = 1f;
        InvokeRepeating("MakeRain", 0f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            time += Time.deltaTime;
            TimeText.text = time.ToString("N2");
        }
    }
    
    void MakeRain()
    {
        Instantiate(Rain);
    }

    public void GameOver()
    {
        isPlay = false;
        Time.timeScale = 0f;
        CurrentTimeText.text = time.ToString("N2");

        if (PlayerPrefs.HasKey(key))
        {
            float best = PlayerPrefs.GetFloat(key);
            if(best < time)
            {
                PlayerPrefs.SetFloat(key, time);
                BestTimeText.text = time.ToString("N2");
            }
            else
            {
                BestTimeText.text = best.ToString("N2");
            }
        }
        else
        {
            PlayerPrefs.SetFloat(key, time);
            BestTimeText.text = time.ToString("N2");
        }
        
        CanvasImage.SetActive(true);

        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.instance.GameOver();
    }
}
