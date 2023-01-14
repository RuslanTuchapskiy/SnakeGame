using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SnakeInput))]
[RequireComponent(typeof(TailGenerator))]
public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private float _speed;
    [SerializeField] private float _tailSpringiness;

    private TailGenerator _tailGenerator;
    private SnakeInput _snakeInput;
    private List<Segment> _tail;

    private void Start()
    {
        _snakeInput = GetComponent<SnakeInput>();
        _tailGenerator = GetComponent<TailGenerator>();

        _tail = _tailGenerator.Generate();
    }

    private void FixedUpdate()
    {
        Move(_snakeHead.transform.position + _snakeHead.transform.up * (_speed * Time.fixedDeltaTime));

        _snakeHead.transform.up = _snakeInput.GetDirectionClick(_snakeHead.transform.position);
    }

    private void Move(Vector3 nextPosition)
    {
        var previousPosition = _snakeHead.transform.position;

        foreach (var tailSegment in _tail)
        {
            var tempPosition = tailSegment.transform.position;
            tailSegment.transform.position = Vector2.Lerp(tailSegment.transform.position, previousPosition, _tailSpringiness * Time.fixedDeltaTime);
            previousPosition = tempPosition;
        }

        _snakeHead.Move(nextPosition);
    }
}
