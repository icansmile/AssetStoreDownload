using UnityEditor;
using UnityEngine;

public class MyWindow: EditorWindow
{
    string myString = "hello";
    bool groupEnabled;
    bool myBool;
    float myFloat;
    Object myObj;


    string path;  
    Rect rect;  


    [MenuItem("Tool/ShowWindow")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(MyWindow));
        Debug.Log("show");
    }

    /// <summary>
    /// OnGUI is called for rendering and handling GUI events.
    /// This function can be called multiple times per frame (one call per event).
    /// </summary>
    void OnGUI()
    {
        GUILayout.Label("BaseSetting", EditorStyles.boldLabel); 
        path = filePathReceiver("路径", 500, path);
    }
    

    string filePathReceiver(string title, int labelWidth, string content)
    {
        EditorGUILayout.BeginHorizontal();

            EditorGUI.LabelField(new Rect(3, 3, position.width, 20), title);  
            //获得一个长width的框  
            rect = EditorGUILayout.GetControlRect(GUILayout.Width(labelWidth));  
            //将上面的框作为文本输入框  
            content = EditorGUI.TextField(rect, path);  

        EditorGUILayout.EndHorizontal();

        //如果鼠标正在拖拽中或拖拽结束时，并且鼠标所在位置在文本输入框内  
        if ((Event.current.type == EventType.DragUpdated  
            || Event.current.type == EventType.DragExited)  
            && rect.Contains(Event.current.mousePosition))  
        {  
            DragAndDrop.visualMode = DragAndDropVisualMode.Generic;  
            if (DragAndDrop.paths != null && DragAndDrop.paths.Length > 0)  
            {  
                content = DragAndDrop.paths[0];  
            }  
        }

        return content;
    }
}