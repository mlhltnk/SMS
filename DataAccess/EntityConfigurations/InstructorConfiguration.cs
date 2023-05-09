﻿using Entities.Concreate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityConfigurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructor").HasKey(u=> u.Id);
        builder.Property(u => u.Id).HasColumnName("Id").IsRequired();
        builder.Property(u => u.Pbik).HasColumnName("Pbik").IsRequired();
        builder.Property(u => u.NationalityId).HasColumnName("NationalityId");
        builder.Property(u => u.Firstname).HasColumnName("Firstname").IsRequired();
        builder.Property(u => u.Lastname).HasColumnName("Lastname").IsRequired();
        builder.Property(u => u.BirthDate).HasColumnName("BirthDate").IsRequired();
        builder.Property(u => u.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(u => u.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(u => u.DeletedDate).HasColumnName("DeletedDate");
        builder.Property(u => u.Status).HasColumnName("Status").IsRequired();

        
        builder.HasQueryFilter(u => !u.DeletedDate.HasValue);

    }
}
