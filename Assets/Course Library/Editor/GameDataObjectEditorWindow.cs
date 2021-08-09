using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameDataObjectEditorWindow : ExtendedEditorWindow
{
    public static void Open(GameDataObject dataObject)
    {
        GameDataObjectEditorWindow window = GetWindow<GameDataObjectEditorWindow>("Game Data Editor");
        window.serializedObject = new SerializedObject(dataObject);
    }

    private void OnGUI()
    {
        // currentProperty = serializedObject.FindProperty("gameData");
        // DrawProperties(currentProperty, true);
    }
}
