using System;
using construct.Models;
using construct.Services;
using Microsoft.AspNetCore.Mvc;

namespace construct.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ContractorJobsController : ControllerBase
  {
    private readonly ContractorJobsService _contractorJobsService;

    public ContractorJobsController(ContractorJobsService contractorJobsService)
    {
      _contractorJobsService = contractorJobsService;
    }

    [HttpPost]

    public ActionResult<ContractorJobs> CreateContractorJobs([FromBody] ContractorJobs cj)
    {
      try
      {
        ContractorJobs newJob = _contractorJobsService.CreateContractorJobs(cj);
        return Ok(newJob);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{id}")]

    public ActionResult<ContractorJobs> UpdateContractorJobs([FromBody] ContractorJobs cj)
    {
      try
      {
        ContractorJobs update = _contractorJobsService.UpdateContractorJobs(cj);
        return Ok(update);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }

}