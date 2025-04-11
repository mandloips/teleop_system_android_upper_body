using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AndroidManagerScript : MonoBehaviour
{
    public int[] axis = new int[53]; // Array to hold multiple scores
    // Method to update a specific element in the array
    public void SetAxisValue(int axisNumber, int newValue)
    {
        if (axisNumber > 0 && axisNumber <= axis.Length) // Ensure the index is within bounds
        {
            axis[axisNumber-1] = newValue;
            // Debug.Log("Value at axis " + axisNumber + " updated to: " + newValue);
        }
        else
        {
            Debug.LogWarning("axisNumber out of bounds: " + axisNumber);
        }
    }

    public void SetInitialAxisValues()
    {
        if (axis.Length == StaticData.initialAxisValues.Length) // Ensure array lengths match
        {
            for (int i = 0; i < StaticData.initialAxisValues.Length; i++) axis[i] = StaticData.initialAxisValues[i];
            Debug.Log("All values updated.");
        }
        else
        {
            Debug.LogWarning("Array length mismatch with initialAxisValues. Expected length: " + axis.Length);
        }
    }

    public int ConvertToSignalPiecewise(int axisNumber, double xinput)
		{
            List<(int x, int y)> points = StaticData.ita[axisNumber-1];
			var (x1, y1) = points[0];
			var (x2, y2) = points[^1];
            double tcp_value = -1;

			// Check if xInput is not between x1 and x2
			if (x1 <= x2 && (xinput <= x1 || xinput >= x2))
			{
				if (xinput <= x1)
				{
					if ((x1-xinput) <= ((360-x2)+xinput)) tcp_value = y1;
					else tcp_value = y2;
				}
				else
				{
					if ((x1+(360-xinput)) <= (xinput-x2)) tcp_value = y1;
					else tcp_value = y2;
				}
			}
			else if (x1 > x2 && (xinput <= x1 && xinput >= x2))
			{
				if (x1 - xinput <= xinput - x2) tcp_value = y1;
				else tcp_value = y2;
			}


			for (int i = 0; i < points.Count - 1; i++)
			{
				(x1, y1) = points[i];
				(x2, y2) = points[i + 1];

				// Check if xInput is between x1 and x2
				if ( (x1 < x2 && (xinput >= x1 && xinput <= x2)) || (x1 > x2 && (xinput >= x1 || xinput <= x2)) )
				{
					if (x1 < x2 && (xinput >= x1 && xinput <= x2)) tcp_value = y1 + (xinput-x1)*(y2 - y1)/(x2 -x1);
					else if (x1 > x2)
					{
						if (xinput >= x1 && xinput <=360) tcp_value = y1 + (xinput - x1)*(y2 - y1)/(360 + x2 - x1);
						else if (xinput >= 0 && xinput <= x2) tcp_value = y1 + (xinput + 360 - x1)*(y2 - y1)/(x2 + 360 - x1);
					}
				}
			}
            SetAxisValue(axisNumber, (int)tcp_value);
            return (int)tcp_value;
		}
}
