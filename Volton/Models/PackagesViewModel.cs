using System.Collections.Generic;

namespace Volton.Models
{
    public class PackagesViewModel
    {
        public string? SelectedPackage { get; set; }
        public List<Package> Packages { get; set; } = new List<Package>();
    }

    public class Package
    {
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
} 