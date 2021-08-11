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
        DrawMainLabel();
        DrawSizeSlider();
        DrawAdditionalSettings();
    }

    private static void DrawMainLabel() => GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
    
    private void DrawSizeSlider() => size = EditorGUILayout.Slider("Size", size, 1f, 3f);

    private void DrawAdditionalSettings()
    {
        groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", groupEnabled);
        
        DrawObjectNameInput();
        DrawColorField();
        DrawButtonColorizeSelected();
        DrawButtonColorizeByName();
        
        EditorGUILayout.EndToggleGroup();
    }

    private void DrawObjectNameInput() => nameObject = EditorGUILayout.TextField("Имя объекта", nameObject);

    private void DrawColorField()
    {
        GUILayout.Label("Color the selected objects", EditorStyles.boldLabel);
        color = EditorGUILayout.ColorField("Color", color);
    }

    private void DrawButtonColorizeSelected()
    {
        if (GUILayout.Button("COLORIZE SELECTED"))
        {
            ColorizeSelectedObject();
        }
    }

    private void ColorizeSelectedObject()
    {
        foreach (GameObject obj in Selection.gameObjects)
        {
            ColorizeGameObject(obj);
        }
    }

    private void DrawButtonColorizeByName()
    {
        if (GUILayout.Button("COLORIZE BY NAME"))
        {
            GameObject foundGameObject = GameObject.Find(nameObject);
            if (foundGameObject != null)
            {
                ColorizeGameObject(foundGameObject);
            }
            else
            {
                Debug.LogError("Object by name not found");
            }
        }
    }

    private void ColorizeGameObject(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            renderer.sharedMaterial.color = color;
        }
    }
}
