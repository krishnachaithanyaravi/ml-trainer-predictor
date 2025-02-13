using Microsoft.ML;
using Microsoft.ML.Trainers;
using MLTrainer.TrainingAlgorithms.CustomisableOption;
using System.Collections.Generic;
using Microsoft.ML.Trainers.FastTree;
using MLTrainer.TrainingAlgorithms.OnlineGradientDescentAlgorithm;
using System.Linq;
using MLTrainer.TrainingAlgorithms.LbfgsMaximumEntropyAlgorithm;
using System;

namespace MLTrainer.TrainingAlgorithms.FastTreeAlgorithm
{
    internal class FastTree : IMLTrainingAlgorithm
    {
        private FeatureFractionOption featureFractionOption;
        private FeatureFirstUsePenaltyOption featureFirstUsePenaltyOption;
        private NumberOfTreesOption numberOfTreesOption;
        private NumberOfLeavesOption numberOfLeavesOption;
        private MinimumExampleCountPerLeafOption minimumExampleCountPerLeafOption;
        private MaximumBinCountPerFeatureOption maximumBinCountPerFeatureOption;
        private LearningRateOption learningRateOption;

        public string Name => "Fast Tree";

        /// <inheritdoc />
        public string PredictedValueColumnKeyword => "PredictedLabel";

        /// <inheritdoc />
        public bool IsValidPredictedValueColumnType(Type predictedValueType)
        {
            return predictedValueType == typeof(string);
        }

        internal FastTree()
        {
            featureFractionOption = new FeatureFractionOption(0.8f);
            featureFirstUsePenaltyOption = new FeatureFirstUsePenaltyOption(0.1f);
            numberOfTreesOption = new NumberOfTreesOption(50);
            numberOfLeavesOption = new NumberOfLeavesOption(21);
            minimumExampleCountPerLeafOption = new MinimumExampleCountPerLeafOption(25);
            maximumBinCountPerFeatureOption = new MaximumBinCountPerFeatureOption(262);
            learningRateOption = new LearningRateOption(0.182675767693886f);
        }

        public IEnumerable<ITrainingAlgorithmOption> GetCustomisableOptions()
        {
            yield return featureFractionOption;
            yield return featureFirstUsePenaltyOption;
            yield return numberOfTreesOption;
            yield return numberOfLeavesOption;
            yield return minimumExampleCountPerLeafOption;
            yield return maximumBinCountPerFeatureOption;
            yield return learningRateOption;
        }

        /// <inheritdoc />
        public IEstimator<ITransformer> BuildTrainingAlgorithmPipeline(MLContext mlContext,
                IEnumerable<ColumnNameStorageAttribute> inputDataColumnAttributes,
                IEnumerable<ColumnNameStorageAttribute> outputDataColumnAttributes)
        {
            string labelledInputColumnName = inputDataColumnAttributes.SingleOrDefault(att => att.IsLabel)?.Name;

            MLTrainingPipelineBuilder trainingBuilder = new MLTrainingPipelineBuilder(mlContext, inputDataColumnAttributes, outputDataColumnAttributes);
            string features = MLTrainingPipelineBuilder.FeaturesString;

            var trainerOptions = new FastTreeRegressionTrainer.Options
            {
                NumberOfLeaves = numberOfLeavesOption.Value,
                MinimumExampleCountPerLeaf = minimumExampleCountPerLeafOption.Value,
                NumberOfTrees = numberOfTreesOption.Value,
                FeatureFraction = featureFractionOption.Value,
                MaximumBinCountPerFeature = maximumBinCountPerFeatureOption.Value,
                LearningRate = learningRateOption.Value,
                LabelColumnName = @labelledInputColumnName,
                FeatureColumnName = @features,
            };


            trainingBuilder.SetupOneHotEncodingForStrings();
            trainingBuilder.SetupMissingValuesReplacementForFloats();
            trainingBuilder.SetupFeaturesConcatenation();
            trainingBuilder.SetupTrainingStrategy(mlContext.Regression.Trainers.FastTree(trainerOptions));

            return trainingBuilder.TryCreatePipeline(out IEstimator<ITransformer> pipeline, out string errorMessage) ? pipeline : null;
        }
    }
}
