// The binomial coefficient, (n choose k)
template <class T = unsigned long>
T Binomial_Coefficient(unsigned long n, unsigned long k) {
    unsigned long i;
    T b;
    if (0 == k || n == k) {
        return 1;
    }
    if (k > n) {
        return 0;
    }
    if (k > (n - k)) {
        k = n - k;
    }
    if (1 == k) {
        return n;
    }
    b = 1;
    for (i = 1; i <= k; ++i) {
        b *= (n - (k - i));
        // Overflow: 
		if (b < 0) return -1; // when T is unsigned, wraps over to '<T>_MAX'!
        b /= i;
    }
    return b;
}