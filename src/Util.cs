//  Authors:  Robert M. Scheller, Jimm Domingo

using Landis.Library.UniversalCohorts;
using Landis.SpatialModeling;
using Landis.Core;

namespace Landis.Extension.Output.BiomassReclass
{
    /// <summary>
    /// Methods for computing biomass for groups of cohorts.
    /// </summary>
    public static class Util
    {
        public static int ComputeBiomass(Site site, ISpecies species)
        {
            ISpeciesCohorts cohorts = (Landis.Library.UniversalCohorts.ISpeciesCohorts) SiteVars.Cohorts[site][species];
            int total = 0;
            if (cohorts != null)
                foreach (ICohort cohort in cohorts)
                    total += cohort.Data.Biomass;
            return total;
        }

        //---------------------------------------------------------------------

        public static int ComputeBiomass(Site site)
        {
            ISiteCohorts cohorts = (Landis.Library.UniversalCohorts.ISiteCohorts) SiteVars.Cohorts[site];
            int total = 0;
            if (cohorts != null)
                foreach (ISpeciesCohorts speciesCohorts in cohorts)
                    total += ComputeBiomass(site, speciesCohorts.Species);
            return total;
        }
    }
}
