using UnityEngine;

public class LerpRotation : MonoBehaviour
{
    public Transform target;         // La cible dont on suit la rotation
    public float lerpSpeed = 5f;     // Vitesse du lissage

    void Update()
    {
        if (target == null) return;

        // On récupère la rotation actuelle et la rotation cible (en angle Y)
        float currentY = transform.eulerAngles.y;
        float targetY = target.eulerAngles.y;

        // Lerp entre les deux angles
        float newY = Mathf.LerpAngle(currentY, targetY, Time.deltaTime * lerpSpeed);

        // Applique la nouvelle rotation
        transform.rotation = Quaternion.Euler(0f, newY, 0f);
    }
}
