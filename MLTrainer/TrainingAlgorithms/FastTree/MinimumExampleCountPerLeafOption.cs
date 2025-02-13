using MLTrainer.TrainingAlgorithms.CustomisableOption;

namespace MLTrainer.TrainingAlgorithms.LbfgsMaximumEntropyAlgorithm
{
    internal class MinimumExampleCountPerLeafOption : TrainingAlgorithmOption<int>
    {
        public override string Name => "MinimumExampleCountPerLeaf";

        internal MinimumExampleCountPerLeafOption(int initialValue) => value = initialValue;

        public override bool TryGetValueAsString(out string valueAsString)
        {
            valueAsString = value.ToString();
            return true;
        }

        public override bool TrySetValue(string newValue)
        {
            if (int.TryParse(newValue, out int validResult))
            {
                value = validResult;
                return true;
            }

            return false;
        }
    }
}
