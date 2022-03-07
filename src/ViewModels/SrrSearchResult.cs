using System;

namespace srrapi.ViewModels
{
    public class SrrSearchResult
    {
        public string ReleaseName { get; set; }

        public DateTime UploadedAt { get; set; }

        public int HasNfo { get; set; }

        public int HasSrs { get; set; }
    }
}
