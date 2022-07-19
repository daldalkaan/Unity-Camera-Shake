using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CameraPro;
using UnityEditor;

namespace CameraPro
{
    #if UNITY_EDITOR
    [CustomEditor(typeof(CameraShakeTester))]
    public class CameraShakeTesterEditor : Editor
    {
        CameraShakeTester cameraShaker;
        float magnitude = 1;
        float roughness = 1;
        float fadeInTime = 1;
        float fadeOutTime = 1;

        private void OnEnable() {
            cameraShaker = (CameraShakeTester)target;
        }

        public override void OnInspectorGUI()
        {
            magnitude = EditorGUILayout.FloatField("Magnitude:", magnitude);
            roughness = EditorGUILayout.FloatField("Roughness:", roughness);
            fadeInTime = EditorGUILayout.FloatField("FadeInTime:", fadeInTime);
            fadeOutTime = EditorGUILayout.FloatField("FadeOutTime:", fadeOutTime);

            EditorGUILayout.Space(10);

            if (GUILayout.Button("Shake Once"))
            {
                if (!Application.isPlaying) { return; }
                CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
            }

            //DrawDefaultInspector();
        }
    }
    #endif

    public class CameraShakeTester : MonoBehaviour
    {
        private void Awake()
        {
            if (!Application.isEditor)
            {
                Destroy(this);
            }
        }
    }
}