using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ReleasePackager
{
    [DataContract]
    public class ConfigCollection
    {
        [DataMember]
        public List<GameSetup> GameSetups { get; set; }

        [DataMember]
        public List<ModSetup> ModSetups { get; set; }
    }

    [DataContract]
    public class GameSetup
    {
        [DataMember]
        public string GameName { get; set; }

        [DataMember]
        public string GamePath { get; set; }

        [DataMember]
        public string ArchiverPath { get; set; }

        [DataMember]
        public string OutputPath { get; set; }
    }

    [DataContract]
    public class ModSetup
    {
        [DataMember]
        public string GameName { get; set; }

        [DataMember]
        public string ModName { get; set; }

        [DataMember]
        public int MainEspIndex { get; set; }

        [DataMember]
        public string ZipName { get; set; }

        [DataMember]
        public string SourcePath { get; set; }
    }
}
