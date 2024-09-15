//  Authors:  Robert M. Scheller, Jimm Domingo

using Landis.Core;
using Landis.SpatialModeling;
using Landis.Library.UniversalCohorts;

namespace Landis.Extension.Output.BiomassReclass
{
    public static class SiteVars
    {
        private static ISiteVar<SiteCohorts> cohorts;
        private static ISiteVar<string> forestType;

        //---------------------------------------------------------------------

        public static void Initialize()
        {
            cohorts = PlugIn.ModelCore.GetSiteVar<SiteCohorts>("Succession.UniversalCohorts");
            forestType = PlugIn.ModelCore.Landscape.NewSiteVar<string>();
            PlugIn.ModelCore.RegisterSiteVar(SiteVars.ForestType, "Output.ForestType");

            if (cohorts == null)
            {
                string mesg = string.Format("Cohorts are empty.  Please double-check that this extension is compatible with your chosen succession extension.");
                throw new System.ApplicationException(mesg);
            }
        }

        //---------------------------------------------------------------------
        public static ISiteVar<string> ForestType
        {
            get
            {
                return forestType;
            }
        }
        //---------------------------------------------------------------------
        public static ISiteVar<SiteCohorts> Cohorts
        {
            get
            {
                return cohorts;
            }
        }
    }
}
