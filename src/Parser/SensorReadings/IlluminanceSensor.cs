namespace Parser.SensorReadings
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct IlluminanceSensor : ISensorReading
    {
        [FieldOffset(0)]
        private readonly byte _channel;

        [FieldOffset(1)]
        private readonly byte _type;

        [FieldOffset(2)]
        private readonly ushort _rawLux;

        public byte Channel => this._channel;

        public byte Type => this._type;
        public ushort RawLux => this._rawLux;
    }
}