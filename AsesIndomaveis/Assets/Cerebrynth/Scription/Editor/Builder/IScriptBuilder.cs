using static UnityEditor.ObjectChangeEventStream;
using UnityEngine;

namespace Cerebrynth
{
    public abstract class IScriptBuilder
    {
        private readonly string _nsMethodBrackets = $"\n\t\t{{\n\n\n\t\t}}\n";
        private readonly string _methodBrackets = $"\n\t{{\n\n\n\t}}\n";
        protected ScriptProduct _script;
        public ScriptProduct Script => _script;
        public IScriptBuilder(bool hasNamespace)
        {
            _script = new ScriptProduct();
            _script.HasNamepspace = hasNamespace;
        }
        public abstract IScriptBuilder AddUsingStatements();
        public virtual IScriptBuilder AddNameSpace(string nameSpace)
        {
            if (_script.HasNamepspace)
            {
                _script.FinalScript.Append($"namespace {nameSpace}\n{{\n");
            }

            return this;
        }
        public abstract IScriptBuilder AddClassName(string className);
        public virtual IScriptBuilder AddUnityMessages(InputData data)
        {
            foreach (var msg in data.UnityMessages)
            {
                if (_script.HasNamepspace)
                {
                    _script.FinalScript.Append($"\t\tprivate void {msg}(){_nsMethodBrackets}");
                }
                else
                {
                    _script.FinalScript.Append($"\tprivate void {msg}(){_methodBrackets}");
                }
            }

            return this;
        }
        public virtual IScriptBuilder Build()
        {
            if (_script.HasNamepspace)
            {
                _script.FinalScript.Append($"\n\t}}\n}}");
            }
            else
            {
                _script.FinalScript.Append($"\n}}");
            }
            return this;
        }

        public override string ToString()
        {
            return _script.FinalScript.ToString();
        }

    }
}
