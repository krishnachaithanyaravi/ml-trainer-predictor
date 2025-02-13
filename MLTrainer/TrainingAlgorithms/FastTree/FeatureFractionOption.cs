using MLTrainer.TrainingAlgorithms.CustomisableOption;

namespace MLTrainer.TrainingAlgorithms.FastTreeAlgorithm
{
    internal class FeatureFractionOption : TrainingAlgorithmOption<double>
    {
        public override string Name => "FeatureFraction";

        internal FeatureFractionOption(double initialValue) => value = initialValue;

        public override bool TryGetValueAsString(out string valueAsString)
        {
            valueAsString = value.ToString();
            return true;
        }

        public override bool TrySetValue(string newValue)
        {
            if (double.TryParse(newValue, out double validResult))
            {
                value = validResult;
                return true;
            }

            return false;
        }
    }
}
