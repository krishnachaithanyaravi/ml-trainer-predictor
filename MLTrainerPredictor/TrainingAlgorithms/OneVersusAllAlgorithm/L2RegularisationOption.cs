﻿using MLTrainerPredictor.TrainingAlgorithms.CustomisableOption;

namespace MLTrainerPredictor.TrainingAlgorithms.OneVersusAllAlgorithm
{
    internal class L2RegularisationOption : TrainingAlgorithmOption<float>
    {
        public override string Name => "L2 Regularisation option";

        internal L2RegularisationOption(float initialValue) => value = initialValue;

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
