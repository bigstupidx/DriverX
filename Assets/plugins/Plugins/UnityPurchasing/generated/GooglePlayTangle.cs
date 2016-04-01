#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class GooglePlayTangle
    {
        private static byte[] data = System.Convert.FromBase64String("Yy2FqwP0Ix1m4qB/v6+WELnYJg0mG1ypV3BaX4fd6VYOSbYaxXFomc1hbaZ7kKs/uJGtMuaiEJOqW7xc4VPQ8+Hc19j7V5lXJtzQ0NDU0dKXkGrTNjJXKyKA1aHelEcSmdgkideIoG5b2agLZ+57sAeVo/rdYOKGdSmeuMzJRSqGQzSDS7HNBPSIwAheB9CdHZ8AlGwC1LKrLnIAAqEkgdpgAxyaEZEcfE2VKKmFGpYYBgdh6oIHDb4uCd4zNBvzEJXkM+tltGlJDBPS92uj9l+2Qp02A4E1uBNiK1PQ3tHhU9Db01PQ0NFLc+IPPoKUz6JU86SuVQhBZ0miuv7/ifJWVecBTQXBFBm6DIj9p6H0/t282xm97JOkkBEfiR5TztPS0NHQ");
        private static int[] order = new int[] { 13,4,7,13,12,9,10,8,11,13,13,12,12,13,14 };
        private static int key = 209;

        public static byte[] Data() {
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
