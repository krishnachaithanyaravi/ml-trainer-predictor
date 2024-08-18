﻿using Microsoft.ML.Data;
using MLTrainerPredictor;

namespace MLTrainerPredictorTests.MicroGasTurbineElectricalEnergyPrediction
{
    public class ElectricalOutput
    {

        /// <summary>
        /// Predicted label
        /// </summary>
        [ColumnName("PredictedLabel")]
        [ColumnNameStorage("PredictedLabel", typeof(string), true)]
        public float Prediction { get; set; }

        /// <summary>
        /// Score
        /// </summary>
        public float[] Score { get; set; }

    }
}
