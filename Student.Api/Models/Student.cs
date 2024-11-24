using System.Runtime.InteropServices;
using System;

namespace Student.Api {
    public class Student{
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;// git update check
    }
}