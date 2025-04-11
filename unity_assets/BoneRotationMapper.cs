using UnityEngine;
using System.Collections.Generic;

public class BoneRotationMapper : MonoBehaviour
{
    [Header("Target GameObjects")]
    public List<GameObject> targetObjects = new List<GameObject>();

    private Dictionary<string, Quaternion> boneRotationMap = new Dictionary<string, Quaternion>();

    public AndroidManagerScript androidManager;
    Vector3 finalBoneEuler;

    new void Start()
    {
        androidManager = GameObject.FindGameObjectWithTag("AndroidManager").GetComponent<AndroidManagerScript>();

        // List of GameObject names you want to add
        string[] objectNames = { "Hips", "Spine", "Spine2", "Neck", "Neck1", "Head", "LeftShoulder", "LeftArm", "LeftForeArm", "LeftHand", "LeftHandThumb3", "LeftHandIndex1", "LeftHandMiddle1", "LeftHandRing1", "LeftHandPinky1", "RightShoulder", "RightArm", "RightForeArm", "RightHand", "RightHandThumb3", "RightHandIndex1", "RightHandMiddle1", "RightHandRing1", "RightHandPinky1"  };

        foreach (string name in objectNames)
        {
            // Find the GameObject by name
            GameObject obj = GameObject.Find(name);

            if (obj != null)
            {
                // Add it to the list if found
                targetObjects.Add(obj);
            }
            else
            {
                Debug.LogWarning($"GameObject with name '{name}' not found.");
            }
        }
    }

    void Update()
    {
        UpdateBoneRotations();
        LogAllBoneRotations();

        finalBoneEuler = boneRotationMap["Neck"].eulerAngles;
        // androidManager.ConvertToSignalPiecewise(17, finalBoneEuler.z);
        androidManager.ConvertToSignalPiecewise(18, finalBoneEuler.x);
        androidManager.ConvertToSignalPiecewise(19, finalBoneEuler.y);
        Debug.Log("Head 18: " + finalBoneEuler.x);

        finalBoneEuler = boneRotationMap["Spine2"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(21, finalBoneEuler.z);
        androidManager.ConvertToSignalPiecewise(22, finalBoneEuler.x);
        // androidManager.ConvertToSignalPiecewise(23, finalBoneEuler.y);

        finalBoneEuler = boneRotationMap["LeftArm"].eulerAngles;
        Vector3 finalBoneEulerLa = ConvertYXZToXZX(finalBoneEuler);
        androidManager.ConvertToSignalPiecewise(27, finalBoneEulerLa.x);
        androidManager.ConvertToSignalPiecewise(28, finalBoneEulerLa.y);
        androidManager.ConvertToSignalPiecewise(29, finalBoneEulerLa.z);

        finalBoneEuler = boneRotationMap["LeftForeArm"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(30, finalBoneEuler.y);
        androidManager.ConvertToSignalPiecewise(31, finalBoneEuler.x);

        finalBoneEuler = boneRotationMap["LeftHand"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(32, finalBoneEuler.z);
        androidManager.ConvertToSignalPiecewise(33, finalBoneEuler.y);

        finalBoneEuler = boneRotationMap["LeftHandThumb3"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(34, finalBoneEuler.z);

        finalBoneEuler = boneRotationMap["LeftHandIndex1"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(35, finalBoneEuler.z);

        finalBoneEuler = boneRotationMap["LeftHandMiddle1"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(36, finalBoneEuler.z);

        finalBoneEuler = boneRotationMap["LeftHandRing1"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(37, finalBoneEuler.z);

        finalBoneEuler = boneRotationMap["LeftHandPinky1"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(38, finalBoneEuler.z);

        finalBoneEuler = boneRotationMap["RightArm"].eulerAngles;
        Vector3 finalBoneEulerRa = ConvertYXZToXZX(finalBoneEuler);
        androidManager.ConvertToSignalPiecewise(41, finalBoneEulerRa.x);
        androidManager.ConvertToSignalPiecewise(42, finalBoneEulerRa.y);
        androidManager.ConvertToSignalPiecewise(43, finalBoneEulerRa.z);


        finalBoneEuler = boneRotationMap["RightForeArm"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(44, finalBoneEuler.y);
        androidManager.ConvertToSignalPiecewise(45, finalBoneEuler.x);

        finalBoneEuler = boneRotationMap["RightHand"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(46, finalBoneEuler.z);
        androidManager.ConvertToSignalPiecewise(47, finalBoneEuler.y);

        finalBoneEuler = boneRotationMap["RightHandThumb3"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(48, finalBoneEuler.z);

        finalBoneEuler = boneRotationMap["RightHandIndex1"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(49, finalBoneEuler.z);

        finalBoneEuler = boneRotationMap["RightHandMiddle1"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(50, finalBoneEuler.z);

        finalBoneEuler = boneRotationMap["RightHandRing1"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(51, finalBoneEuler.z);

        finalBoneEuler = boneRotationMap["RightHandPinky1"].eulerAngles;
        androidManager.ConvertToSignalPiecewise(52, finalBoneEuler.z);
    }

    void UpdateBoneRotations()
    {
        boneRotationMap.Clear(); // Refresh the map

        foreach (GameObject obj in targetObjects)
        {
            if (obj != null)
            {
                // Add the bone's name and localRotation to the map
                boneRotationMap[obj.name] = obj.transform.localRotation;
            }
        }
    }

    public Quaternion GetBoneLocalRotation(string boneName)
    {
        if (boneRotationMap.TryGetValue(boneName, out Quaternion rotation))
        {
            return rotation;
        }

        Debug.LogWarning($"Bone with name '{boneName}' not found.");
        return Quaternion.identity; // Default rotation if bone not found
    }

    [ContextMenu("Log All Bone Rotations")]
    public void LogAllBoneRotations()
    {
        foreach (var pair in boneRotationMap)
        {
            // Debug.Log($"Bone: {pair.Key}, Local Rotation: {boneRotationMap["RightHandIndex1"].eulerAngles.z}");
        }
    }

    public static Vector3 RotationMatrixToXZX(float[,] m)
    {
        float[] x1 = new float[3];
        float[] z = new float[3];
        float[] x2 = new float[3];
        for (int i = 0; i < 3; ++i)
            for (int j = 0; j < 3; ++j)
                // Debug.Log("m: " + i + " " + j + " " + m[i, j]);
        x1[0] = Mathf.Atan2(m[2, 0], m[1, 0]) * Mathf.Rad2Deg;
        if (x1[0] >= 0) x1[1] = x1[0];
        else if (x1[0] < 0) x1[1] = 360 + x1[0];
        x1[2] = 180 + x1[0];

        z[0] = Mathf.Acos(m[0, 0]) * Mathf.Rad2Deg;
        if (z[0] >= 0) z[1] = z[0];
        else if (z[0] < 0) z[1] = 360 + z[0];
        z[2] = 360 - z[0];

        x2[0] = Mathf.Atan2(-m[0, 2], m[0,1]) * Mathf.Rad2Deg;
        if (x2[0] >= 0) x2[1] = x2[0];
        else if (x2[0] < 0) x2[1] = 360 + x2[0];
        x2[2] = 180 + x2[0];

        // Debug.Log("m[0, 0]: " + m[0, 0] + " m[0, 1]: " + m[0, 1] + " m[0, 2]: " + m[0, 2]);
        // Debug.Log("m[1, 0]: " + m[1, 0] + " m[1, 1]: " + m[1, 1] + " m[1, 2]: " + m[1, 2]);
        // Debug.Log("m[2, 0]: " + m[2, 0] + " m[2, 1]: " + m[2, 1] + " m[2, 2]: " + m[2, 2]);
        // Debug.Log("x10: " + x1[0] + " z0: " + z[0] + " x20: " + x2[0]);

        Vector3 finalxzx = new Vector3(x1[1], z[1], x2[1]);
        Vector3 xzx = new Vector3(x1[1], z[1], x2[1]);
        float checker = AbsDeterminant3x3(SubtractMatrices(XZXToRotationMatrix(new Vector3(x1[1], z[1], x2[1])),m));

        for (int i = 1; i < 3; ++i)
            for (int j = 1; j < 3; ++j)
                for (int k = 1; k < 3; ++k)
                {
                    xzx = new Vector3(x1[i], z[j], x2[k]);
                    float[,] rm_xzx = XZXToRotationMatrix(xzx);
                    // Debug.Log("xzx: " + xzx + " i: " + i + " j: " + j + " k: " + k);
                    // Debug.Log("xzx test: " + i + " " + j + " " + k + " " + new Vector3(x1[i], z[j], x2[k]));
                    if (rm_xzx[0, 0] * m[0, 0] >= 0 && rm_xzx[0, 1] * m[0, 1] >= 0 && rm_xzx[0, 2] * m[0, 2] >= 0 && rm_xzx[1, 0] * m[1, 0] >= 0 && rm_xzx[1, 1] * m[1, 1] >= 0 && rm_xzx[1, 2] * m[1, 2] >= 0 && rm_xzx[2, 0] * m[2, 0] >= 0 && rm_xzx[2, 1] * m[2, 1] >= 0 && rm_xzx[2, 2] * m[2, 2] >= 0)
                    {
                        // checker = AbsDeterminant3x3(SubtractMatrices(XZXToRotationMatrix(xzx),m));
                        finalxzx = new Vector3(x1[i], z[j], x2[k]);
                    }
                }

        return finalxzx;
    }
    
    public static Vector3 ConvertYXZToXZX(Vector3 yxzEuler)
    {
        float[,] rotationMatrix = YXZToRotationMatrix(yxzEuler);
        // Debug.Log("rotationMatrix: " + rotationMatrix);
        Quaternion q = RotationMatrixToQuaternion(rotationMatrix);
        // Debug.Log("q: " + q);
        Vector3 xzxEulerNew = RotationMatrixToXZX(rotationMatrix);
        // Debug.Log("xzxEulerNew: " + xzxEulerNew);
        Vector3 xzxEuler = QuaternionToXZX(q);
        return xzxEulerNew;
    }

    public static float[,] YXZToRotationMatrix(Vector3 eulerAngles)
    {
        float cosX = Mathf.Cos(eulerAngles.x * Mathf.Deg2Rad);
        float sinX = Mathf.Sin(eulerAngles.x * Mathf.Deg2Rad);
        float cosY = Mathf.Cos(eulerAngles.y * Mathf.Deg2Rad);
        float sinY = Mathf.Sin(eulerAngles.y * Mathf.Deg2Rad);
        float cosZ = Mathf.Cos(eulerAngles.z * Mathf.Deg2Rad);
        float sinZ = Mathf.Sin(eulerAngles.z * Mathf.Deg2Rad);

        float[,] R_Y = {
            { cosY, 0, sinY },
            { 0, 1, 0 },
            { -sinY, 0, cosY }
        };

        float[,] R_X = {
            { 1, 0, 0 },
            { 0, cosX, -sinX },
            { 0, sinX, cosX }
        };

        float[,] R_Z = {
            { cosZ, -sinZ, 0 },
            { sinZ, cosZ, 0 },
            { 0, 0, 1 }
        };

        float[,] R_YXZ = MultiplyMatrices(MultiplyMatrices(R_Y, R_X), R_Z);

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                // Debug.Log("R_YXZ[i, j]: " + R_YXZ[i, j] + " i: " + i + " j: " + j);
            }
        }

        return MultiplyMatrices(MultiplyMatrices(R_Y, R_X), R_Z);
    }

    public static Vector3 QuaternionToXZX(Quaternion q)
    {
        float x1 = Mathf.Atan2(2.0f * (q.w * q.x - q.y * q.z), 1.0f - 2.0f * (q.x * q.x + q.z * q.z)) * Mathf.Rad2Deg;
        float z = Mathf.Acos(2.0f * (q.w * q.z + q.x * q.y)) * Mathf.Rad2Deg;
        float x2 = Mathf.Atan2(2.0f * (q.w * q.x + q.y * q.z), 1.0f - 2.0f * (q.x * q.x + q.y * q.y)) * Mathf.Rad2Deg;

        return new Vector3(x1, z, x2);
    }

    public static float AbsDeterminant3x3(float[,] matrix)
    {
        float det = matrix[0, 0] * (matrix[1, 1] * matrix[2, 2] - matrix[1, 2] * matrix[2, 1])
                - matrix[0, 1] * (matrix[1, 0] * matrix[2, 2] - matrix[1, 2] * matrix[2, 0])
                + matrix[0, 2] * (matrix[1, 0] * matrix[2, 1] - matrix[1, 1] * matrix[2, 0]);

        if (det>=0) return det;
        else return -det;
    }

    public static float[,] SubtractMatrices(float[,] matrix1, float[,] matrix2)
    {
        int rows = matrix1.GetLength(0);
        int cols = matrix1.GetLength(1);

        // Check if matrices are of the same size
        if (rows != 3 || cols != 3 || rows != matrix2.GetLength(0) || cols != matrix2.GetLength(1))
        {
            Debug.LogError("Matrices must be 3x3 for subtraction.");
            return null;
        }

        float[,] result = new float[rows, cols];

        // Perform element-wise subtraction
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                result[i, j] = matrix1[i, j] - matrix2[i, j];
            }
        }

        return result;
    }

    public static float[,] XZXToRotationMatrix(Vector3 eulerAngles)
    {
        float cosX1 = Mathf.Cos(eulerAngles.x * Mathf.Deg2Rad);
        float sinX1 = Mathf.Sin(eulerAngles.x * Mathf.Deg2Rad);
        float cosZ = Mathf.Cos(eulerAngles.y * Mathf.Deg2Rad);
        float sinZ = Mathf.Sin(eulerAngles.y * Mathf.Deg2Rad);
        float cosX2 = Mathf.Cos(eulerAngles.z * Mathf.Deg2Rad);
        float sinX2 = Mathf.Sin(eulerAngles.z * Mathf.Deg2Rad);

        float[,] R_X1 = {
            { 1, 0, 0 },
            { 0, cosX1, -sinX1 },
            { 0, sinX1, cosX1 }
        };

        float[,] R_Z = {
            { cosZ, -sinZ, 0 },
            { sinZ, cosZ, 0 },
            { 0, 0, 1 }
        };

        float[,] R_X2 = {
            { 1, 0, 0 },
            { 0, cosX2, -sinX2 },
            { 0, sinX2, cosX2 }
        };
        

        return MultiplyMatrices(MultiplyMatrices(R_X1, R_Z), R_X2);
    }

    public static Quaternion RotationMatrixToQuaternion(float[,] m)
    {
        float trace = m[0, 0] + m[1, 1] + m[2, 2];
        float w, x, y, z;

        if (trace > 0)
        {
            float s = 0.5f / Mathf.Sqrt(trace + 1.0f);
            w = 0.25f / s;
            x = (m[2, 1] - m[1, 2]) * s;
            y = (m[0, 2] - m[2, 0]) * s;
            z = (m[1, 0] - m[0, 1]) * s;
        }
        else
        {
            if (m[0, 0] > m[1, 1] && m[0, 0] > m[2, 2])
            {
                float s = 2.0f * Mathf.Sqrt(1.0f + m[0, 0] - m[1, 1] - m[2, 2]);
                w = (m[2, 1] - m[1, 2]) / s;
                x = 0.25f * s;
                y = (m[0, 1] + m[1, 0]) / s;
                z = (m[0, 2] + m[2, 0]) / s;
            }
            else if (m[1, 1] > m[2, 2])
            {
                float s = 2.0f * Mathf.Sqrt(1.0f + m[1, 1] - m[0, 0] - m[2, 2]);
                w = (m[0, 2] - m[2, 0]) / s;
                x = (m[0, 1] + m[1, 0]) / s;
                y = 0.25f * s;
                z = (m[1, 2] + m[2, 1]) / s;
            }
            else
            {
                float s = 2.0f * Mathf.Sqrt(1.0f + m[2, 2] - m[0, 0] - m[1, 1]);
                w = (m[1, 0] - m[0, 1]) / s;
                x = (m[0, 2] + m[2, 0]) / s;
                y = (m[1, 2] + m[2, 1]) / s;
                z = 0.25f * s;
            }
        }

        return new Quaternion(x, y, z, w);
    }

    public static float[,] MultiplyMatrices(float[,] A, float[,] B)
    {
        float[,] C = new float[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                C[i, j] = 0;
                for (int k = 0; k < 3; k++)
                {
                    C[i, j] += A[i, k] * B[k, j];
                    
                }
                // Debug.Log("C[i, j]: " + C[i, j] + " i: " + i + " j: " + j);
                // Debug.Log("A[i, j]: " + A[i, j] + " i: " + i + " j: " + j);
                // Debug.Log("B[i, j]: " + B[i, j] + " i: " + i + " j: " + j);
            }
        }
        return C;
    }

    int optimize(double tcp)
    {
        if (tcp<0) return 0;
        if (tcp>255) return 255;
        return (int)tcp;
    }
}
