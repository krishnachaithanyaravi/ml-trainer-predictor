using Microsoft.ML.Data;
using MLTrainer;

namespace MLTrainerTests.TaxiFare
{

    public class TaxiFareOutput
    {
        [ColumnName(@"Score")]
        [ColumnNameStorage(@"Score", typeof(float), true)]
        public float Score { get; set; }
    }
}
