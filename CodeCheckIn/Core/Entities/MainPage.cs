using System.ComponentModel.DataAnnotations;

namespace CodeCheckIn.Core.Entities
{
    public class MainPage
    {
        [Key]
        public int CodeId { get; set; }
        public string Subject { get; set; }
        public string From { get; set; }
        public List<Receiver> SendTo { get; set; }
        public string Synopsis { get; set; }
        public string Description { get; set; }
        public string ImpactAnalysis { get; set; }
        public List<FilesURL> DeploymentDocument { get; set; }
        public string UnitTest { get; set; }
        public string FilesAdded { get; set; }
        public string FilesModified { get; set; }
        public string FilesDeleted { get; set; }
        public string GitBranch { get; set; }
        public string GitRevision { get; set; }
        public string PullRequest { get; set; }
        public string CodeReviewedBy { get; set; }
        public string TargetVersion { get; set; }
        public List<FilesURL> SpecificationDoc { get; set; }
        public List<FilesURL> TechnicalDoc { get; set; }
        public List<FilesURL> Scenarios { get; set; }
        public string Notes { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //Relations

    }

}

