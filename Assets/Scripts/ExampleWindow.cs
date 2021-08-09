using System;
using UnityEngine;
using UnityEditor;

public class ExampleWindow :EditorWindow
{
    private Color color;
    private string nameObject= "Bonus";
    public bool groupEnabled;
    public float size;

    
    [MenuItem("Window/Colorizer")]
    public static void ShowWindow()
    {
      GetWindow<ExampleWindow>("Colorizer");
    }
    private void OnGUI()
    {
        GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
        nameObject = EditorGUILayout.TextField("Имя объекта", nameObject);

        groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки",
            groupEnabled);
        GUILayout.Label("Color the selected objects", EditorStyles.boldLabel);
         color = EditorGUILayout.ColorField("Color", color);
       // myString = EditorGUILayout.TagField("Name", myString);
        if (GUILayout.Button("COLORIZE"))
        {
            Colorize();
        }

       size = EditorGUILayout.Slider("Size", size, 1f, 3f);
    }

    private void Colorize()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            Renderer renderer =  obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.sharedMaterial.color = color;
            }
        }
    }
}
