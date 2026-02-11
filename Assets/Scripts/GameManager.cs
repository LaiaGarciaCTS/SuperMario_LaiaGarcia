using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Text goombaText;

    public bool _pause;

    public int killedEnemies = 0;

    public void AddKill()
    {
        killedEnemies++;
        goombaText.text = killedEnemies.ToString();
    }


    void Pause()
    {
        if (_pause == false)
        {
            Time.timeScale = 0;
            _pause = true;
        }
        
        else (_pause == true)
        {
            Time.timeScale = 1;
            _pause = false;
        }
        
    }
}
