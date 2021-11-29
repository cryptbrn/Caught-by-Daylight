using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    int levelIsUnlocked;


    public Button[] cards;

    // Start is called before the first frame update
    void Start()
    {
        levelIsUnlocked = PlayerPrefs.GetInt("levelIsUnlocked", 1);

        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].interactable = false;
        }

        for (int i = 0; i < levelIsUnlocked; i++)
        {
            cards[i].interactable = true;
        }
    }

    public void LoadLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
