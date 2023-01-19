using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField] private Vector2 _wallSizeRange;

    private void Start()
    {
        transform.localScale = new Vector3(transform.localScale.x, Random.Range(_wallSizeRange.x, _wallSizeRange.y), transform.localScale.z);
    }
}
