using MLTrainer.TrainingAlgorithms.CustomisableOption;

namespace MLTrainer.TrainingAlgorithms.FastTreeAlgorithm
{
    internal class LearningRateOption : TrainingAlgorithmOption<double>
    {
        public override string Name => "LearningRate";

        internal LearningRateOption(double initialValue) => value = initialValue;

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
