﻿using Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IPersonelService
    {
        int insert(string sqlCumlesi);
        void delete(string sqlCumlesi);
        void update(string sqlCumlesi);

        List<PersonelDTO> PersonelListesi(string sqlCumlesi);
    }
}
