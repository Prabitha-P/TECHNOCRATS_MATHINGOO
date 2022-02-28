using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    public Text scoreText;
    public float count;

    // Update is called once per frame
    public void Update()
    {
        count = player.position.z;
        scoreText.text = count.ToString("00");
    }
    public void increasescore()
    {
        count += 100;
        scoreText.text = count.ToString();
    }
}
