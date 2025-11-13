

namespace Cerebrynth
{
    public class BuildStruct : IScriptBuilder
    {
        public BuildStruct(bool hasNamespace) : base(hasNamespace)
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
                _script.FinalScript.Append($"\tpublic struct {className}\n\t{{\n");
            }
            else
            {
                _script.FinalScript.Append($"public struct {className}\n{{\n");
            }
            return this;
        }

    }

}