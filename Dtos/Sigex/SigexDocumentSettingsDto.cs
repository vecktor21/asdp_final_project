namespace ASDP.FinalProject.Dtos.Sigex
{
    public class SigexDocumentSettingsDto
    {
        public bool @private { get; set; }
        public int signaturesLimit { get; set; }
        public bool switchToPrivateAfterLimitReached { get; set; } = false;
        public List<string> unique { get; set; }
        public bool strictSignersRequirements { get; set; }
        public bool sequentialSignersRequirements { get; set; } = false;
        public List<SigexSignersRequirementsDto> signersRequirements { get; set; } = new();
        public bool publicDuringPreregistration { get; set; } = false;
        public List<SigexDocumentAccessDto> documentAccess { get; set; } = new();
        public bool forceArchive { get; set; } = true;
    }

    public class SigexSignersRequirementsDto
    {
        public string iin { get; set; }
        public string bin { get; set; }
        public string cas { get; set; } /*= "nca";*/

    }

    public class SigexDocumentAccessDto
    {
        public string iin { get; set; }
        public string bin { get; set; }

    }
}
