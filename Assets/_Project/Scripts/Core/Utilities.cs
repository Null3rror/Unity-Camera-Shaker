using System.Linq;
using UnityEngine;

namespace _Project.Scripts.Core
{
    public static class Utilities
    {
        
        public static Vector3 ElementWiseMultiply(Vector3 a, Vector3 b)
        {
            return new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        }
        
        public static Vector3 RandomPerlinVector3(float t)
        {
            Vector3 v;
            v.x = Mathf.PerlinNoise(t, 0f) - 0.5f;
            v.y = Mathf.PerlinNoise(0f, t) - 0.5f;
            v.z = Mathf.PerlinNoise(t, t) - 0.5f;

            return v;
        }
        
    }
}