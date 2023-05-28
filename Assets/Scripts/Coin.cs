using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    private UnityEvent _collected = new UnityEvent();

    public event UnityAction Collected
    {
        add => _collected.AddListener(value);
        remove => _collected.RemoveListener(value);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
        {
            _collected.Invoke();
            Destroy(gameObject);
        }
    }
}
