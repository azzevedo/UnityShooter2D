using System;

namespace Cerebrynth
{
    public class ScriptBuilder
    {
        private IScriptBuilder _builder;
        private InputData _data;
        public ScriptBuilder(InputData data)
        {
            _data = data;
        }

        public string BuildNewScript()
        {
            string result = _data.ClassType switch
            {
                ClassTypes.MonoBehaviour => BuildMonoBehaviour(_data),
                ClassTypes.BaseClass => BuildBaseClass(_data),
                ClassTypes.Abstract => BuildAbstractClass(_data),
                ClassTypes.Interface => BuildInterface(_data),
                ClassTypes.ScriptableObject => BuildScriptableObject(_data),
                ClassTypes.Enum => BuildEnum(_data),
                ClassTypes.Struct => BuildStruct(_data),
                ClassTypes.HLSL => BuildHlsl(_data),
                _ => throw new Exception("No ClassType selected.")
            };
            return result;

        }
        private string BuildMonoBehaviour(InputData data)
        {
            _builder = new BuildMonoBehaviour(data.EnableNamespace);
            _builder.AddUsingStatements();
            _builder.AddNameSpace(data.NameSpace);
            _builder.AddClassName(data.Name);
            _builder.AddUnityMessages(data);
            _builder.Build();
            return _builder.ToString();
        }

        private string BuildBaseClass(InputData data)
        {
            _builder = new BuildBaseClass(data.EnableNamespace);
            _builder.AddUsingStatements();
            _builder.AddNameSpace(data.NameSpace);
            _builder.AddClassName(data.Name);
            _builder.Build();
            return _builder.ToString();
        }

        private string BuildAbstractClass(InputData data)
        {
            _builder = new BuildAbstractClass(data.EnableNamespace);
            _builder.AddUsingStatements();
            _builder.AddNameSpace(data.NameSpace);
            _builder.AddClassName(data.Name);
            _builder.AddUnityMessages(data);
            _builder.Build();
            return _builder.ToString();
        }

        private string BuildInterface(InputData data)
        {
            _builder = new BuildInterface(data.EnableNamespace);
            _builder.AddUsingStatements();
            _builder.AddNameSpace(data.NameSpace);
            _builder.AddClassName(data.Name);
            _builder.Build();
            return _builder.ToString();
        }

        private string BuildScriptableObject(InputData data)
        {
            _builder = new BuildScriptableObjectClass(data.EnableNamespace);
            _builder.AddUsingStatements();
            _builder.AddNameSpace(data.NameSpace);
            _builder.AddClassName(data.Name);
            _builder.AddUnityMessages(data);
            _builder.Build();
            return _builder.ToString();
        }

        private string BuildEnum(InputData data)
        {
            _builder = new BuildEnum(data.EnableNamespace);
            _builder.AddUsingStatements();
            _builder.AddNameSpace(data.NameSpace);
            _builder.AddClassName(data.Name);
            _builder.Build();
            return _builder.ToString();
        }

        private string BuildStruct(InputData data)
        {
            _builder = new BuildStruct(data.EnableNamespace);
            _builder.AddUsingStatements();
            _builder.AddNameSpace(data.NameSpace);
            _builder.AddClassName(data.Name);
            _builder.Build();
            return _builder.ToString();
        }

        private string BuildHlsl(InputData data)
        {
            return string.Empty;
        } 

    }

}

