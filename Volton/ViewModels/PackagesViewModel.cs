using System.Collections.Generic;

namespace Volton.ViewModels
{
    public class PackagesViewModel
    {
        public int? SelectedPackageId { get; set; }
        public List<Package> Packages { get; set; } = new List<Package>();
    }

    public class Package
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
} 