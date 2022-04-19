using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class ZombieMovement : MonoBehaviour
{
    bool charge = true;
    public NavMeshAgent agent;
    public GameObject gracz;
    public Component SphereColider;
    public Component AnimationState;
    CapsuleCollider CapsuleCollider;
    public int SeePlayer = 0; // tak wiem mog³em zrobiæ to boolem :D
    bool InRange = false;
    bool coroutine = true;
   


    public event Action PlayerInRange; // -> animationStateController
    public event Action Speed; // -> animationStateController
    public event Action Attack; // -> animationStateController
    
    public PlayerHealthMenager playerHealthMenager;

    AudioSource ZombieSound;

    
    // Start is called before the first frame update
    void Start()
    {
       
        CapsuleCollider = GetComponent<CapsuleCollider>(); // tak kazali wy³¹czaæ kolizje :/ 
        GetComponent<ZombieHealth>().TurnOffCapsule += CapsuleOff; // referencja do eventu 
        
        agent.stoppingDistance = 2f;
       
        StartCoroutine(MojaPierwszaKorutyna());
        ZombieSound = GetComponent<AudioSource>();

        
    }
   





    // Update is called once per frame
    void Update()
    {
       
        
        if (SeePlayer >= 1 && GetComponent<ZombieHealth>().dead == false)
        {

            agent.SetDestination(gracz.transform.position); // idzie do gracza

            if (agent.remainingDistance <= 2.0f && agent.remainingDistance != 0)
            {
                
                InRange = true;
                Attack?.Invoke();
                if (coroutine)
                StartCoroutine(MojaPierwszaKorutyna());
                
                
                
                

            }


            else if (agent.remainingDistance >= 2.5f && agent.remainingDistance != 0)
                
            {
                InRange = false;
                
                PlayerInRange?.Invoke();
                if (charge == false)// jeœli biega³ to ma iœæ
                                     
                    Speed?.Invoke();
            }


            
            




        }
        
    }
    IEnumerator MojaPierwszaKorutyna()
    {
        coroutine = false;
        
            while (InRange && GetComponent<ZombieHealth>().dead == false)
        {
            Debug.Log("robie korutyne");
            yield return new WaitForSeconds(1.5f);
            playerHealthMenager.DealDamagePlayer();
           
        }
        coroutine = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (GetComponent<ZombieHealth>().dead == false)
        {
            
            if (other.CompareTag("Player"))
            {
                SeePlayer = 1;
                InvokeRepeating("speed", 2, 3);
                PlayerInRange?.Invoke();
                ZombieSound.Play();




            }
        }
        
    }
    



    void speed() // zombie staj¹ siêwolniejsze po kilku sekundach gonitwy 
    
    {

        agent.speed--;
        agent.speed = Mathf.Clamp(agent.speed, 2, 5);


        if (GetComponent<ZombieHealth>().dead == false)
        {
            if (agent.speed <= 2)
            {
                Speed?.Invoke();
                charge = false;

            }
        }


    }
    

    void CapsuleOff() // wy³¹cz capsule by mo¿na by³o chodziæ po zw³okach 
    {
        

            if (GetComponent<ZombieHealth>().dead == true)
            {

                CapsuleCollider.enabled = !CapsuleCollider.enabled;
                
                    agent.enabled = !agent.enabled;
                ZombieSound.Stop();

             }
        



    }
   


    void NearTarget()
    {

        
        Attack?.Invoke();
        
       



    }


    
       
        
            
        
    


}
