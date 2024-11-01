using UnityEditor;
using UnityEngine;

namespace TDS.Game.Enemy
{
    [CustomEditor(typeof(PatrolPath))]
    public class PatrolPathEditor : Editor
    {
        #region Public methods

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Collect Points"))
            {
                ((PatrolPath)target).CollectPoints();

                serializedObject.ApplyModifiedProperties();
                serializedObject.Update();
            }
        }

        #endregion

        #region Private methods

        [DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
        private static void DrawGizmo(PatrolPath path, GizmoType gizmoType)
        {
            if (!IsGameObjectOrChildrenSelected(path))
            {
                return;
            }

            if (path.Points == null || path.Points.Count <= 0)
            {
                return;
            }
            
            for (int i = 0; i < path.Points.Count; i++)
            {
                Transform point = path.Points[i];
                if (point == null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(path.transform.position, 1.2f);
                    continue;
                }
                
                Gizmos.color = Color.blue;

                Gizmos.DrawSphere(point.position, 0.2f);
                Transform nextPoint = path.Points[GetNextPoint(i)];
                if (nextPoint != null)
                {
                    Gizmos.DrawLine(point.position, nextPoint.position);
                }
            }

            int GetNextPoint(int currentIndex)
            {
                int index = currentIndex + 1;
                if (index >= path.Points.Count)
                {
                    index = 0;
                }

                return index;
            }
        }

        private static bool IsGameObjectOrChildrenSelected(PatrolPath path)
        {
            GameObject activeGameObject = Selection.activeGameObject;
            if (activeGameObject == null)
            {
                return false;
            }

            if (path.gameObject == activeGameObject)
            {
                return true;
            }

            for (int i = 0; i < path.transform.childCount; i++)
            {
                if (path.transform.GetChild(i).gameObject == activeGameObject)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
    }
}