using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Cerebrynth
{
    public class ScriptProduct
    {
        public StringBuilder FinalScript = new StringBuilder();

        public bool HasNamepspace;

        public override string ToString()
        {
            return FinalScript.ToString();
        }
    }
}
