﻿using System;
using System.Collections.Generic;

namespace APIEmpreGO.Models
{
    public partial class Administrador
    {
        public int IdAdministrador { get; set; }
        public int? IdUsuario { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}