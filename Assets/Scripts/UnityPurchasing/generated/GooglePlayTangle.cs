// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("uJAY4u6zk/+fhl2DDdcIVOL5opcVe3RB3G7LBiX1jRC4PadKgvad+qn0zyx/jm0bOcy4SeAZrBTcXnTqxl5S5nzj54urOpCDoN8eK2l4QPKVrRvRzUNCryWcbpWOM1oeUYWTGVgohyoarwrcHRS0u7n091dkQrc2l5aGaOm4wV7/B0TKPBq8A8hU9jkr0BWrtKnnby4T3p5lgzcG6lMlvmPRUnFjXlVaedUb1aReUlJSVlNQDMXu0m/zcwXmv+d0gWoVFq5HEpWwt8qLzuAGZasbS0aSHPYxLaC39tFSXFNj0VJZUdFSUlPixdVJdEY2nc04RTutFYVF3/R+2DyfbmWtBghS9PofUsfRKj8utIyYDq/qYDmUmc1YdjhjWevwoFFQUlNS");
        private static int[] order = new int[] { 9,7,4,3,10,10,13,10,9,11,13,13,13,13,14 };
        private static int key = 83;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
