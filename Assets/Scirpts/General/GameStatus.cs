using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStatus : MonoBehaviour
{
    [SerializeField] private Snake _snake;
    [SerializeField] private Image _gameOverScreen;
    [SerializeField] private TMP_Text _scoreText;

    private void OnEnable() => _snake.SizeUpdated += OnSizeUpdated;
    private void OnDisable() => _snake.SizeUpdated -= OnSizeUpdated;

    private void OnSizeUpdated(int updated)
    {
        if (updated <= 0)
        {
            _snake.gameObject.SetActive(false);
            _gameOverScreen.gameObject.SetActive(true);
            _scoreText.gameObject.SetActive(false);
        }
    }
}
