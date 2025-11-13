
namespace Cerebrynth
{
    public class BuildAbstractClass : IScriptBuilder
    {
        public BuildAbstractClass(bool hasNamespace) :base(hasNamespace)
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
                _script.FinalScript.Append($"\tpublic abstract class {className} : MonoBehaviour\n\t{{\n");
            }
            else
            {
                _script.FinalScript.Append($"public abstract class {className} : MonoBehaviour\n{{\n");
            }
            return this;
        }

    }
}
