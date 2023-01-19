using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(SnakeInput))]
[RequireComponent(typeof(TailGenerator))]
public class Snake : MonoBehaviour
{
    [SerializeField] private SnakeHead _snakeHead;
    [SerializeField] private float _speed;
    [SerializeField] private float _tailSpringiness;
    [SerializeField] private int _tailSize;

    private TailGenerator _tailGenerator;
    private SnakeInput _snakeInput;
    private List<Segment> _tail;

    public event UnityAction<int> SizeUpdated;

    private void Start()
    {
        _snakeInput = GetComponent<SnakeInput>();
        _tailGenerator = GetComponent<TailGenerator>();

        _tail = _tailGenerator.Generate(_tailSize);
        SizeUpdated?.Invoke(_tail.Count);
    }

    private void OnEnable()
    {
        _snakeHead.BlockCollided += OnBlockCollided;
        _snakeHead.BonusPickUp += OnBonusPickUp;
    }

    private void OnDisable()
    {
        _snakeHead.BlockCollided -= OnBlockCollided;
        _snakeHead.BonusPickUp -= OnBonusPickUp;
    } 

    private void FixedUpdate()
    {
        Move(_snakeHead.transform.position + _snakeHead.transform.up * (_speed * Time.fixedDeltaTime));

        _snakeHead.transform.up = _snakeInput.GetDirectionClick(_snakeHead.transform.position);
    }

    private void Move(Vector2 nextPosition)
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

    private void OnBlockCollided()
    {
        var deletedSegment = _tail[^1];
        _tail.Remove(deletedSegment);
        Destroy(deletedSegment.gameObject);

        SizeUpdated?.Invoke(_tail.Count);
    }

    private void OnBonusPickUp(int bonusValue)
    {
        _tail.AddRange(_tailGenerator.Generate(bonusValue));

        SizeUpdated?.Invoke(_tail.Count);
    }
}
