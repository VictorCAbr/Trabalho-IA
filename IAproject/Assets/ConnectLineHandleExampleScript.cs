// Draw lines to the connected game objects that a script has.
// If the target object doesnt have any game objects attached
// then it draws a line from the object to (0, 0, 0).

using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ConnectedObjectsExampleScript))]
class ConnectLineHandleExampleScript : Editor
{
    void OnSceneGUI()
    {
        ConnectedObjectsExampleScript connectedObjects = target as ConnectedObjectsExampleScript;
        if (connectedObjects.objs == null)
            return;

        Vector3 center = connectedObjects.transform.position;
        for (int i = 0; i < connectedObjects.objs.Length; i++)
        {
            GameObject connectedObject = connectedObjects.objs[i];
            if (connectedObject)
            {
                Handles.DrawLine(center, connectedObject.transform.position);
            }
            else
            {
                Handles.DrawLine(center, Vector3.zero);
            }
        }
    }
}