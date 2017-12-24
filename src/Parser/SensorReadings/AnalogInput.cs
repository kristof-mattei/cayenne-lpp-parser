namespace Parser.SensorReadings
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct AnalogInput : ISensorReading
    {
        [FieldOffset(0)]
        private readonly byte _channel;

        [FieldOffset(1)]
        private readonly byte _type;

        [FieldOffset(2)]
        private readonly short _rawValue;

        private const decimal Resolution = .01m;

        public byte Channel => this._channel;

        public byte Type => this._type;
        public decimal Value => this._rawValue * Resolution;
    }
}