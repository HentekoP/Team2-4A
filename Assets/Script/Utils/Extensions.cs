// �F��\���ʒu�����߂Ă�����
// �����͊ۃp�N�����Ȃ��Ƃ����Ȃ�����
// Fracture�n��͑S���������炢���ȃf�[�^���Q�Ƃ��Ă���

using System;
using System.Collections.Generic;   // ISet �� HashSet ����`����Ă���
using System.Linq;  // ForEach, Select, Where���g���Ȃ�K�{
using UnityEngine;

namespace Project.Scripts.Utils
{
    public static class Extensions
    {
        public static Color SetAlpha(this Color color, float value) // ChunkNode.cs �Ŏg���Ă���
        {
            return new Color(color.r, color.g, color.b, value);
        }

        public static ISet<T> ToSet<T>(this IEnumerable<T> iEnumerable) // ChunkGraphManager.cs �Ŏg���Ă���
        {
            return new HashSet<T>(iEnumerable);
        }

        public static T GetOrAddComponent<T>(this Component c) where T : Component  // ChunkGraphManager.cs �� ChunkNode.cs �Ŏg���Ă���
        {
            return c.gameObject.GetOrAddComponent<T>();
        }

        public static Component GetOrAddComponent(this GameObject go, Type componentType)   // GetOrAddComponent<T>(this GameObject go) where T : Component �Ŏg���Ă���
        {
            var result = go.GetComponent(componentType);
            return result == null ? go.AddComponent(componentType) : result;
        }

        public static T GetOrAddComponent<T>(this GameObject go) where T : Component    // GetOrAddComponent<T>(this Component c) where T : Component �Ŏg���Ă���
        {
            return GetOrAddComponent(go, typeof(T)) as T;
        }

        public static Vector3 SetX(this Vector3 vector3, float x)   // Fracture.cs �Ŏg���Ă���
        {
            return new Vector3(x, vector3.y, vector3.z);
        }

        public static Vector3 SetY(this Vector3 vector3, float y)   // Fracture.cs �Ŏg���Ă���
        {
            return new Vector3(vector3.x, y, vector3.z);
        }

        public static Vector3 SetZ(this Vector3 vector3, float z)   // Fracture.cs �Ŏg���Ă���
        {
            return new Vector3(vector3.x, vector3.y, z);
        }

        public static Vector3 Multiply(this Vector3 vectorA, Vector3 vectorB)   // Fracture.cs �Ŏg���Ă���
        {
            return Vector3.Scale(vectorA, vectorB);
        }

        public static Vector3 Abs(this Vector3 vector)  // Fracture.cs �Ŏg���Ă���
        {
            var x = Mathf.Abs(vector.x);
            var y = Mathf.Abs(vector.y);
            var z = Mathf.Abs(vector.z);
            return new Vector3(x, y, z);
        }
        
        private static float SignedVolumeOfTriangle(Vector3 p1, Vector3 p2, Vector3 p3) // Volume(this Mesh mesh) �Ŏg���Ă���
        {
            float v321 = p3.x * p2.y * p1.z;
            float v231 = p2.x * p3.y * p1.z;
            float v312 = p3.x * p1.y * p2.z;
            float v132 = p1.x * p3.y * p2.z;
            float v213 = p2.x * p1.y * p3.z;
            float v123 = p1.x * p2.y * p3.z;
            return (1.0f / 6.0f) * (-v321 + v231 + v312 - v132 - v213 + v123);
        }

        public static float Volume(this Mesh mesh)  // Fracture.cs �Ŏg���Ă���
        {
            float volume = 0;
            Vector3[] vertices = mesh.vertices;
            int[] triangles = mesh.triangles;
            for (int i = 0; i < triangles.Length; i += 3)
            {
                var p1 = vertices[triangles[i + 0]];
                var p2 = vertices[triangles[i + 1]];
                var p3 = vertices[triangles[i + 2]];
                volume += SignedVolumeOfTriangle(p1, p2, p3);
            }
            return Mathf.Abs(volume);
        }
        
        public static Vector3[] GetVertices(this Bounds bounds) => new[]    // TransformBounds(this Transform from, Transform to, Bounds bounds) �Ŏg���Ă���
        {
            new Vector3(bounds.center.x, bounds.center.y, bounds.center.z) + new Vector3(-bounds.extents.x, -bounds.extents.y, -bounds.extents.z),
            new Vector3(bounds.center.x, bounds.center.y, bounds.center.z) + new Vector3(bounds.extents.x, -bounds.extents.y, -bounds.extents.z),
            new Vector3(bounds.center.x, bounds.center.y, bounds.center.z) + new Vector3(-bounds.extents.x, -bounds.extents.y, bounds.extents.z),
            new Vector3(bounds.center.x, bounds.center.y, bounds.center.z) + new Vector3(bounds.extents.x, -bounds.extents.y, bounds.extents.z),
            new Vector3(bounds.center.x, bounds.center.y, bounds.center.z) + new Vector3(-bounds.extents.x, bounds.extents.y, -bounds.extents.z),
            new Vector3(bounds.center.x, bounds.center.y, bounds.center.z) + new Vector3(bounds.extents.x, bounds.extents.y, -bounds.extents.z),
            new Vector3(bounds.center.x, bounds.center.y, bounds.center.z) + new Vector3(-bounds.extents.x, bounds.extents.y, bounds.extents.z),
            new Vector3(bounds.center.x, bounds.center.y, bounds.center.z) + new Vector3(bounds.extents.x, bounds.extents.y, bounds.extents.z),
        };
        
        public static Vector3 Min(this Vector3 vectorA, Vector3 vectorB)    // ToBounds(this Vector3[] vertices) �Ŏg���Ă���
        {
            return Vector3.Min(vectorA, vectorB);
        }

        public static Vector3 Max(this Vector3 vectorA, Vector3 vectorB)    // ToBounds(this Vector3[] vertices) �Ŏg���Ă���
        {
            return Vector3.Max(vectorA, vectorB);
        }
        
        public static Bounds ToBounds(this Vector3[] vertices)  // ToBounds(this IEnumerable<Vector3> vertices) �Ŏg���Ă���
        {
            var min = Vector3.one * float.MaxValue;
            var max = Vector3.one * float.MinValue;

            for (int i = 0; i < vertices.Length; i++)
            {
                min = vertices[i].Min(min);
                max = vertices[i].Max(max);
            }

            return new Bounds((max - min) / 2 + min, max - min);
        }

        public static Bounds ToBounds(this IEnumerable<Vector3> vertices)   // TransformBounds(this Transform from, Transform to, Bounds bounds) �Ŏg���Ă���
        {
            return vertices.ToArray().ToBounds();
        }
        
        public static Vector3 TransformPoint(this Transform t, Vector3 position, Transform dest)    // TransformBounds(this Transform from, Transform to, Bounds bounds) �Ŏg���Ă���
        {
            var world = t.TransformPoint(position);
            return dest.InverseTransformPoint(world);
        }
        
        public static Bounds TransformBounds(this Transform from, Transform to, Bounds bounds)  // GetCompositeMeshBounds(this GameObject go, bool includeInactive = false, bool isSharedMesh = false) �Ŏg���Ă���
        {
            return bounds.GetVertices()
                .Select(bv => from.transform.TransformPoint(bv, to.transform))
                .ToBounds();
        }
        
        public static Bounds GetCompositeMeshBounds(this GameObject go, bool includeInactive = false, bool isSharedMesh = false)    // Fracture.cs �Ŏg���Ă���
        {
            var bounds = go.GetComponentsInChildren<MeshFilter>(includeInactive)
                .Select(mf =>
                {
                    var mesh = isSharedMesh ? mf.sharedMesh : mf.mesh;
                    var localBound = mf.transform.TransformBounds(go.transform, mesh.bounds);
                    return localBound;
                })
                .Where(b => b.size != Vector3.zero)
                .ToArray();

            if (bounds.Length == 0)
                return new Bounds();

            if (bounds.Length == 1)
                return bounds[0];

            var compositeBounds = bounds[0];

            for (var i = 1; i < bounds.Length; i++)
            {
                compositeBounds.Encapsulate(bounds[i]);
            }

            return compositeBounds;
        }
    }
}