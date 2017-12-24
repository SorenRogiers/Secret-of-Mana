using UnityEditor;
using UnityEngine;

[CustomEditor(typeof (Character_EnemyBehaviour))]
public class Enemy_FOV : Editor
{
    private void OnSceneGUI()
    {
        Character_EnemyBehaviour enemy = (Character_EnemyBehaviour)target;
        Handles.color = Color.white;

        //Draw the view range of enemy
        Handles.DrawWireArc(enemy.transform.position, Vector3.up, Vector3.forward, 360, enemy.ViewRadius);

        //Create a cone to visualize the view angle
        Vector3 viewAngleA = enemy.DirectionFromAngle(-enemy.ViewAngle / 2, false);
        Vector3 viewAngleB = enemy.DirectionFromAngle(enemy.ViewAngle / 2, false);

        Handles.DrawLine(enemy.transform.position, enemy.transform.position + viewAngleA * enemy.ViewRadius);
        Handles.DrawLine(enemy.transform.position, enemy.transform.position + viewAngleB * enemy.ViewRadius);

        //Draw a line towards the target if he is in our field of view
        Handles.color = Color.red;
        if (enemy.IsTargetInFov)
            Handles.DrawLine(enemy.transform.position, enemy.Target.transform.position);
    }
}
