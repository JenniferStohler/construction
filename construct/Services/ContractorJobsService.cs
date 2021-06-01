using System;
using construct.Models;
using construct.Repositories;

namespace construct.Services
{
  public class ContractorJobsService
  {
    private readonly ContractorJobsRepository _contractorJobsRepo;
    public ContractorJobsService(ContractorsRepository contractorsRepo, ContractorJobsRepository contractorJobsRepo)
    {
      _contractorJobsRepo = contractorJobsRepo;
    }

    public ContractorJobs CreateContractorJobs(ContractorJobs cj)
    {
      return _contractorJobsRepo.Create(cj);
    }

    internal ContractorJobs UpdateContractorJobs(ContractorJobs cj)
    {
      throw new NotImplementedException();
    }
  }
}