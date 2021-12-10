using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HumanAgent : MonoBehaviour
{
    #region Game objects
    public NavMeshAgent agent;
    public GameObject gold;
    public GameObject endDoor;
    public GameObject key;
    public GameObject lockedDoor;
    public Animator anim;
    public Animator doorAnim;
    #endregion
    #region Bools and Speed
    public bool doorIsLocked;
    public bool isEncumbered;
    public bool hasKey;
    public bool hasGold;
    public bool canLeave;
    public bool isMoving;
    public bool isWalking;
    #endregion
    public StateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { if(hasKey == false)
        {
            agent.destination = key.transform.position;
        }
    if(doorIsLocked == true && hasKey == true)
        {
            agent.destination = lockedDoor.transform.position;
        }
        if (doorIsLocked == false && hasGold == false)
        {
            agent.destination = gold.transform.position;
        }
        if (doorIsLocked == false && hasGold == true)
        {
            agent.destination = endDoor.transform.position;
        }
        if (isMoving == true && isEncumbered == false)
        {
            anim.SetBool("isMoving", true);
        }
        if(isMoving == true && isEncumbered == true)
        {
            anim.SetBool("isEncumbered", true);
            anim.SetBool("isMoving", false);
            agent.speed = 3.5f;
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Key")
        {
            hasKey = true;
            Destroy(collision.gameObject);
        }
      else  if (collision.gameObject.tag == "Gold")
        {
            hasGold = true;
            Destroy(collision.gameObject);
            isEncumbered = true;
        }
        else if (collision.gameObject.tag == "LockedDoor" && hasKey == true)
        {
            Debug.Log("Unlock");
            doorIsLocked = false;
            doorAnim.SetTrigger("Open");
        }
        else if(collision.gameObject.tag == "Door")
        {
            Destroy(this.gameObject);
        }
    }
}
