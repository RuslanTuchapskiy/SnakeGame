using UnityEngine;
using UnityEngine.Events;

public class Block : MonoBehaviour
{
    [SerializeField] private Vector2Int _destroyPriceRange;

    private int _destroyPrice;
    private int _filling;

    public int LeftToFill => _destroyPrice - _filling;

    public event UnityAction<int> FillingProgress;

    private void Start()
    {
        _destroyPrice = Random.Range(_destroyPriceRange.x, _destroyPriceRange.y);

        FillingProgress?.Invoke(LeftToFill);
    }

    public void Fill()
    {
        _filling++;
        FillingProgress?.Invoke(LeftToFill);

        if (_filling == _destroyPrice) Destroy(gameObject);
    }
}
