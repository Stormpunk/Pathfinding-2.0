using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State
{
    Run, Carrying
}

public class StateMachine : MonoBehaviour
{
    [SerializeField] private State state;
    public HumanAgent waypointAI;

    public IEnumerator Moving()
    {
        Debug.Log("Is Moving");
        while (state == State.Run)
        {
            waypointAI.isMoving = true;
            yield return null;
        }
        NextState();
        Debug.Log("Not Moving anymore");
    }
    public IEnumerator Encumbered()
    {
        Debug.Log("weighed down!");
        while (state == State.Carrying)
        {
            waypointAI.isEncumbered = true;
            yield return null;
        }
        NextState();
        Debug.Log("Whew, no more weight");
    }
    
    private void Start()
    {
        NextState();
    }
    private void NextState()
    {
        switch (state)
        {
            case State.Run:
                StartCoroutine(Moving());
                break;
            case State.Carrying:
                StartCoroutine(Encumbered());
                break;
        }
    }
}
