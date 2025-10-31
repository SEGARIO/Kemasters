using UnityEngine;

public class StickyProj : MonoBehaviour
{
    public float _stickTime;
    bool isSticked;
    public float speedDamage;
    private void OnCollisionEnter(Collision collision)
    {
        // V�rifie si l'objet touch� a le tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Devient enfant de l'objet "Player"
            transform.SetParent(collision.transform);

            // Optionnel : d�sactive la physique pour qu�il ne rebondisse pas
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = true;
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
                isSticked = true;
            }
        }
        else
        {
            if (!isSticked)
            {
                Destroy(gameObject);
            }
           
        }
    }

    private void Update()
    {
        if (isSticked)
        {
            _stickTime -= Time.deltaTime;
            GetComponent<Animator>().SetBool("IsSticked", true);
            GetComponentInParent<PlayerFightScript>()._hp -= Time.deltaTime * speedDamage;

            AutoRotate _autoRotate = GetComponent<AutoRotate>();
            if (_autoRotate != null)
            {
                _autoRotate.enabled = false;
            }
        }

        if (_stickTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
