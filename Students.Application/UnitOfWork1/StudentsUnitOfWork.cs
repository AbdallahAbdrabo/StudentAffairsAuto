﻿using AutoMapper;
using Students.Application.Model;
using Students.Application.Repository1;

namespace Students.Application.UnitOfWork1;

public class StudentsUnitOfWork : UnitOfWork<Student, StudentDTO>, IStudentsUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IStudentsRepository _studentsRepository;
    public StudentsUnitOfWork(ApplicationDbContext context, IStudentsRepository studentsRepository, IMapper mapper) : base(context, studentsRepository ,mapper)
    {
        _context = context;
        _studentsRepository = studentsRepository;
    }


}

