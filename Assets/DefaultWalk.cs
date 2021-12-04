using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefaultWalk : StateMachineBehaviour
{
    private Transform door;
    private NavMeshAgent agent;

    [HideInInspector]
    public bool isPathAvailable;
    public NavMeshPath navMeshPath;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        door = GameObject.FindGameObjectWithTag("Door").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        agent.destination = door.transform.position;
        navMeshPath = new NavMeshPath();
        agent.CalculatePath(agent.destination, navMeshPath);
        if(navMeshPath.status == NavMeshPathStatus.PathPartial)
        {
            animator.SetBool("isLookingForKey", true);
            Debug.Log("Path not reachable, changing state to key search");
        }
        else
        {
            Debug.Log("This shouldn't be the first message when run");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
            agent.SetDestination(door.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
