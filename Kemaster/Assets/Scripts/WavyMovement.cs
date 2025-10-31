using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WavyMovement : MonoBehaviour
{
    [Header("Movement Settings")]
      // Force de propulsion vers l'avant
    public float swayAmplitude = 1f;      // Distance du mouvement gauche/droite
    public float swaySpeed = 2f;          // Vitesse du mouvement gauche/droite

    private Rigidbody rb;
    private Vector3 startLocalPos;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startLocalPos = transform.localPosition;
    }

    void FixedUpdate()
    {
      
        // Oscillation gauche/droite selon la rotation actuelle
        float sway = Mathf.Sin(Time.time * swaySpeed) * swayAmplitude;

        // Calcul de la direction gauche/droite relative à l'orientation de l'objet
        Vector3 sideMovement = transform.right * sway;

        // Appliquer la position oscillante (autour de la position locale de départ)
        Vector3 targetPosition = startLocalPos + sideMovement;
        transform.localPosition = new Vector3(targetPosition.x, transform.localPosition.y, transform.localPosition.z);
    }
}