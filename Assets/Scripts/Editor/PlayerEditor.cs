using RollBall;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestBehaviour))]
public class PlayerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        TestBehaviour player = (TestBehaviour)target;
        
        GUILayout.Label("Oscillates around a base size");
        
        player.transform.localScale = Vector3.one * player.baseSize;
        player.baseSize = EditorGUILayout.Slider("Change Size",player.baseSize, 1f, 5f);
        
        GUILayout.BeginHorizontal();
        

        if (GUILayout.Button("Generate Color"))
        {
            player.GenerateColor();
        }
        if (GUILayout.Button("Reset"))
        {
            player.Reset();
        }
        
        GUILayout.EndHorizontal();
    }
}
