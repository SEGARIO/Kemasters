using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour
{
    public InstatiationVisual _ins;
    public SO_Monster _monster;
    public float _jumpTimer;
    Animator _enemyAnimator;
    [System.Serializable]
    public class ProjectileWave
    {
        public GameObject projectilePrefab;
        public float fireRate = 0.5f;
        public int projectileCount = 5;
        public float waveDelay = 2f;
        public float shootForce = 10f;
        
    }

   
   
    public Transform firePoint;
    float _jumpDuration;
    private bool isShooting = false;

    void Start()
    {
        _monster = _ins._monster;
        _enemyAnimator = GetComponentInChildren<Animator>();  
        _jumpTimer = _monster._maxTimeBeforeJump + _monster._maxJumpDuration + _monster._timeBeforeFirstJump;
        StartCoroutine(WaveRoutine());
        StartCoroutine(RotationRoutine());
    }

    private void Update()
    {
        if (_monster._canJump)
        {
            _jumpTimer -= Time.deltaTime;

            if (_jumpTimer < _jumpDuration)
            {
                _enemyAnimator.SetBool("IsJumping", true);

            }
            else
            {
                _enemyAnimator.SetBool("IsJumping", false);

            }

            if (_jumpTimer <= 0)
            {
                
                _jumpDuration = Random.Range(_monster._minJumpDuration, _monster._maxJumpDuration);
                _jumpTimer = Random.Range(_monster._minTimeBeforeJump, _monster._maxTimeBeforeJump) + _jumpDuration;
            }
        }
    }

    IEnumerator WaveRoutine()
    {
        while (true)
        {
            for (int i = 0; i < _monster._projectiles.Length; i++)
            {
                yield return StartCoroutine(ShootWave(_monster._projectiles[i]));
                yield return new WaitForSeconds(_monster._projectiles[i].waveDelay);
            }
        }
    }

    IEnumerator ShootWave(SO_Monster.ProjectileWave wave)
    {
        if (isShooting) yield break;
        isShooting = true;

        for (int i = 0; i < wave.projectileCount; i++)
        {
            if (wave.projectilePrefab != null && firePoint != null)
            {
                // Directions relatives au firePoint
                Vector3[] directions = new Vector3[]
                {
            firePoint.forward,                // avant
            -firePoint.forward,               // arrière
            firePoint.right,                  // droite
            -firePoint.right                  // gauche
                };

                foreach (Vector3 dir in directions)
                {
                    GameObject projectile = Instantiate(wave.projectilePrefab, firePoint.position, Quaternion.LookRotation(dir));
                    Rigidbody rb = projectile.GetComponent<Rigidbody>();
                    if (rb != null)
                        rb.AddForce(dir * wave.shootForce, ForceMode.Impulse);
                }
            }

            yield return new WaitForSeconds(wave.fireRate);
        }

        isShooting = false;
    }

    IEnumerator RotationRoutine()
    {
        while (true)
        {
            // Attente avant la prochaine rotation
            float waitTime = Random.Range(_monster.rotationDelayRange.x, _monster.rotationDelayRange.y);
            yield return new WaitForSeconds(waitTime);

            // Rotation locale de base (0,0,0)
            Quaternion initialRotation = Quaternion.identity;

            // Paramètres aléatoires
            float rotateTime = Random.Range(_monster.rotationDurationRange.x, _monster.rotationDurationRange.y);
            float rotationSpeed = Random.Range(_monster.rotationSpeedRange.x, _monster.rotationSpeedRange.y);
            int direction = Random.value > 0.5f ? 1 : -1;

            float elapsed = 0f;

            // Tourne dans un sens
            while (elapsed < rotateTime)
            {
                transform.Rotate(Vector3.up * rotationSpeed * direction * Time.deltaTime, Space.Self);
                elapsed += Time.deltaTime;
                yield return null;
            }

            // Reviens à (0,0,0) local
            Quaternion currentRot = transform.localRotation;
            float t = 0f;

            while (t < 1f)
            {
                transform.localRotation = Quaternion.Lerp(currentRot, initialRotation, t);
                t += Time.deltaTime / 0.5f; // Durée du retour
                yield return null;
            }

            transform.localRotation = initialRotation;
        }
    }
}
