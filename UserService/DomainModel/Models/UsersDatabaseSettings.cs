﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Models
{
    public class UsersDatabaseSettings : IUsersDatabaseSettings
    {
        public string UsersCollectionName { get; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }

    public interface IUsersDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string UsersCollectionName { get; set; }
    }
}
