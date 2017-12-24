namespace Parser.SensorReadings
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct TemperatureSensor : ISensorReading
    {
        [FieldOffset(0)]
        private readonly byte _channel;

        [FieldOffset(1)]
        private readonly byte _type;

        [FieldOffset(2)]
        private readonly short _rawTemperature;

        private const decimal Resolution = .1m;

        public byte Channel => this._channel;

        public byte Type => this._type;
        public decimal Temperature => this._rawTemperature * Resolution;
    }
}