using UnityEngine;
using UnityEngine.SceneManagement;

public class BossMap : MonoBehaviour
{
    public Animator animator;
    public SO_Monster _monster;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.SetBool("IsInMap", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Fight()
    {
        Debug.Log("Fight!");
        ManagerInMap _man = FindObjectOfType<ManagerInMap>();
        PlayerMovement _payer = FindObjectOfType<PlayerMovement>();
        _payer.enabled = false;
        Rigidbody _rb = _payer.gameObject.GetComponent<Rigidbody>();
        _rb.isKinematic = true;
        _man._monsterForFight = _monster;
        _man._transitionAnimator.SetTrigger("ActivateBoss");
        Invoke("ChangeScene", 5);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("CombatScene");
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Fight();

        }
    }
}
