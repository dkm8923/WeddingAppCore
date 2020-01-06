using System.Collections.Generic;
using System.Linq;

namespace CleanArchitecture.WebUI.Common
{
    public static class Extensions
    {
        public static List<short> ConvertToInt16(this List<string> stringList)
        {
            short x = 0;
            var ret = stringList.Where(str => short.TryParse(str, out x)).Select(str => x).ToList();
            return ret;
        }
        public static List<int> ConvertToInt32(this List<string> stringList)
        {
            int x = 0;
            var ret = stringList.Where(str => int.TryParse(str, out x)).Select(str => x).ToList();
            return ret;
        }

        public static List<long> ConvertToInt64(this List<string> stringList)
        {
            long x = 0;
            var ret = stringList.Where(str => long.TryParse(str, out x)).Select(str => x).ToList();
            return ret;
        }

        public static List<ushort> ConvertToUInt16(this List<string> stringList)
        {
            ushort x = 0;
            var ret = stringList.Where(str => ushort.TryParse(str, out x)).Select(str => x).ToList();
            return ret;
        }
        public static List<uint> ConvertToUInt32(this List<string> stringList)
        {
            uint x = 0;
            var ret = stringList.Where(str => uint.TryParse(str, out x)).Select(str => x).ToList();
            return ret;
        }

        public static List<ulong> ConvertToUInt64(this List<string> stringList)
        {
            ulong x = 0;
            var ret = stringList.Where(str => ulong.TryParse(str, out x)).Select(str => x).ToList();
            return ret;
        }

        public static List<byte> ConvertToByte(this List<string> stringList)
        {
            byte x = 0;
            var ret = stringList.Where(str => byte.TryParse(str, out x)).Select(str => x).ToList();
            return ret;
        }

        public static List<double> ConvertToDouble(this List<string> stringList)
        {
            double x = 0;
            var ret = stringList.Where(str => double.TryParse(str, out x)).Select(str => x).ToList();
            return ret;
        }

        public static List<decimal> ConvertToDecimal(this List<string> stringList)
        {
            decimal x = 0;
            var ret = stringList.Where(str => decimal.TryParse(str, out x)).Select(str => x).ToList();
            return ret;
        }

        public static List<float> ConvertToFloat(this List<string> stringList)
        {
            float x = 0;
            var ret = stringList.Where(str => float.TryParse(str, out x)).Select(str => x).ToList();
            return ret;
        }
    }
}
