namespace Parser.SensorReadings
{
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit)]
    public struct GpsLocation : ISensorReading
    {
        [FieldOffset(0)]
        private readonly byte _channel;

        [FieldOffset(1)]
        private readonly byte _type;

        [FieldOffset(2)]
        private readonly short _rawLatitude;

        [FieldOffset(4)]
        private readonly short _rawLongitude;

        [FieldOffset(6)]
        private readonly short _rawAltitude;

        private const decimal ResolutionLatitudeAndLongitude = 0.0001m;
        private const decimal ResolutionAltitude = 0.01m;

        public byte Channel => this._channel;

        public byte Type => this._type;
        public decimal Latitude => this._rawLatitude * ResolutionLatitudeAndLongitude;
        public decimal Longitude => this._rawLongitude * ResolutionLatitudeAndLongitude;
        public decimal Altitude => this._rawAltitude * ResolutionAltitude;
    }
}