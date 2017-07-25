using Microsoft.TeamFoundation.WorkItemTracking.WebApi.Models;
using System.Collections.Generic;

namespace TFS_WebApi.Models
{
    public class WorkObj
    {
        private WorkItem _item;
        public WorkItem item
        {
            get
            {
                _item.Fields = null;
                _item.Relations = null;
                _item.Links = null;
                return _item;
            }
            set
            {
                _item = value;
            }
        }

        public List<WorkObj> children { get; set; }

        public WorkObj(WorkItem item)
        {
            this.item = item;
            children = new List<WorkObj>();
        }
    }
}