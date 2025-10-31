using UnityEngine;
using UnityEngine.UI;

public class IndexScript : MonoBehaviour
{
    public SO_Monster _currentMonster;
    public SO_Monster[] _monsterList;
    public Text _name;
    public Text _description;
    public Transform _rotatingParent;
    public int _index;
    GameObject _currentRenderMonster;
    Animator _anim;
    public GameObject _interogation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentMonster = _monsterList[_index];
        DisplayMonster();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (_index < _monsterList.Length - 1)
            {
                _index += 1;
            }
            else
            {
                _index = 0;
            }
            
            _currentMonster = _monsterList[_index];
            DisplayMonster();
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (_index > 0)
            {
                _index -= 1;
            }
            else
            {
                _index = _monsterList.Length - 1;
            }
            _currentMonster = _monsterList[_index];
            DisplayMonster();
        }

       
    }

    void DisplayMonster()
    {
        if (_currentMonster._hasBeenEncountered)
        {
            Destroy(_currentRenderMonster);
            _currentRenderMonster = Instantiate(_currentMonster._visual, this.transform.position, Quaternion.identity, _rotatingParent);
            _anim = _currentRenderMonster.GetComponentInChildren<Animator>();
            _anim.SetBool("Display", true);
            _name.text = _currentMonster._name;
            _description.text = _currentMonster._description;
        }
        else
        {
            Destroy(_currentRenderMonster);
            _currentRenderMonster = Instantiate(_interogation, this.transform.position, Quaternion.identity, _rotatingParent);
            _name.text = "?";
            _description.text = "?";
        }
    }
}
