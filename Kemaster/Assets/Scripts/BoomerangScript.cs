using UnityEngine;

public class BoomerangScript : MonoBehaviour
{
    public float returnDelay = 2f;     
    public float returnForce = 10f;     // Force du retour
    private Rigidbody rb;
    private Vector3 startPosition;
    private bool isReturning = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPosition = transform.position;
        Invoke(nameof(StartReturn), returnDelay);
    }

    void StartReturn()
    {
        isReturning = true;
    }

    void FixedUpdate()
    {
        if (isReturning)
        {
            // Direction vers le point de d�part
            Vector3 direction = (startPosition - transform.position).normalized;

            // On remet une force vers le point d�origine
            rb.AddForce(direction * returnForce, ForceMode.Acceleration);

            // Optionnel : si l�objet est proche du point d�origine, on stoppe
            if (Vector3.Distance(transform.position, startPosition) < 0.5f)
            {
                rb.linearVelocity = Vector3.zero;
                isReturning = false;
            }
        }
    }
}
