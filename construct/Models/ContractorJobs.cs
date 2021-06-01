using System.ComponentModel.DataAnnotations;

namespace construct.Models
{
  public class ContractorJobs
  {
    public int Id { get; set; }
    [Required]

    public int JobId { get; set; }
    [Required]

    public int ContractorId { get; set; }

  }
  public class ContractorJobsViewModel : Job
  {
    public string Location { get; set; }
    public int ContractorId { get; set; }
    public int JobId { get; set; }
    public int ContractorJobsId { get; set; }

  }
}