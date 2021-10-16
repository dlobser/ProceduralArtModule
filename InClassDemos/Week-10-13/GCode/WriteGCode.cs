using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

namespace Art
{
    public static class WriteGCode : object
    {

        public static string Write(Vector3[] linePositions)
        {
            string header = "M82 ;absolute extrusion mode\n; Ender 3 Custom Start G-code\nG92 E0 ; Reset Extruder\nG28 ; Home all axes\nM107 ; Fan off\nG0 F0 X0 Y0\n";
            string positions = "";

            for (int i = 0; i < linePositions.Length; i++)
            {
                positions +=
                    "G0 X" +
                    linePositions[i].x
                    + " Y" +		  
                    linePositions[i].y
                    + " Z" +		  
                    linePositions[i].z
                    + "\n";
                }

            header += positions;

            string date = System.DateTime.Now.ToString("yyyy_dd_HH_mm_ss");
            string path = "Assets/Drawing_" + date + ".gcode";
            File.AppendAllText(path, header);
            return header;
        }

        public static string Write(Vector3[] linePositions, Vector3 minInputSize, Vector3 maxInputSize, Vector3 minOutputSize, Vector3 maxOutputSize)
        {
            string header = "M82 ;absolute extrusion mode\n; Ender 3 Custom Start G-code\nG92 E0 ; Reset Extruder\nG28 ; Home all axes\nM107 ; Fan off\nG0 F0 X0 Y0\n";
            string positions = "";

            for (int i = 0; i < linePositions.Length; i++)
            {
                positions +=
                    "G0 X" +
                    map(linePositions[i].x, minInputSize.x, maxInputSize.x, minOutputSize.x, maxOutputSize.x)
                    + " Y" +
                    map(linePositions[i].y, minInputSize.y, maxInputSize.y, minOutputSize.y, maxOutputSize.y)
                    + " Z" +
                    map(linePositions[i].z, minInputSize.z, maxInputSize.z, minOutputSize.z, maxOutputSize.z)
                    + "\n";
            }

            header += positions;

            string date = System.DateTime.Now.ToString("yyyy_dd_HH_mm_ss");
            string path = "Assets/Drawing_" + date + ".gcode";
            File.AppendAllText(path, header);
            return header;
        }

        public static float map(float s, float a1, float a2, float b1, float b2)
        {
            return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
        }
    }
}