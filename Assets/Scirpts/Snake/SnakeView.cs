using UnityEngine;
using TMPro;

[RequireComponent(typeof(Snake))]
public class SnakeView : MonoBehaviour
{
    [SerializeField] private TMP_Text _view;

    private Snake _snake;

    private void Awake() => _snake = GetComponent<Snake>();
    private void OnEnable() => _snake.SizeUpdated += OnSizeUpdated;
    private void OnDisable() => _snake.SizeUpdated -= OnSizeUpdated;
    private void OnSizeUpdated(int updated) => _view.text = updated.ToString();
}
