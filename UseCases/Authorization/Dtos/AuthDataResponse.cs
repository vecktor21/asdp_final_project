namespace ASDP.FinalProject.UseCases.Authorization.Dtos
{
    public class AuthDataResponse
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
        public string Token { get; set; }
    }
}
