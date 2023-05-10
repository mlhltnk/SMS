﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Response;
using Business.ValidationRules;
using Core.Aspects.Validation;
using Core.Paging;
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concreate;

public class InstructorManager : IInstructorService
{
    private IInstructorDal instructorDal;
    private IMapper mapper;

    


    [ValidationAspect(typeof(CreateInstructorRequestValidator))]
    public async Task Add(CreateInstructorRequest createInstructorRequest)
    {
      Instructor instructor = mapper.Map<Instructor>(createInstructorRequest);
        await instructorDal.AddAsync(instructor);
    }

    public async Task<GetListResponse<InstructorResponse>> GetAll(PageRequests pageRequests)
    {
        IPaginate<Instructor> result = await instructorDal.GetListAsync(index:pageRequests.Index, size:pageRequests.Size);

        return mapper.Map<GetListResponse<InstructorResponse>>(result);

    }
}
