﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JS.Base.WS.API.DTO.Response.Domain
{
    public class AppointmentStatusDTO
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string Description { get; set; }
    }
}