﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EEMS.BusinessLogic.DTOs;

public class EmployeeDTO
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string JobTitle { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public bool IsActive { get; set; }
}
