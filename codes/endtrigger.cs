using UnityEngine;
public class endtrigger : MonoBehaviour
{
    void OnTriggerEnter()
    {
        FindObjectOfType<GameManager>().levelcomplete();
    }
}
