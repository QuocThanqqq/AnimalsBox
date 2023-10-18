using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpriteEditor : EditorWindow
{
    private Sprite spriteToEdit;
    private int id;
    private string Name;
    private List<SpriteData> spriteDataList = new List<SpriteData>();
    private Vector2 scrollPos;
    
    [MenuItem("Window/Sprite Editor")]
    public static void ShowWindow()
    {
        GetWindow<SpriteEditor>("Sprite Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("Edit Sprite", EditorStyles.boldLabel);
        scrollPos = EditorGUILayout.BeginScrollView(scrollPos, GUILayout.Height(700));

       
        for (int i = 0; i < spriteDataList.Count; i++)
        {
            DrawSpriteData(spriteDataList[i]);
            
            if (GUILayout.Button("Delete", GUILayout.Width(60)))
            {
                spriteDataList.RemoveAt(i);
                i--;
            }
            if (i < spriteDataList.Count - 1)
            {
                GUILayout.Space(10);
            }
        }
        

        EditorGUILayout.EndScrollView();
        GUILayout.Space(10);
        if (GUILayout.Button("Add Sprite"))
        {
            spriteDataList.Add(new SpriteData());
        }

        if (GUILayout.Button("Save"))
        {
            foreach (var data in spriteDataList)
            {
                EditorUtility.SetDirty(data.spriteToEdit);
            }
        }
    }

    private void DrawSpriteData(SpriteData data)
    {
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.LabelField("ID", GUILayout.Width(15));
        data.id = EditorGUILayout.IntField(data.id, GUILayout.Width(40));

        GUILayout.Space(10);

        EditorGUILayout.LabelField("Name", GUILayout.Width(40));
        data.Name = EditorGUILayout.TextField(data.Name, GUILayout.Width(100));

        GUILayout.Space(10);

        EditorGUILayout.LabelField("Sprite", GUILayout.Width(50));
        data.spriteToEdit = (Sprite)EditorGUILayout.ObjectField(data.spriteToEdit, typeof(Sprite), false, GUILayout.Width(100), GUILayout.Height(100));

        EditorGUILayout.EndHorizontal();
    }
    
    
}

public class SpriteData
{
    public int id;
    public string Name;
    public Sprite spriteToEdit;
}
