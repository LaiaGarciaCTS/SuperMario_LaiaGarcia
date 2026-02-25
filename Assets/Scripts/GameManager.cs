using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class GameManager : MonoBehaviour
{
    public Text goombaText;

    public bool _pause = false;
    public bool win = false;

    public int killedEnemies = 0;

    public GameObject pauseCanvas;
    public GameObject WinCanvas;

    public SceneLoader _sceneLoader;
    public string gameOverScene;

    public Button botonWinCanvas;

    void Awake()
    {
        _sceneLoader = GameObject.Find("Scene Loader").GetComponent<SceneLoader>();
    }

    public void GameOver()
    {
        _sceneLoader.ChangeScene(gameOverScene);
    }

    public void AddKill()
    {
        killedEnemies++;
        goombaText.text = killedEnemies.ToString();
    }


    public void Pause()
    {
        if (_pause == false)
        {
            Time.timeScale = 0;
            _pause = true;
        }
        else
        {
            Time.timeScale = 1;
            _pause = false;
        }

        pauseCanvas.SetActive(_pause);
    }

    public IEnumerator Win()
    {
        yield return new WaitForSeconds(2f);
        if (win == false)
        {
            win = true;
        }
        else
        {
            win = false;
        }

        pauseCanvas.SetActive(win);
    }



}
