using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMining
{
    public class Itemset : List<int>
    {
        #region Properties

        public double Support { get; set; }

        #endregion

        #region Methods

        public bool Contains(Itemset itemset)
        {
            return (this.Intersect(itemset).Count() == itemset.Count);
        }
        public Itemset Remove(Itemset itemset)
        {
            Itemset removed = new Itemset();
            removed.AddRange(from item in this
                             where !itemset.Contains(item)
                             select item);
            return (removed);
        }

        public override string ToString()
        {
            return ("{" + string.Join(", ", this.ToArray()) + "}" + (this.Support > 0 ? " (support: " + Math.Round(this.Support, 2) + "%)" : string.Empty));
        }

        #endregion
    }
}
