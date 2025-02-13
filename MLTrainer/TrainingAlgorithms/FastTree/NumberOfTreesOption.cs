using MLTrainer.TrainingAlgorithms.CustomisableOption;

namespace MLTrainer.TrainingAlgorithms.FastTreeAlgorithm
{
    internal class NumberOfTreesOption : TrainingAlgorithmOption<int>
    {
        public override string Name => "NumberOfTrees";

        internal NumberOfTreesOption(int initialValue) => value = initialValue;

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
