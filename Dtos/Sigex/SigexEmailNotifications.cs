namespace ASDP.FinalProject.Dtos.Sigex
{
    public class SigexEmailNotifications
    {
        public List<string> to { get; set; } = new();
        public bool doNotAttachDocument { get; set; } = false;
    }
}
