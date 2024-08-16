using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.view
{
    public class SearchBar(IList<string> allEntries)
    {
        private readonly IList<string> allEntries = allEntries;
        private IList<string> filteredEntries = allEntries;

        public void FilterEntries(string filter)
        {
            this.filteredEntries = this.allEntries.Where(entry => entry.Contains(filter.ToLower())).ToList();
        }

        public IList<string> GetFilteredEntries()
        {
            return this.filteredEntries;
        }
    }
}
