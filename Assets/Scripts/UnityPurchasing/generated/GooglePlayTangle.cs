// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("wbEes4M2k0WEjS0iIG1uzv3bLq8MNIJIVNrbNrwF9wwXqsOHyBwKgMttY4bLXkizprctFQGXNnP5oA0AlVx3S/Zq6px/Jn7tGPOMjzfeiwz6SMvo+sfMw+BMgkw9x8vLy8/KyV/Hy3/len4SMqMJGjlGh7Lw4dlrBFSh3KI0jBzcRm3nQaUG9/w0n5EODx/xcCFYx2ae3VOlgyWaUc1voLJJjDItMH72t4pHB/warp9zyrwnSMvFyvpIy8DISMvLyntcTNDt368pLlMSV3mf/DKC0t8LhW+otDkub4zi7dhF91KfvGwUiSGkPtMbbwRjIQmBe3cqCmYGH8QalE6RzXtgOw4wbVa15hf0gqBVIdB5gDWNRcftc1TB76H6wHJpOcjJy8rL");
        private static int[] order = new int[] { 2,10,12,11,12,11,8,13,11,10,11,13,13,13,14 };
        private static int key = 202;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
