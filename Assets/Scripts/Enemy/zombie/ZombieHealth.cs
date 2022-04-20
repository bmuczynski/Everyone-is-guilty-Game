using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{

    public float health = 100f;
    public event Action PlayDeath; // -> animationStateController 
    public bool dead;
    public event Action TurnOffCapsule; // -> zombie_movement




    private void Start()
    {
    }










    public void  CheckKill() {
        
        if (health <= 0)
        {
            
                PlayDeath?.Invoke();
                Debug.Log("zabiles");
                dead = true;
                TurnOffCapsule?.Invoke();
            

        }
            }

}
