using UnityEngine;

public class LerpPosition : MonoBehaviour
{
    public Transform target;      // L�objet vers lequel on veut se d�placer
    public float lerpSpeed = 5f;  // Vitesse du lerp

    void Update()
    {
        if (target == null) return;

        transform.position = Vector3.Lerp(
            transform.position,
            target.position,
            Time.deltaTime * lerpSpeed
        );
    }
}
