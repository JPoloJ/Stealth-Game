using UnityEngine;

public class WinCon : MonoBehaviour
{
    GameManager gameManager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            gameManager.OnEndGame(false);
        }
    }
}