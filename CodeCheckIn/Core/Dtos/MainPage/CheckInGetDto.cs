namespace CodeCheckIn.Core.Dtos.MainPage
{
    public class CheckInGetDto
    {
        public int CodeId { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public string Synopsis { get; set; }
        public string Description { get; set; }
        public string ImpactAnalysis { get; set; }
        public string DeploymentDocument { get; set; }
        public string UnitTest { get; set; }
        public string FilesAdded { get; set; }
        public string FilesModified { get; set; }
        public string FilesDeleted { get; set; }
        public string GitBranch { get; set; }
        public string GitRevision { get; set; }
        public string PullRequest { get; set; }
        public string CodeReviewedBy { get; set; }
        public string TargetVersion { get; set; }
        public string SpecificationDoc { get; set; }
        public string TechnicalDoc { get; set; }
        public string Scenarios { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
