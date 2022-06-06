using Quanlicaan.Models.ShowModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Quanlicaan.Models.View
{
    public class ModelViews
    {
        public PagedList.IPagedList<ReportsPerDay> rp { get; set; }

        public IEnumerable<ReportsPerDay> rp2 { get; set; }
    }
}