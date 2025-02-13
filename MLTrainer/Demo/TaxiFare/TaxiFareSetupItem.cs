using MLTrainer.CompileTimeTrainingSetup.DataSetup;
using MLTrainer.TrainingAlgorithms;
using MLTrainerTests.MicroGasTurbineElectricalEnergyPrediction;
using System;

namespace MLTrainerTests.TaxiFare
{
    internal class TaxiFareSetupItem : ConcreteObjectMLSetupItem<TaxiFareInput, TaxiFareOutput>
    {
        public TaxiFareSetupItem() : base("TaxiFareTrainingModel")
        {
        }

        public override string Name => "TaxiFare Setup";

        public override string TrainingModelDirectory { get; set; } = "C:\\Temp";

        public override string TrainingModelName { get; set; } = string.Empty;

        protected override bool TryConvertToCSVString(TaxiFareInput input, out string csvRow)
        {
            csvRow = input.VendorId.ToString() + SEPARATOR +
                   input.RateCode.ToString() + SEPARATOR +
                   input.PassengerCount.ToString() + SEPARATOR+
                   input.TripTime.ToString() + SEPARATOR+
                   input.TripDistance.ToString() + SEPARATOR+
                   input.PaymentType.ToString() + SEPARATOR+
                   input.FareAmount.ToString() + SEPARATOR;
            return !string.IsNullOrEmpty(csvRow);
        }

        protected override bool TryParse(string csvRow, out TaxiFareInput validModelInput)
        {
            validModelInput = new TaxiFareInput();
            string[] items = csvRow.Split(new[] { SEPARATOR }, StringSplitOptions.None);
            if (items.Length != 7)
            {
                return false;
            }

            try
            {
                validModelInput.VendorId = items[0];

                if (!float.TryParse(items[1], out float rateCode))
                {
                    return false;
                }
                validModelInput.RateCode = rateCode;

                if (!float.TryParse(items[2], out float passCount))
                {
                    return false;
                }
                validModelInput.PassengerCount = passCount;

                if (!float.TryParse(items[3], out float tripTimeInSecs))
                {
                    return false;
                }
                validModelInput.TripTime = tripTimeInSecs;

                if (!float.TryParse(items[4], out float tripdis))
                {
                    return false;
                }
                validModelInput.TripDistance = tripdis;

                validModelInput.PaymentType = items[5];

                if (!float.TryParse(items[6], out float fare))
                {
                    return false;
                }
                validModelInput.FareAmount = fare;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
