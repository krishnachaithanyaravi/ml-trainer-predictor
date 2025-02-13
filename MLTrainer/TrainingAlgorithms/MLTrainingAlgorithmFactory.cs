using MLTrainer.TrainingAlgorithms.LbfgsMaximumEntropyAlgorithm;
using MLTrainer.TrainingAlgorithms.LbfgsPoissonAlgorithm;
using MLTrainer.TrainingAlgorithms.LightGbmAlgorithm;
using MLTrainer.TrainingAlgorithms.OneVersusAllAlgorithm;
using MLTrainer.TrainingAlgorithms.OnlineGradientDescentAlgorithm;
using MLTrainer.TrainingAlgorithms.FastTreeAlgorithm;
using System.Collections.Generic;
namespace MLTrainer.TrainingAlgorithms
{
    internal static class MLTrainingAlgorithmFactory
    {

        internal static IEnumerable<IMLTrainingAlgorithm> GetAllAlgorithms()
        {
            yield return new OneVersusAll();
            yield return new LbfgsMaxEntropy();
            yield return new OnlineGradientDescent();
            yield return new LbfgsPoisson();
            yield return new LightGbm();
            yield return new FastTree();
        }
    }
}
