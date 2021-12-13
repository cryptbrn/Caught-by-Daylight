using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using CBD.Gameplay;

namespace CBD.UI{
    public class InGameMenu : MonoBehaviour
    {
        public GameObject gameOverMenuUI;
        public GameObject pauseMenuUI;
        public GameObject finishMenuUI;
        public bool isPaused;
        // Start is called before the first frame update
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape) && !PlayerHealth.isPlayerDead && !PlayerFinish.isPlayerFinish){
                if(isPaused)
                    Resume();
                else
                    Pause();
            }

            if(PlayerHealth.isPlayerDead){
                GameOver();
            }

            if(PlayerFinish.isPlayerFinish){
                GameFinish();
            }
            
        }

        void GameOver(){
            gameOverMenuUI.SetActive(true);
            Destroy(GameObject.FindWithTag("Player"));
        }

        void GameFinish(){
            finishMenuUI.SetActive(true);
            Destroy(GameObject.FindWithTag("Player"));
        }

        public void LoadScene(string sceneName){
            SceneManager.LoadScene(sceneName);
        }

        public void Resume(){
            pauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            isPaused = false;
        }

        void Pause(){
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;
        }
    }
}

