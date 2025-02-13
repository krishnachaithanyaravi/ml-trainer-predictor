using MLTrainer.TrainingAlgorithms.CustomisableOption;

namespace MLTrainer.TrainingAlgorithms.FastTreeAlgorithm
{
    internal class FeatureFirstUsePenaltyOption : TrainingAlgorithmOption<float>
    {
        public override string Name => "FeatureFirstUsePenalty";

        internal FeatureFirstUsePenaltyOption(float initialValue) => value = initialValue;

        public override bool TryGetValueAsString(out string valueAsString)
        {
            valueAsString = value.ToString("R");
            return true;
        }

        public override bool TrySetValue(string newValue)
        {
            if (float.TryParse(newValue, out float validResult))
            {
                value = validResult;
                return true;
            }

            return false;
        }
    }
}
