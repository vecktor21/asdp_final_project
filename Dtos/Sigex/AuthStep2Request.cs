namespace ASDP.FinalProject.Dtos.Sigex
{
    public class SigexAuthStep2Request
    {
        public string Nonce { get; set; }
        public string Signature { get; set; }
        public bool External { get; set; } = false;
    }

    public class SigexAuthDataResponse: SigexResponse
    {
        public string? UserId { get; set; }
        public string? BusinessId { get; set; }
        public string? Email { get; set; }
        public string Subjects { get; set; }
        //public List<SubjectStructureDto> SubjectStructure { get; set; }
        public string? SubjectAltName { get; set; }
        //public List<SubjectAltNameStructureDto> SubjectAltNameStructure { get; set; }
        public string SignAlgorithm { get; set; }
        public string KeyStorage { get; set; }
        public List<string> PolicyIds { get; set; }
        public List<string> ExtKeyUsages { get; set; }
    }

    public class SubjectStructureDto
    {
        public string Oid { get; set; }
        public string Name { get; set; }
        public bool ValueInB64 { get; set; }
        public string Value { get; set; }
    }

    public class SubjectAltNameStructureDto
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
