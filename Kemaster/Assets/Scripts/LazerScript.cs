using UnityEngine;

public class LazerScript : MonoBehaviour
{
    public EnemyScript enemyScript;
    public InstatiationVisual _visual;
    float _timeBeforeLazer;

    public Animator _lazerAnim;
    public Animator _enemyAnim;

    public static bool _isLazering;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(_visual._monster._canLazer)
        {
            
              _timeBeforeLazer = Random.Range(_visual._monster._minTimeLazer, _visual._monster._maxTimeLazer);
        }
        else
        {
            Destroy(_lazerAnim.gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (_enemyAnim == null)
        {
            _enemyAnim = GameObject.FindWithTag("MonsterPivot").GetComponent<Animator>();
            Debug.Log("Null");

        }
        _timeBeforeLazer -= Time.deltaTime;

        if(_timeBeforeLazer < 0 && _timeBeforeLazer >= -1)
        {
            _isLazering = true;
            enemyScript.enabled = false;
            _lazerAnim.SetBool("Activated", true);
            _enemyAnim.SetBool("Lazer", true);
        }

        if(_timeBeforeLazer < -4.5)
        {
            _isLazering = false;
            _lazerAnim.SetBool("Activated", false);
            _enemyAnim.SetBool("Lazer", false);
            _timeBeforeLazer = Random.Range(enemyScript._monster._minTimeLazer, enemyScript._monster._maxTimeLazer);
            enemyScript.enabled = true;
        }
    }
}
