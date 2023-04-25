using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;


public class EnemyFollow : MonoBehaviour
{
    public GameObject Target;
    public GameObject currentTarget;
    public NavMeshAgent myAgent;
    public int rangeFrom;
    public int tetherRange;
    public Vector3 startPos;
    private Animator _animator;
    private Vector3 onPlace;
    
    //Audio
    private AudioSource _audioSource;

    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        InvokeRepeating("DistCheck",0 ,0.5f);
        startPos = this.transform.position;
        _animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        EnemyFollows();
    
    }

    private void EnemyFollows(){
        if(currentTarget != null)
        {
            myAgent.destination = currentTarget.transform.position;
            _animator.SetBool("ZombRunning", true);

        }else{
            _animator.SetBool("ZombRunning", false);
        }
    }
        
    public void DistCheck()
    {
        float dist = Vector3.Distance(this.transform.position, Target.transform.position);

        if(dist < rangeFrom)
        {
            currentTarget = Target;
        }
        else if (dist > tetherRange)
        {
            currentTarget = null;
        }
    }


}