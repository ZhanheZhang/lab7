using lab7.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab7.ViewModels
{
    // StudentIndexViewModel.cs
    public class StudentIndexViewModel
    {
        public IPagedList<Student> Students { get; set; }

        //public IEnumerable<Student> Students { get; set; }
        public string Search { get; set; }
        public string Campus { get; set; }
        public IEnumerable<CampusWithCount> CampusesWithCount { get; set; }
        public IEnumerable<SelectListItem> CampusFilterItems
        {
            get
            {
                var allCampuses = CampusesWithCount.Select(c => new SelectListItem
                {
                    Value = c.CampusName,
                    Text = c.CampusNameWithCount
                });
                return allCampuses;
            }
        }
    }
}

    public class CampusWithCount
    {
        public string CampusName { get; set; }
        public int StudentCount { get; set; }
        public string CampusNameWithCount
        {
            get { return CampusName + " (" + StudentCount + "person)"; }
        }
    }
