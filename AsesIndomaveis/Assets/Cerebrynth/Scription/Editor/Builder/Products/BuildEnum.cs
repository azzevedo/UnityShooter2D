
namespace Cerebrynth
{

    public class BuildEnum : IScriptBuilder
    {
        public BuildEnum(bool hasNamespace) : base(hasNamespace)
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
                _script.FinalScript.Append($"\tpublic enum {className}\n\t{{\n");
            }
            else
            {
                _script.FinalScript.Append($"public enum {className}\n{{\n");  
            }
            return this;
        }

    }

}