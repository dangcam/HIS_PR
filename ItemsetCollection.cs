﻿using System;

public class ItemsetCollection : List<Itemset>
{
    #region Methods

    public Itemset GetUniqueItems()
    {
        Itemset unique = new Itemset();

        foreach (Itemset itemset in this)
        {
            unique.AddRange(from item in itemset
                            where !unique.Contains(item)
                            select item);
        }

        return (unique);
    }
    public int FindIndex(int item)
    {
        for (int i = 0; i < this.Count; i++)
        {
            if (this[i].Contains(item))
                return i;
        }
        return -1;
    }

    public double FindSupport(int item)
    {
        int matchCount = (from itemset in this
                          where itemset.Contains(item)
                          select itemset).Count();

        double support = ((double)matchCount / (double)this.Count) * 100.0;
        return (support);
    }

    public double FindSupport(Itemset itemset)
    {
        int matchCount = (from i in this
                          where i.Contains(itemset)
                          select i).Count();

        double support = ((double)matchCount / (double)this.Count) * 100.0;
        return (support);
    }
    public double Support(Itemset itemset)
    {
        double support = ((double)itemset.Support / (double)this.Count) * 100.0;
        return (support);
    }

    public override string ToString()
    {
        return (string.Join("\r\n", (from itemset in this select itemset.ToString()).ToArray()));
    }

    #endregion
}