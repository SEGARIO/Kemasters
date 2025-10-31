using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    [Header("Projectile Settings")]
    public GameObject projectilePrefab;   // Le prefab du projectile
    public Transform firePoint;           // Le point de d�part (orientation)
    public float launchForce = 10f;       // Force de projection ajustable

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            LaunchProjectile();
        }
    }

    void LaunchProjectile()
    {
        if (projectilePrefab == null || firePoint == null) return;

        // Instancie le projectile � la position + rotation du firePoint
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Ajoute une force dans la direction du firePoint
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddForce(firePoint.forward * launchForce, ForceMode.Impulse);
        }
    }
}
