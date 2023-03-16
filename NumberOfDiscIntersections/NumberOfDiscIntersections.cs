static int solution(int[] A)
{
	int N = A.Length;
	var startX = new int[N];
	var endX = new int[N];

	for (int i = 0; i < N; i++)
	{
		startX[Math.Max(0, i - (long)A[i])] += 1;
		endX[Math.Min(N - 1, i + (long)A[i])] += 1;
	}

	int intersections = 0;
	int active = 0;

	for (int i = 0; i < N; i++)
	{
		if (startX[i] > 0)
		{
			intersections += active * startX[i];
			intersections += startX[i] * (startX[i] - 1) / 2;
			if (intersections > 10000000)
			{
				return -1;
			}
			active += startX[i];
		}
		active -= endX[i];
	}

	return intersections;
}