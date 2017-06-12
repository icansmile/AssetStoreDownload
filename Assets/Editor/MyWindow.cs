using UnityEditor;
using UnityEngine;

public class MyWindow: EditorWindow
{
    string url;
    string key;
    
    string path;  
    string packagePath;
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
        EditorGUI.LabelField(new Rect(0, 0, 100, 20), "json path");
        path = filePathReceiver(new Rect(100, 0, 500, 20), path);

        if(GUI.Button(new Rect(0, 30, 100, 50), "Get"))
        {
            url = Tool.GetUrl(path); 
            key = Tool.GetKey(path); 
        }

        EditorGUI.LabelField(new Rect(0, 90, 100, 20), "url");
        EditorGUI.SelectableLabel(new Rect(100, 90, 500, 20), url);

        EditorGUI.LabelField(new Rect(0, 120, 100, 20), "key");
        EditorGUI.SelectableLabel(new Rect(100, 120, 500, 20), key);

        EditorGUI.LabelField(new Rect(0, 180, 100, 20), "package path");
        packagePath = filePathReceiver(new Rect(100, 180, 500, 20), packagePath);

        if(GUI.Button(new Rect(0, 220, 100, 50), "Decrypt"))
        {
            Tool.DecryptUnityPackage(packagePath, key);
        }
    }

    string filePathReceiver(Rect rect, string content)
    {
        // //获得一个长width的框  
        // rect = EditorGUILayout.GetControlRect(GUILayout.Width(labelWidth));  
        // //将上面的框作为文本输入框  
        content = EditorGUI.TextField(rect, content);  

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