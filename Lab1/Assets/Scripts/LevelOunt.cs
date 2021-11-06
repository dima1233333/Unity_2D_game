
using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

public class LevelOunt : MonoBehaviour
{
    [SerializeField] private int _coinsToNextLevel;
    [SerializeField] private int _levelTolaod;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Sprite _finichOutSprite;

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerControl player = other.GetComponent<PlayerControl>();
        if (player != null && player.CoinsAmount >= _coinsToNextLevel)
        {
            Debug.Log("Dors open");
            Invoke(nameof(LoadNextScene), 1f);
   
        }

    }
    private void LoadNextScene()
    {
        SceneManager.LoadScene(_levelTolaod); 
    }

}
