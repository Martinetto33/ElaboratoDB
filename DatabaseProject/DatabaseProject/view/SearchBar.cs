using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseProject.view
{
    // Could be made generic, by passing a filtering method
    public class SearchBar<T>(IList<T> allEntries)
    {
        private readonly IList<T> allEntries = allEntries;
        private IList<T> filteredEntries = allEntries;

        public void FilterEntries(Predicate<T> predicate)
        {
            //this.filteredEntries = this.allEntries.Where(entry => entry.Contains(filter.ToLower())).ToList();
            this.filteredEntries = this.allEntries.Where(entry => predicate.Invoke(entry)).ToList();
        }

        public IList<T> GetFilteredEntries()
        {
            return this.filteredEntries;
        }
    }
}
