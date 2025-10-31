using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    public EnemyScript _enemy;
    public PivotPlayer _player;
    public PlayerFightScript _playerF;
    bool _lifebar;
    public Image[] _image;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        EnemyScript enemy = FindObjectOfType<EnemyScript>();
        PivotPlayer _player = FindObjectOfType<PivotPlayer>();    
        _enemy.enabled = false;
        _player.enabled = false;
        _playerF.enabled = false;
        Invoke("ActivateScript", 8);
        Invoke("LifeBar", 5);

        
    }

  void ActivateScript()
    {
        _enemy.enabled = true;
        _player.enabled = true;
        _playerF.enabled = true;
    }

    void LifeBar()
    {
        _lifebar = true;
    }

    private void Update()
    {
        if (_lifebar)
        {
            for (int i = 0; i < _image.Length; i++)
            {
                _image[i].color = new Color(_image[i].color.r, _image[i].color.g, _image[i].color.b, _image[i].color.a + Time.deltaTime);
            }
        }
    }
}
