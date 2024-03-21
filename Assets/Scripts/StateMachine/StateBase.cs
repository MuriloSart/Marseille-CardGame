using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _Core.StateMachine
{
    public class StateBase
    {
        public virtual void OnStateEnter(object o = null)
        {

        }
        public virtual void OnStateStay()
        {

        }
        public virtual void OnStateExit()
        {

        }
    }
}