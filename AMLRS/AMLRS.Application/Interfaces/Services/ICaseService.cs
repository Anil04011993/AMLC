using AMLRS.Application.DTOs;
using AMLRS.Core.QueryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace AMLRS.Application.Interfaces.Services
{
    public interface ICaseService
    {
        public Task<IReadOnlyList<EntityDataDto>> GetAllCasesAsync(CaseQueryParams query);
    }
}
