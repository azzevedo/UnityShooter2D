using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cerebrynth
{
    public class BuildInterface : IScriptBuilder
    {
        public BuildInterface(bool hasNamespace) : base(hasNamespace)
        {

        }
        public override IScriptBuilder AddUsingStatements()
        {
            return this;
        }
        public override IScriptBuilder AddClassName(string className)
        {
            if(_script.HasNamepspace)
            {
                _script.FinalScript.Append($"\tpublic interface {className}\n\t{{\n");
            }
            else
            {
                _script.FinalScript.Append($"public interface {className}\n{{\n");
            }
            return this;
        }

    }
}
