using Synapse.Config;
using System.ComponentModel;

namespace ClearItem
{
    public class Config : AbstractConfigSection
    {
        [Description("The time before an item on the ground despawns in seconde")]
        public int TimeBeforeDespawn { get; set; } = 300;
        
    }
}
