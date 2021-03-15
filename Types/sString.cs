using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace BIAB.DataTypes
{
    public class sString
    {
        public delegate void OnStringChangeDelegate(string newVal);
        public event OnStringChangeDelegate OnStringChange;
        private string trackedVariable;
        public string variable
        {
            get
            {
                return trackedVariable;
            }
            set
            {
                if (trackedVariable != value)
                    if (OnStringChange != null) OnStringChange(value);
                trackedVariable = value;
            }
        }

        public sString()
        {

        }

        public sString(string str)
        {
            trackedVariable = str;
        }


        public static implicit operator string(sString rhs)
        {
            return rhs.variable;
        }
        public static implicit operator sString(string rhs)
        {
            return new sString(rhs);
        }

    }
}