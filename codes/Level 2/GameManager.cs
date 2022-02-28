using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManager;
public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    bool gameended = false;
    public float restartdelay = 1f;
    public void levelcomplete()
    {
        Debug.Log("level complted");
    }
    public void EndGame()
    {
        if (gameended == false)
        {
            gameended = true;
            Debug.Log("game over");
            Invoke("restart", restartdelay);

        }
    }

    // }
    void restart()
    {
        SceneManager.LoadScene("game");
    }
}
