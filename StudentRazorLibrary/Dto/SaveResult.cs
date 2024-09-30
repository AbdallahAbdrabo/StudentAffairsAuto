using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students.Client.Dto;

public class SaveResult
{
    public bool IsSuccess { get; set; }
    public StudentDTO? Student { get; set; }
}
