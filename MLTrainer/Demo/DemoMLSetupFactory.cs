using MLTrainer.DataSetup;
using MLTrainer.Demo.IrisPrediction;
using MLTrainer.RuntimeTrainingSetup.DynamicObjectSetup;
using MLTrainerTests.MicroGasTurbineElectricalEnergyPrediction;
using MLTrainerTests.TaxiFare;
using System.Collections.Generic;

namespace MLTrainer.Demo
{
    internal class DemoMLSetupFactory : IFunctionalitySpecificMLSetupFactory
    {
        public IEnumerable<IFunctionalitySpecificMLSetupItem> GetAvailableSetupItems()
        {
            yield return new ElectricalEnergySetupItem();
            yield return new IrisClassificationSetupItem();
            yield return new JsonObjectMLSetupItem();
            yield return new TaxiFareSetupItem();
        }
    }
}
