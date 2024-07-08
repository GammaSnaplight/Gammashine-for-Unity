using System;
using System.Collections.Generic;

using UnityEngine;
using UnityEditor;

using Snaplight.Extension;

//namespace Snaplight
//{
//    [CustomPropertyDrawer(typeof(VisualizationDictionary<,>))]
//    public class VisualizationDictionaryDrawer : PropertyDrawer
//    {
//        private EditorGUI _gui = new();

//        private GUIStyle _guiStyle = new();

//        private bool _foldout;
//        private bool _touchdown;
//        private bool _lookTouchdown;
//        private bool _look;

//        SerializedProperty keys;
//        SerializedProperty values;
//        SerializedProperty isSerialize;

//        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
//        {
//            EditorGUI.BeginProperty(position, label, property);

//            keys = property.FindPropertyRelative("_keys");
//            values = property.FindPropertyRelative("_values");
//            isSerialize = property.FindPropertyRelative("IsSerialize");

//            GUILayout.Space(-15);

//            GUIStyle background = new();
//            background.normal.background = _gui.CreateColorBox(200, 200, Colorlight.Mix(Colorlight.RichRazzleberry, 1, 4));


//            EditorGUILayout.BeginVertical(background);

//            _guiStyle.fontSize = 16;
//            _guiStyle.fontStyle = FontStyle.Bold;
//            _guiStyle.normal.textColor = Colorlight.MangoMelody;

//            EditorGUILayout.BeginHorizontal();

//            string input = values.arrayElementType;
//            int startIndex = input.IndexOf('$') + 1;
//            int length = input.IndexOf('>') - startIndex;
//            string result = input.Substring(startIndex, length);

//            _lookTouchdown = GUILayout.Button(_look ? "Unlock" : "Look", GUILayout.Width(55), GUILayout.Height(16));
//            _touchdown = GUILayout.Button(_foldout ? "Unwrap" : "Wrap", GUILayout.Width(55), GUILayout.Height(16));

//            _foldout = EditorGUILayout.Foldout(_foldout,
//                _foldout ?
//                   _look ? $"Dictionary [{keys.arraySize}]" : $"Dictionary [{keys.arraySize}] (Look)"
//                         : $"Dictionary<{keys.arrayElementType}, {result}> [{keys.arraySize}]", _guiStyle);

//            if (_touchdown) _foldout = !_foldout;
//            if (_lookTouchdown) _look = !_look;
//            EditorGUILayout.EndHorizontal();

//            if (_foldout) GUILayout.Space(5);
//            else GUILayout.Space(0);

//            //if (keys.arraySize > 3) isSerialize.boolValue = true;
//            //else isSerialize.boolValue = false;

//            if (_foldout)
//            {
//                EditorGUILayout.BeginHorizontal();

//                if (keys.arraySize == 0)
//                {
//                    if (GUILayout.Button($"New Dictionary +", GUILayout.Width(250), GUILayout.Height(25)))
//                    {
//                        keys.arraySize = 5;
//                        values.arraySize = 5;

//                        //isSerialize.boolValue = true;
//                    }
//                }
//                else
//                {
//                }
//                    if (GUILayout.Button("Collection ✓", GUILayout.Width(100), GUILayout.Height(25)))
//                    {
//                        keys.arraySize++;
//                        values.arraySize++;

//                    //isSerialize.boolValue = true;
//                }

//                if (_look && keys.arraySize != 0 && GUILayout.Button("Elimination ✕", GUILayout.Width(100), GUILayout.Height(25)))
//                {
//                    keys.arraySize--;
//                    values.arraySize--;
//                }

//                if (_look && keys.arraySize != 0 && GUILayout.Button("Destruction ◯", GUILayout.Width(100), GUILayout.Height(25)))
//                {
//                    keys.arraySize = 0;
//                    values.arraySize = 0;
//                }

//                EditorGUILayout.EndHorizontal();

//                GUIStyle backgroundStyle = new();
//                backgroundStyle.normal.background = _gui.CreateColorBox(200, 200, Colorlight.Mix(Colorlight.RedReal, 1, 2));
//                for (int i = 0; i < keys.arraySize; i++)
//                {
//                    EditorGUILayout.BeginVertical(backgroundStyle);

//                    EditorGUILayout.BeginHorizontal();

//                    EditorGUILayout.LabelField($" {i} →", GUILayout.MaxWidth(50));

//                    EditorGUILayout.PropertyField(keys.GetArrayElementAtIndex(i), GUIContent.none, GUILayout.MinWidth(50), GUILayout.MaxWidth(200));
//                    EditorGUILayout.PropertyField(values.GetArrayElementAtIndex(i), GUIContent.none, GUILayout.MinWidth(50), GUILayout.MaxWidth(200));

//                    EditorGUILayout.EndHorizontal();

//                    EditorGUILayout.EndVertical();
//                }
//            }

//            GUILayout.Space(50);
//            EditorGUILayout.EndVertical();
//            EditorGUI.EndProperty();
//        }
//    }
//}
