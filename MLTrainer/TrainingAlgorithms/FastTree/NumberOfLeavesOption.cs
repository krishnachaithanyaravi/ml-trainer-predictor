using MLTrainer.TrainingAlgorithms.CustomisableOption;

namespace MLTrainer.TrainingAlgorithms.LbfgsMaximumEntropyAlgorithm
{
    internal class NumberOfLeavesOption : TrainingAlgorithmOption<int>
    {
        public override string Name => "NumberOfLeaves";

        internal NumberOfLeavesOption(int initialValue) => value = initialValue;

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
