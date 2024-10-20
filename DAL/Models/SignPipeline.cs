using ASDP.FinalProject.Constants;

namespace ASDP.FinalProject.DAL.Models
{
    public class SignPipeline
    {
        public Guid Id { get; protected set; }
        public int CreatorEmployeeId { get; protected set; }
        public Employee CreatorEmployee { get; protected set; }
        public SignPipelineStatus Status { get; protected set; }
        public Guid SignDocumentId { get; protected set; }
        public SignDocument SignDocument { get; protected set; }
        public List<SignerToPipeline> Signers { get; protected set; }
        public long SigexSignId { get; protected set; }

        public SignPipeline(Employee creator, long sigexSignId, byte[] content, string signDocumentName, string sigexDocumentId)
        {
            this.Id = Guid.NewGuid();
            this.CreatorEmployee = creator;
            this.CreatorEmployeeId = creator.Id;
            this.Status = SignPipelineStatus.Created;
            this.SigexSignId = sigexSignId;

            var signDocument = new SignDocument(content, signDocumentName, this, sigexDocumentId);
            
            this.SignDocument = signDocument;
            this.SignDocumentId = signDocument.Id;
            this.Signers = new();
            
        }
        public SignPipeline() { }

        public void AddSigner(Employee signer, int order)
        {
            SignerToPipeline signerToPipeline = new SignerToPipeline(signer, order, this);
            this.Signers.Add(signerToPipeline);
        }
    }
}
