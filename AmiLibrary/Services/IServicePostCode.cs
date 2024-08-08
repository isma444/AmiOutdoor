﻿using AmiLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmiLibrary.Services
{
    public interface IServicePostCode
    {
        Task<PostCodeData> GetPostCodeData(string cityName);
    }
}