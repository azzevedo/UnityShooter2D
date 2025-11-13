using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using UnityEditor.UIElements;
using System;

namespace Cerebrynth
{

    public class ScriptGeneratorWindow : EditorWindow
    {
        VisualElement _root;

        #region Parameters
        [SerializeField] private string _classType;
        [SerializeField] private string _className;
        [SerializeField] private string _nameSpace;
        [SerializeField] private bool _MsgsBool;
        [SerializeField] private string _extTxt;
        #endregion

        #region Elements
        EnumField _classTypeEnum;
        Toolbar _msgToolbar;
        Toolbar _msgMainToolbar;
        Toolbar _namespaceToolbar;
        List<string> _msgToggleNames;
        TextField _pathString;
        ToolbarToggle _namespaceToggle;
        ToolbarToggle _unityMessages;
        Label _extLabel;
        #endregion

        #region Strings
        private readonly string _UXMLPath = "Assets/Cerebrynth/Scription/Editor/Styles/SG_VisualElementTree.uxml";
        private readonly string _USSPath = "Assets/Cerebrynth/Scription/Editor/Styles/SG_Styles.uss";
        private readonly string _btnGenerate = "Generate_Script_Button";
        private readonly string _enumMenu = "Class_Types";
        const string _version = "1.4.0";
        #endregion

        [MenuItem("Tools/Cerebrynth/Scription")]
        public static void ShowWindow()
        {
            var win = GetWindow<ScriptGeneratorWindow>("Scription");
            win.minSize = new Vector2(290, 250);

        }

        #region Initialization
        void OnEnable()
        {
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            _root = rootVisualElement;

            var mySS = (StyleSheet)EditorGUIUtility.Load(_USSPath);
            _root.styleSheets.Add(mySS);

            var vTree = (VisualTreeAsset)EditorGUIUtility.Load(_UXMLPath);
            VisualElement windowStyle = vTree.CloneTree();

            _root.Add(windowStyle);

            _namespaceToggle = _root.Q<ToolbarToggle>("Togg_Namespace");
            _unityMessages = _root.Q<ToolbarToggle>("MSG_ToolBar");

            var versionTxt = _root.Q<Label>("Version_Text");
            versionTxt.text = _version;


            var generateBtn = _root.Q<Button>(_btnGenerate);
            generateBtn.clicked += () => Generate();

            _classTypeEnum = _root.Q<EnumField>(_enumMenu);
            _classTypeEnum.Init(ClassTypes.MonoBehaviour);
            var children = _classTypeEnum.Children();
            foreach (var child in children)
            {
                if (child.GetType() == typeof(VisualElement))
                {
                    child.pickingMode = PickingMode.Position;
                }
            }

            _msgToolbar = _root.Q<Toolbar>("MSG_ToolBar");
            _msgMainToolbar = _root.Q<Toolbar>("MSG_Main_Toolbar");
            var toggles = _msgToolbar.Children();
            _msgToggleNames = new List<string>();
            foreach (var toggle in toggles)
            {
                _msgToggleNames.Add(toggle.name);
            }

            _namespaceToolbar = _root.Q<Toolbar>("Namespace_ToolBar");

            _pathString = _root.Q<TextField>("PathStringField");

            var extLabel = _root.Q<Label>("Dot_EXT_Text");
            _extLabel = extLabel;

        }

        private void OnGUI()
        {
            if(_classTypeEnum.value.ToString() == "HLSL")
            {
                _msgMainToolbar.style.display = DisplayStyle.None;
                _namespaceToolbar.style.display = DisplayStyle.None;  
            }
            else
            {
                _msgMainToolbar.style.display = DisplayStyle.Flex;
                _namespaceToolbar.style.display = DisplayStyle.Flex;
            }
            _extLabel.text = _classTypeEnum.value.ToString() == "HLSL" ? ".hlsl" : ".cs";
        }

        #endregion


        private void Generate()
        {
            if (string.IsNullOrEmpty(_root.Q<TextField>("ClassName_TF").text))
            {
                return;
            }


            var data = new InputData();
            data.Name = ReturnTextValue("ClassName_TF", StringTypes.ClassName);
            data.EnableNamespace = _namespaceToggle.value;
            data.NameSpace = ReturnTextValue("Namespace_TF",StringTypes.Namespace);
            data.ClassType = (ClassTypes)_classTypeEnum.value;
            data.SelectedType = (ClassTypes)Enum.Parse(typeof(ClassTypes), _classTypeEnum.value.ToString());
            data.UMessages = false;
            data.SavePath = String.IsNullOrEmpty(_pathString.value)? "Assets/Scripts/" : $"Assets/Scripts/{ReturnTextValue("PathStringField", StringTypes.Path)}/";


            data.UnityMessages = new List<string>();
            for (int i= 0; i< _msgToggleNames.Count; i++)
            {
                if (_root.Q<ToolbarToggle>(_msgToggleNames[i]).value)
                {
                    data.UnityMessages.Add(_root.Q<ToolbarToggle>(_msgToggleNames[i]).name);
                }
            }

            
            SGBuilder.ExportScript(data);
        }

        private string ReturnTextValue(string name, StringTypes sType)
        {
            var element = _root.Q<TextField>(name);
            string result = element.text;
            element.value = null;
            return Utilities.ValidateString(result, sType);
        }

    }
}
