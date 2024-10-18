using UnityEngine;
using UnityEngine.SceneManagement;


    public class RetryButton : MonoBehaviour
    {
        public void OnClickRetryBtn()
        {
            SceneManager.LoadScene("GameScene");
        }
    }

