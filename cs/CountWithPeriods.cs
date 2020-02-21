using System;
using System.Linq;

public class OneGcd
{
    int countInRangeInclusive(long a, long b, int y)
    {
        var mul2 = y%2==0;
        var mul3 = y%3==0;
        var mul5 = y%5==0;
        var mul7 = y%7==0; int notcoprimes = 0;
        for (long i=a;i<=b;i++)
        {
            if (mul2 && i%2 == 0) notcoprimes++;
            else if (mul3 && i%3 == 0) notcoprimes++;
            else if (mul5 && i%5 == 0) notcoprimes++;
            else if (mul7 && i%7 == 0) notcoprimes++;
        }
        return Math.Max(0,(int)(b+1-a-notcoprimes));
    }

    int ycoprimes(long x, int y)
    {
        // Some property repeats in a period on the number line: 
        // For an arbitrary range find including periods, count the occurences in one period and multiply by 
        // the number of periods covering the range, then substract the occurences in the gap 
        // between the start of the covering periods and the actual start (and the end)
        int period = 2*3*5*7;
        var coprimesInPeriod = countInRangeInclusive(1,period,y);
        var fullPeriodsStart = (x / period )*period;
        var fullPeriodEnd  = ((x+y) / period * period)+ period;
        var coveringPeriods = ((int)(fullPeriodEnd-fullPeriodsStart)/period*coprimesInPeriod);
        var startingGap = countInRangeInclusive(fullPeriodsStart, x-1,y);
        var endingGap = countInRangeInclusive(x+y, fullPeriodEnd,y);
        return coveringPeriods-startingGap-endingGap;
    }
    
    public  int[] solve(long[] X, int[] Y)
    {
		    return Enumerable.Range(0, X.Length).Select(i=>ycoprimes(X[i],Y[i])).ToArray();
    }
}
