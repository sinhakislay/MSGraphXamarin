using System;
using System.Collections.Generic;
using System.Text;

namespace MSGraphXamarin.Models
{
    public enum MenuItemType
    {
        Welcome,
        Calendar,
        NewEvent
    }

    public class NavMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
