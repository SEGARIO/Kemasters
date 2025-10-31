using UnityEngine;

public class Destroyable : MonoBehaviour
{
    public int _damage;
    public GameObject _fx;
    public Color _particleColor;
    public bool _isIndestructible;
    float _timeDestruction = 0.1f;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Bullet") && !_isIndestructible)
        {
          
             Instantiate(_fx, this.transform.position, Quaternion.identity).GetComponent<ParticleSystem>().startColor = _particleColor;
            Destroy(gameObject);
           
        }

        if(collision.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<Feedbacks>().ScreenShake(0.1f, 0.1f);

            FindObjectOfType<PlayerFightScript>()._hp -= _damage * FindObjectOfType<EnemyScript>()._monster._attack;
        }
            
    }

    private void Update()
    {
        _timeDestruction -= Time.deltaTime;
        if(LazerScript._isLazering && !_isIndestructible && _timeDestruction >= 0)
        {
            Destroy(gameObject);
        }
    }
}
