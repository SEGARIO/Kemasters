using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float lifetime = 3f; // Dur�e avant destruction

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}