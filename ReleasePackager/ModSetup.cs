using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ReleasePackager
{
    [DataContract]
    public class ModSetupCollection
    {
        [DataMember]
        public List<ModSetup> ModSetups { get; set; }
    }

    [DataContract]
    public class ModSetup
    {
        [DataMember]
        public string ModName { get; set; }

        [DataMember]
        public int MainEspIndex { get; set; }

        [DataMember]
        public string ZipName { get; set; }

        [DataMember]
        public string SourcePath { get; set; }

        [DataMember]
        public string OutputPath { get; set; }
    }
}
