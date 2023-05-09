using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public BaseState activeState;
    //property for patrol state.
    

    public void Initialise()
    {
        ChangeState(new PatrolState());
    }    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(activeState != null)
        {
            activeState.Perform();
        }
    }
    public void ChangeState(BaseState newState)
    {
        //check activeState !=[null]
        if(activeState != null)
        {
            activeState.Exit();
        }
        //change new state
        activeState = newState;

        //fail-safe null check for make sure that new state wasn't null
        if(activeState != null)
        {
            //set up new state
            activeState.stateMachine = this;
            activeState.enemy = GetComponent<Enemy>();
            activeState.Enter();
        }
    }    
}
