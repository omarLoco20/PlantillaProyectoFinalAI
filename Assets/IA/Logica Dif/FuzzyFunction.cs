using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class FuzzyFunction 
{
	public AnimationCurve Functioncurves;
	public float F_y;
	public float Singleton;

	public FuzzyFunction()
	{

	}
	public float Evaluate(float x)
	{
		F_y = 0;
		if (x >= Functioncurves.keys[0].time )
			F_y += Mathf.Clamp01(Functioncurves.Evaluate(x));
		return F_y;
	}
}
