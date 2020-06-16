using System;

namespace Client.Models
{
    public class HttpResponseError
    {
        public string Type { get; set; }

        public string Title { get; set; }

        public int Status { get; set; }

        public string TraceId { get; set; }

        public Errors Errors { get; set; }
    }

    public class Errors
    {
        public string[] Email { get; set; }

        public string[] Password { get; set; }

        public string[] Username { get; set; }

        public string[] DisplayName { get; set; }
    }
}