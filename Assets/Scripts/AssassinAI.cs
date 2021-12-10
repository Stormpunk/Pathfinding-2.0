using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AssassinAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject endDoor;
    public Animator assAnim;
    public bool isMoving;
    public bool isJumping;
    public bool isGrounded;
    public StatemachineAssassin stateAssassin;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = endDoor.transform.position;
        if (isMoving == true && isGrounded == false)
        {
            assAnim.SetBool("isRunning", true);
        }
        if (isGrounded == false)
        {
            stateAssassin.Jump();
        }
        else
        {
            stateAssassin.Stealth();
        }
        if(isJumping == true)
        {
            assAnim.SetTrigger("Jump");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }
}
