﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SmartMaintenanceApp.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Login
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
