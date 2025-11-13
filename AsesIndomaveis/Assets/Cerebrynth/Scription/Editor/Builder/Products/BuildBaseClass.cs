using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cerebrynth
{
    public class BuildBaseClass : IScriptBuilder
    {
        public BuildBaseClass(bool hasNamespace) : base(hasNamespace)
        {
        }

        public override IScriptBuilder AddUsingStatements()
        {
            _script.FinalScript.Append($"using System;\nusing System.Collections.Generic;\nusing System.Collections;\n\n");
            return this;
        }
        public override IScriptBuilder AddClassName(string className)
        {
            if(_script.HasNamepspace)
            {
                _script.FinalScript.Append($"\tpublic class {className}\n\t{{\n");
            }
            else
            {
                _script.FinalScript.Append($"public class {className}\n{{\n");
            }
            return this;
        }

    }
}
