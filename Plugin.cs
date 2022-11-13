using Synapse.Api.Plugin;

namespace ClearItem
{
    [Synapse.Api.Plugin.PluginInformation(
           Author = "VT",
           Description = "Remove items from the floor",
           Name = "ClearItem",
           SynapseMajor = SynapseController.SynapseMajor,
           SynapseMinor = SynapseController.SynapseMinor,
           SynapsePatch = SynapseController.SynapsePatch,
           Version = "v.1.0.0"
           )]
    public class Plugin : AbstractPlugin
    {
        public static Plugin Instance { get; set; }

        [Synapse.Api.Plugin.Config(section = "ClearItem")]
        public Config Config { get; set; }

        public EventHandler EventHandler { get; set;}

        public override void Load()
        {
            new EventHandler();
            Instance = this;


        }

    }
}