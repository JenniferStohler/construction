using System.Collections.Generic;
using System.Data;
using System.Linq;
using construct.Models;
using Dapper;

namespace construct.Repositories
{
  public class ContractorJobsRepository
  {
    private readonly IDbConnection _db;
    public ContractorJobsRepository(IDbConnection db)
    {
      _db = db;
    }

    public ContractorJobs Create(ContractorJobs cj)
    {
      string sql = @"INSERT INTO
 contractor_jobs(contractorId, jobId)
            VALUES (@WContractorId, @JobId);
            SELECT LAST_INSERT_ID();
            ";
      cj.Id = _db.ExecuteScalar<int>(sql, cj);
      return cj;
    }

    internal List<ContractorJobsViewModel> GetJobByContractorId(int contractorId)
    {
      string sql = @"
                SELECT
                j.*,
                c.location,
                cj.id as contractorJobId,
                cj.jobId as jobId,
                cj.contractorId as contractorId
                FROM
                contractor_jobs cj
                JOIN contractors c ON c.id = cj.contractorId
                JOIN jobs j ON j.id = cj.jobId
                WHERE
                cj.contractorId = @contractorId;
            ";
      return _db.Query<ContractorJobsViewModel>(sql, new { contractorId }).ToList();
    }
  }
}