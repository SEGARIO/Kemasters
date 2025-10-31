using UnityEngine;

public class BossMap : MonoBehaviour
{
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator.SetBool("IsInMap", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
