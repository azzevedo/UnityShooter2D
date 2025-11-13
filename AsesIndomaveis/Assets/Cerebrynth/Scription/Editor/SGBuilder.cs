using System.IO;
using UnityEditor;
using UnityEngine;


namespace Cerebrynth
{
    public static class SGBuilder
    {

        #region Data
        private static InputData _data;
        #endregion

        private static ScriptBuilder _scriptBuilder;

        public static void ExportScript(InputData data)
        {
            _data = data;
            _scriptBuilder = new ScriptBuilder(_data);

            if (!Directory.Exists(data.SavePath)) Directory.CreateDirectory(data.SavePath);
            var extension = data.ClassType.ToString() == "HLSL" ? ".hlsl" : ".cs";

            string tempPath = _data.SavePath + ($"{_data.Name}{extension}");
            _data.SavePath = tempPath.CheckExistingFileName(_data,out _data.Name);


            //Let's do this!
            File.WriteAllText(_data.SavePath, _scriptBuilder.BuildNewScript());
            AssetDatabase.Refresh();
        }

    }
}

