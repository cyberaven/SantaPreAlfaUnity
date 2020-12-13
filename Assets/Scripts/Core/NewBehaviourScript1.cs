using UnityEngine;
using System.Collections;
using System;

namespace Rules
{
    public class Rule1 : MonoBehaviour
    {
        //так делать нельзя!!!
        private int printerError = 0;

        private void Start()
        {
            if (printerError == 0)//для этого есть true/false. Вот так надо --> if(true)DoWork(); 
            {
                DoWork();
            }
        }

        private void DoWork()
        {            
        }

        private void Examples()
        {
            //obj?.method?.attr

            //SomeClass a = null;
            //a?.some_method();
            //if (a != null)
            //{
            //    a.some_method();
            //}
        }
    }
}