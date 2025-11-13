

namespace Cerebrynth
{

    public class BuildScriptableObjectClass : IScriptBuilder
    {
        public BuildScriptableObjectClass(bool hasNamespace) : base(hasNamespace) 
        {

        }
        public override IScriptBuilder AddUsingStatements()
        {
            _script.FinalScript.Append($"using System;\nusing System.Collections.Generic;\nusing UnityEngine;\n\n");
            return this;
        }

        public override IScriptBuilder AddClassName(string className)
        {
            if(_script.HasNamepspace)
            {
                _script.FinalScript.Append($"\t[CreateAssetMenu(fileName = \"{className} Scriptable Object\", menuName = \"MyScriptableObject/{className}\")]\n");
                _script.FinalScript.Append($"\tpublic class {className} : ScriptableObject\n\t{{\n");
            }
            else
            {
                _script.FinalScript.Append($"[CreateAssetMenu(fileName = \"{className} Scriptable Object\", menuName = \"MyScriptableObject/{className}\")]\n");
                _script.FinalScript.Append($"public class {className} : ScriptableObject\n{{\n");
            }

            return this;
        }

    }

}