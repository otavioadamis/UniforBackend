using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniforBackend.Domain.Models.DTOs.S3TOs
{
    public class AwsCredentials
    {
        public string AwsKey { get; set; } = string.Empty;
        public string AwsSecret { get; set; } = null!;
    }
}
