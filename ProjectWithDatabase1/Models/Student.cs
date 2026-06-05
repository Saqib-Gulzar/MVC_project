using System;
using System.Collections.Generic;

namespace ProjectWithDatabase1.Models;

public partial class Student
{
    public int Roll { get; set; }

    public string? StudentName { get; set; }

    public DateOnly? StudentDob { get; set; }

    public string? StudentGender { get; set; }
}
