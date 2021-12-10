using System.Collections;
using UnityEngine;

public enum AssState
{
    Sneak, Jump
}
public class StatemachineAssassin : MonoBehaviour
{
    [SerializeField] private AssState state;
    public AssassinAI assAI;
    public IEnumerator Stealth()
    {
        Debug.Log("Sneaky beaky like");
        while(state == AssState.Sneak)
        {
            assAI.isMoving = true;
            yield return null;
        }
        NextState();

    }
   public IEnumerator Jump()
    {
        Debug.Log("Boing");
        while(state == AssState.Jump)
        {
            assAI.isJumping = true;
            yield return null;
        }
        NextState();
    }
    // Start is called before the first frame update
    void Start()
    {
        NextState();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
   public void NextState()
    {
        switch (state)
        {
            case AssState.Sneak:
                StartCoroutine(Stealth());
                break;
            case AssState.Jump:
                StartCoroutine(Jump());
                break;
        }
    }
}
