using Microsoft.ML.Data;
using MLTrainer;

namespace MLTrainerTests.TaxiFare
{
    public class TaxiFareInput
    {
        [ColumnName("vendor_id")]
        [ColumnNameStorage("vendor_id", typeof(string))]
        public string VendorId { get; set; }

        [ColumnName("rate_code")]
        [ColumnNameStorage("rate_code", typeof(float))]
        public float RateCode { get; set; }

        [ColumnName("passenger_count")]
        [ColumnNameStorage("passenger_count", typeof(float))]
        public float PassengerCount { get; set; }

        [ColumnName("trip_time_in_secs")]
        [ColumnNameStorage("trip_time_in_secs", typeof(float))]
        public float TripTime { get; set; }

        [ColumnName("trip_distance")]
        [ColumnNameStorage("trip_distance", typeof(float))]
        public float TripDistance { get; set; }

        [ColumnName("payment_type")]
        [ColumnNameStorage("payment_type", typeof(string))]
        public string PaymentType { get; set; }

        [ColumnName("fare_amount")]
        [ColumnNameStorage("fare_amount", typeof(float), true)]
        public float FareAmount { get; set; }

    }
}
