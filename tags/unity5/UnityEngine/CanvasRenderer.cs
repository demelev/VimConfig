﻿namespace UnityEngine
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    public sealed class CanvasRenderer : Component
    {
        public static  event OnRequestRebuild onRequestRebuild;

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public extern void Clear();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public extern void DisableRectClipping();
        public void EnableRectClipping(Rect rect)
        {
            INTERNAL_CALL_EnableRectClipping(this, ref rect);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public extern float GetAlpha();
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public extern Color GetColor();
        public Material GetMaterial()
        {
            return this.GetMaterial(0);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public extern Material GetMaterial(int index);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public extern Material GetPopMaterial(int index);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void INTERNAL_CALL_EnableRectClipping(CanvasRenderer self, ref Rect rect);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        private static extern void INTERNAL_CALL_SetColor(CanvasRenderer self, ref Color color);
        private static void RequestRefresh()
        {
            if (onRequestRebuild != null)
            {
                onRequestRebuild();
            }
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public extern void SetAlpha(float alpha);
        public void SetColor(Color color)
        {
            INTERNAL_CALL_SetColor(this, ref color);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public extern void SetMaterial(Material material, int index);
        public void SetMaterial(Material material, Texture texture)
        {
            this.materialCount = Math.Max(1, this.materialCount);
            this.SetMaterial(material, 0);
            this.SetTexture(texture);
        }

        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public extern void SetMesh(Mesh mesh);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public extern void SetPopMaterial(Material material, int index);
        [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall]
        public extern void SetTexture(Texture texture);
        [Obsolete("UI System now uses meshes. Generate a mesh and use 'SetMesh' instead")]
        public void SetVertices(List<UIVertex> vertices)
        {
            this.SetVertices(vertices.ToArray(), vertices.Count);
        }

        [Obsolete("UI System now uses meshes. Generate a mesh and use 'SetMesh' instead")]
        public void SetVertices(UIVertex[] vertices, int size)
        {
            Mesh mesh = new Mesh();
            List<Vector3> inVertices = new List<Vector3>();
            List<Color32> inColors = new List<Color32>();
            List<Vector2> uvs = new List<Vector2>();
            List<Vector2> list4 = new List<Vector2>();
            List<Vector3> inNormals = new List<Vector3>();
            List<Vector4> inTangents = new List<Vector4>();
            List<int> list7 = new List<int>();
            for (int i = 0; i < size; i += 4)
            {
                for (int j = 0; j < 4; j++)
                {
                    inVertices.Add(vertices[i + j].position);
                    inColors.Add(vertices[i + j].color);
                    uvs.Add(vertices[i + j].uv0);
                    list4.Add(vertices[i + j].uv1);
                    inNormals.Add(vertices[i + j].normal);
                    inTangents.Add(vertices[i + j].tangent);
                }
                list7.Add(i);
                list7.Add(i + 1);
                list7.Add(i + 2);
                list7.Add(i + 2);
                list7.Add(i + 3);
                list7.Add(i);
            }
            mesh.SetVertices(inVertices);
            mesh.SetColors(inColors);
            mesh.SetNormals(inNormals);
            mesh.SetTangents(inTangents);
            mesh.SetUVs(0, uvs);
            mesh.SetUVs(1, list4);
            mesh.SetIndices(list7.ToArray(), MeshTopology.Triangles, 0);
            this.SetMesh(mesh);
            UnityEngine.Object.DestroyImmediate(mesh);
        }

        public int absoluteDepth { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; }

        public bool cull { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public bool hasMoved { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; }

        public bool hasPopInstruction { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public bool hasRectClipping { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; }

        [Obsolete("isMask is no longer supported. See EnableClipping for vertex clipping configuration")]
        public bool isMask { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public int materialCount { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public int popMaterialCount { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] set; }

        public int relativeDepth { [MethodImpl(MethodImplOptions.InternalCall), WrapperlessIcall] get; }

        public delegate void OnRequestRebuild();
    }
}

