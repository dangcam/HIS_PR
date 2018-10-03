using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    public class AssociationRule
    {
        #region Properties

        public Itemset X { get; set; }
        public Itemset Y { get; set; }
        public double Support { get; set; }
        public double Confidence { get; set; }

        #endregion

        #region Constructors

        public AssociationRule()
        {
            X = new Itemset();
            Y = new Itemset();
            Support = 0.0;
            Confidence = 0.0;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return (X + " => " + Y + " (support: " + Math.Round(Support, 2) + "%, confidence: " + Math.Round(Confidence, 2) + "%)");
        }

        #endregion
    }
}
