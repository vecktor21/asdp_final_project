namespace ASDP.FinalProject.DAL.Models
{
    public class SignerToPipeline
    {
        public int Id { get; protected set; }
        public int Order { get; protected set; }
        public Guid SignPipelineId { get; protected set; }
        public SignPipeline SignPipeline { get; protected set; }
        public int SignerEmployeeId { get; protected set; }
        public Employee SignerEmployee { get; protected set; }
        public bool IsSigned { get; protected set; }

        public SignerToPipeline() { }

        public SignerToPipeline(Employee employee, int order, SignPipeline signPipeline)
        {
            this.Order = order;
            this.SignerEmployee = employee;
            this.SignerEmployeeId = employee.Id;
            this.SignPipelineId = signPipeline.Id;
            this.SignPipeline= signPipeline;
            this.IsSigned = false;
        }

        public void Sign()
        {
            this.IsSigned= true;
        }
    }
}
