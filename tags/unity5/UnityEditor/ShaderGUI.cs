﻿namespace UnityEditor
{
    using System;
    using UnityEngine;

    public abstract class ShaderGUI
    {
        protected ShaderGUI()
        {
        }

        public virtual void AssignNewShaderToMaterial(Material material, Shader oldShader, Shader newShader)
        {
            material.shader = newShader;
        }

        protected static MaterialProperty FindProperty(string propertyName, MaterialProperty[] properties)
        {
            return FindProperty(propertyName, properties, true);
        }

        protected static MaterialProperty FindProperty(string propertyName, MaterialProperty[] properties, bool propertyIsMandatory)
        {
            for (int i = 0; i < properties.Length; i++)
            {
                if ((properties[i] != null) && (properties[i].name == propertyName))
                {
                    return properties[i];
                }
            }
            if (propertyIsMandatory)
            {
                object[] objArray1 = new object[] { "Could not find MaterialProperty: '", propertyName, "', Num properties: ", properties.Length };
                throw new ArgumentException(string.Concat(objArray1));
            }
            return null;
        }

        public virtual void OnGUI(MaterialEditor materialEditor, MaterialProperty[] properties)
        {
            materialEditor.PropertiesDefaultGUI(properties);
        }

        public virtual void OnMaterialInteractivePreviewGUI(MaterialEditor materialEditor, Rect r, GUIStyle background)
        {
            materialEditor.DefaultPreviewGUI(r, background);
        }

        public virtual void OnMaterialPreviewGUI(MaterialEditor materialEditor, Rect r, GUIStyle background)
        {
            materialEditor.DefaultPreviewGUI(r, background);
        }

        public virtual void OnMaterialPreviewSettingsGUI(MaterialEditor materialEditor)
        {
            materialEditor.DefaultPreviewSettingsGUI();
        }
    }
}

