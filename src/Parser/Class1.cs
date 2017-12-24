namespace Parser
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using SensorReadings;

    public class SensorReadingParser
    {
        public IReadOnlyCollection<ISensorReading> Parse(string hex)
        {
            byte[] bytes = HexToByte.ConvertToByteArray(hex);

            var list = new List<ISensorReading>();

            for (var i = 0; i < bytes.Length; i++)
            {
                // channel = bytes[0]
                // type = bytes[1]

                var toSkip = 0;
                switch (bytes[i + 1])
                {
                    case 0x01:

                        toSkip = Marshal.SizeOf(typeof(AnalogInput));

                        list.Add(ByteArrayToStructure<AnalogInput>(bytes.Slice(i, toSkip)));

                        break;
                    default:
                        throw new Exception();
                }
            }

            return list;
        }

        private static T ByteArrayToStructure<T>(byte[] bytes)
            where T : struct
        {
            GCHandle handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                return (T) Marshal.PtrToStructure(handle.AddrOfPinnedObject(), typeof(T));
            }
            finally
            {
                handle.Free();
            }
        }
    }

    public static class Extensions
    {
        /// <summary>
        ///     Get the array slice between the two indexes.
        ///     ... Inclusive for start index, exclusive for end index.
        /// </summary>
        public static T[] Slice<T>(this T[] source, int start, int end)
        {
            // Handles negative ends.
            if (end < 0)
            {
                end = source.Length + end;
            }
            int len = end - start;

            // Return new array.
            var res = new T[len];
            for (var i = 0; i < len; i++)
            {
                res[i] = source[i + start];
            }
            return res;
        }
    }
}