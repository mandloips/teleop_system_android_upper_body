using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    public const int MaxScore = 23;         // Constant integer
    public static readonly int[] Levels = { 1, 2, 3, 4, 5 }; // Read-only array

    // Read-only properties
    public static int Health => 50;
    public static string GameName => "My Awesome Game";
    // Initial axis values for the android
    public static int a1 = 80;
    public static int a2 = 80;
    public static int a3 = 128;
    public static int a4 = 128;
    public static int a5 = 180;
    public static int a6 = 0;
    public static int a7 = 0;
    public static int a8 = 0;
    public static int a9 = 0;
    public static int a10 = 0;
    public static int a11 = 0;
    public static int a12 = 0;
    public static int a13 = 0;
    public static int a14 = 0;
    public static int a15 = 0;
    public static int a16 = 30;
    public static int a17 = 128;
    public static int a18 = 110;
    public static int a19 = 128;
    public static int a20 = 0;
    public static int a21 = 128;
    public static int a22 = 130;
    public static int a23 = 128;
    public static int a24 = 0;
    public static int a25 = 32;
    public static int a26 = 32;
    public static int a27 = 128;
    public static int a28 = 128;
    public static int a29 = 120;
    public static int a30 = 120;
    public static int a31 = 180;
    public static int a32 = 128;
    public static int a33 = 128;
    public static int a34 = 0;
    public static int a35 = 0;
    public static int a36 = 0;
    public static int a37 = 0;
    public static int a38 = 0;
    public static int a39 = 32;
    public static int a40 = 32;
    public static int a41 = 128;
    public static int a42 = 128;
    public static int a43 = 120;
    public static int a44 = 120;
    public static int a45 = 180;
    public static int a46 = 128;
    public static int a47 = 128;
    public static int a48 = 0;
    public static int a49 = 0;
    public static int a50 = 0;
    public static int a51 = 0;
    public static int a52 = 0;
    public static int a53 = 128;
    public static int[] initialAxisValues = { a1, a2, a3, a4, a5, a6, a7, a8, a9, a10, a11, a12, a13, a14, a15, a16, a17, a18, a19, a20, a21, a22, a23, a24, a25, a26, a27, a28, a29, a30, a31, a32, a33, a34, a35, a36, a37, a38, a39, a40, a41, a42, a43, a44, a45, a46, a47, a48, a49, a50, a51, a52, a53 };
    
    // terminals for making piecewise linear functions of each axis
    public static List<(int x, int y)> ita1 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita2 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita3 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita4 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita5 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita6 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita7 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita8 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita9 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita10 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita11 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita12 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita13 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita14 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita15 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita16 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita17 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita18 = new List<(int x, int y)>
        {
            (350, 255),
            (20, 0)
        };
    public static List<(int x, int y)> ita19 = new List<(int x, int y)>
        {
            (330, 255),
            (30, 0)
        };
    public static List<(int x, int y)> ita20 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita21 = new List<(int x, int y)>
        {
            (355, 0), 
            (5, 255)
        };
    public static List<(int x, int y)> ita22 = new List<(int x, int y)>
        {
            (20, 180),
            (30, 130),
            (60, 0)
        };
    public static List<(int x, int y)> ita23 = new List<(int x, int y)>
        {
            (350, 255), 
            (0, 128), 
            (10, 0)
        };
    public static List<(int x, int y)> ita24 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita25 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita26 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita27 = new List<(int x, int y)>
        {
            (51, 255), 
            (90, 200), 
            (170, 90), 
            (199, 0)
        };
    public static List<(int x, int y)> ita28 = new List<(int x, int y)>
        {
            (260, 0),
            (280, 45),
            (316, 255)
        };
    public static List<(int x, int y)> ita29 = new List<(int x, int y)>
        {
            (170, 0),
            (200, 50),
            (250, 255)
        };
    public static List<(int x, int y)> ita30 = new List<(int x, int y)>
        {
            (355, 0),
            (0, 0),
            (90, 150),
            (140, 255)
        };
    public static List<(int x, int y)> ita31 = new List<(int x, int y)>
        {
            (330, 0), 
            (30, 255)
        };
    public static List<(int x, int y)> ita32 = new List<(int x, int y)>
        {
            (336, 255), 
            (26, 0)
        };
    public static List<(int x, int y)> ita33 = new List<(int x, int y)>
        {
            (332, 255), 
            (28, 0)
        };
    public static List<(int x, int y)> ita34 = new List<(int x, int y)>
        {
            (0, 0), 
            (45, 255)
        };
    public static List<(int x, int y)> ita35 = new List<(int x, int y)>
        {
            (0, 0), 
            (89, 255)
        };
    public static List<(int x, int y)> ita36 = new List<(int x, int y)>
        {
            (0, 0), 
            (89, 255)
        };
    public static List<(int x, int y)> ita37 = new List<(int x, int y)>
        {
            (0, 0), 
            (89, 255)
        };
    public static List<(int x, int y)> ita38 = new List<(int x, int y)>
        {
            (0, 0), 
            (89, 255)
        };
    public static List<(int x, int y)> ita39 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita40 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)> ita41 = new List<(int x, int y)>
        {
            (231, 255), 
            (260, 220), 
            (350, 50), 
            (19, 0)
        };
    public static List<(int x, int y)> ita42 = new List<(int x, int y)>
        {
            (260, 0),
            (280, 70),
            (316, 255)
        };
    public static List<(int x, int y)> ita43 = new List<(int x, int y)>
        {
            (20, 0),
            (40, 70),
            (45, 100),
            (70, 255)
        };
    public static List<(int x, int y)> ita44 = new List<(int x, int y)>
        {
            (210, 255),
            (270, 150),
            (0, 0),
            (5, 0)
        };
    public static List<(int x, int y)> ita45 = new List<(int x, int y)>
        {
            (330, 0), 
            (30, 255)
        };
    public static List<(int x, int y)> ita46 = new List<(int x, int y)>
        {
            (334, 0), 
            (24, 255)
        };
    public static List<(int x, int y)> ita47 = new List<(int x, int y)>
        {
            (332, 0), 
            (28, 255)
        };
    public static List<(int x, int y)> ita48 = new List<(int x, int y)>
        {
            (315, 255), 
            (0, 0)
        };
    public static List<(int x, int y)> ita49 = new List<(int x, int y)>
        {
            (271, 255), 
            (0, 0)
        };
    public static List<(int x, int y)> ita50 = new List<(int x, int y)>
        {
            (271, 255), 
            (0, 0)
        };
    public static List<(int x, int y)> ita51 = new List<(int x, int y)>
        {
            (271, 255), 
            (0, 0)
        };
    public static List<(int x, int y)> ita52 = new List<(int x, int y)>
        {
            (271, 255), 
            (0, 0)
        };
    public static List<(int x, int y)> ita53 = new List<(int x, int y)>
        {
            (1, 2),
            (4, 8)
        };
    public static List<(int x, int y)>[] ita = { ita1, ita2, ita3, ita4, ita5, ita6, ita7, ita8, ita9, ita10, ita11, ita12, ita13, ita14, ita15, ita16, ita17, ita18, ita19, ita20, ita21, ita22, ita23, ita24, ita25, ita26, ita27, ita28, ita29, ita30, ita31, ita32, ita33, ita34, ita35, ita36, ita37, ita38, ita39, ita40, ita41, ita42, ita43, ita44, ita45, ita46, ita47, ita48, ita49, ita50, ita51, ita52, ita53 };

    // Static method (optional) to provide any additional data processing
    public static int GetLevelCount()
    {
        return Levels.Length;
    }
}
