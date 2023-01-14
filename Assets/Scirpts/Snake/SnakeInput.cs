using UnityEngine;

public class SnakeInput : MonoBehaviour
{
    public Vector2 GetDirectionClick(Vector2 headPosition)
    {
        var clickPosition = Input.mousePosition;

        clickPosition = Camera.main.ScreenToViewportPoint(clickPosition);
        clickPosition.y = 1f;
        clickPosition = Camera.main.ViewportToWorldPoint(clickPosition);
        var direction = new Vector2(clickPosition.x - headPosition.x, clickPosition.y - headPosition.y);

        return direction;
    }
}
