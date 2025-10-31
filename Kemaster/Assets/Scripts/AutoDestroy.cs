using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    public float lifetime = 3f; // Durée avant destruction

    void Start()
    {
        Destroy(gameObject, lifetime);
    }
}