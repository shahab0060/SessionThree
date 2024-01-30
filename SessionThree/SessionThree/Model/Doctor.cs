using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;

namespace SessionThree.Model
{
    public class Doctor
    {
        public long DoctorId { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }

        public string Major { get; set; }

        public string Address { get; set; }
    }
}
