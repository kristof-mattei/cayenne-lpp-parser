namespace Parser.SensorReadings
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct Accelerometer : ISensorReading
    {
        [FieldOffset(0)]
        private readonly byte _channel;

        [FieldOffset(1)]
        private readonly byte _type;

        [FieldOffset(2)]
        private readonly short _rawX;

        [FieldOffset(4)]
        private readonly short _rawY;

        [FieldOffset(6)]
        private readonly short _rawZ;

        private const decimal Resolution = 0.001m;

        public byte Channel => this._channel;

        public byte Type => this._type;
        public decimal X => this._rawX * Resolution;
        public decimal Y => this._rawY * Resolution;
        public decimal Z => this._rawZ * Resolution;
    }
}