using UnityEngine;
using System.Collections;

public static class MathUtility
{
    public static Matrix4x4 CreateFromQuaternion(Quaternion q)
    {
        float w = q.w;
        float x = q.x;
        float y = q.y;
        float z = q.z;
        
        Matrix4x4 matrix;
        matrix.m00 = (float)((Mathf.Pow(w, 2f) + Mathf.Pow(x, 2f) - Mathf.Pow(y, 2f) - Mathf.Pow(z, 2f)));
        matrix.m01 = (float)(2 * x * y - 2 * w * z);
        matrix.m02 = (float)(2 * x * z + 2 * w * y);
        matrix.m03 = (float)0;
        matrix.m10 = (float)(2 * x * y + 2 * w * z);
        matrix.m11 = (float)(Mathf.Pow(w, 2f) - Mathf.Pow(x, 2f) + Mathf.Pow(y, 2f) - Mathf.Pow(z, 2f));
        matrix.m12 = (float)(2 * y * z + 2 * w * x);
        matrix.m13 = (float)0;
        matrix.m20 = (float)(2 * x * z - 2 * w * y);
        matrix.m21 = (float)(2 * y * z - 2 * w * x);
        matrix.m22 = (float)(Mathf.Pow(w, 2f) - Mathf.Pow(x, 2f) - Mathf.Pow(y, 2f) + Mathf.Pow(z, 2f));
        matrix.m23 = 0;
        matrix.m30 = 0;
        matrix.m31 = 0;
        matrix.m32 = 0;
        matrix.m33 = 1;
        return matrix;
    }

    public static Quaternion Normalize(this Quaternion quat)
    {
        Quaternion q = quat;

        if (Mathf.Pow(q.w, 2f) + Mathf.Pow(q.x, 2f) + Mathf.Pow(q.y, 2f) + Mathf.Pow(q.z, 2f) != 1f)
        {
            double magnitude = (double)Mathf.Sqrt(Mathf.Pow(q.w, 2f) + Mathf.Pow(q.x, 2f) + Mathf.Pow(q.y, 2f) + Mathf.Pow(q.z, 2f));
            q.w = (float)((double)q.w / magnitude);
            q.x = (float)((double)q.x / magnitude);
            q.y = (float)((double)q.y / magnitude);
            q.z = (float)((double)q.z / magnitude);
        }
        return q;
    }
}
