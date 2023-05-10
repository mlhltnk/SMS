﻿using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("BaseDb")
            ));

        services.AddScoped<IstudentDal, EfStudentDal>()
            .AddScoped<IInstructorDal, EfInstructorDal>()
            .AddScoped<ICourseDal, EfCourseDal>();

        return services;
    }
}
