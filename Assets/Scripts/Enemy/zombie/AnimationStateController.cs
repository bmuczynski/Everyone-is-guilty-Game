using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateController : MonoBehaviour
{
    
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        GetComponent<ZombieMovement>().PlayerInRange += ChangeAnimationToRun;
        GetComponent<ZombieMovement>().Speed += ChangeAnimationToWalk;
        GetComponent<ZombieHealth>().PlayDeath += ChangeAnimationToDeath;
        GetComponent<ZombieMovement>().Attack += AttackAnim;
       
    }

    // Update is called once per frame
    void ChangeAnimationToRun()
    {

        animator.SetBool("IsRunning", true);
        animator.SetFloat("Blend", 1f);
        animator.SetBool("IsNearTarget", false);

    }


    void ChangeAnimationToWalk()
    {
        animator.SetBool("IsRunning", true);
        animator.SetFloat("Blend", 0.7f);
        animator.SetBool("IsNearTarget", false);
        

    }


    void ChangeAnimationToDeath()
    {
        //Debug.Log("wykonalo sie");
        animator.SetBool("IsRunning", false);
        animator.SetBool("IsDead", true);

    }


    void AttackAnim()
    {
        
        if (animator.GetBool("IsDead") == false  /* && GetComponent<ZombieMovement>().agent.remainingDistance <= 2.0f*/ )
        {
            
            animator.SetBool("IsNearTarget",true);
            animator.SetBool("IsRunning", false);


        }
        

    }




}
