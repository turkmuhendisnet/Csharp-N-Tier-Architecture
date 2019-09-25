using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Service.DTO;

namespace Service
{
  public  class PersonelService : IPersonelService
    {
        Baglanti bag = new Baglanti();

        Command cmd = new Command();


        
        public void delete(string sqlCumlesi)
        {
            SqlCommand cmd1 = cmd.sqlcommand(sqlCumlesi);
            cmd1.ExecuteNonQuery();
            bag.BaglantiKapat();

            throw new NotImplementedException();
        }

        public int insert(string sqlCumlesi)
        {
            SqlCommand cmd1 = cmd.sqlcommand(sqlCumlesi);
            cmd1.ExecuteNonQuery();
            bag.BaglantiKapat();


            throw new NotImplementedException();
        }

        public void update(string sqlCumlesi)
        {
            SqlCommand cmd1 = cmd.sqlcommand(sqlCumlesi);
            cmd1.ExecuteNonQuery();
            bag.BaglantiKapat();

            throw new NotImplementedException();
        }

        public List<PersonelDTO> PersonelListesi(string sqlCumlesi)
        {
            SqlCommand cmd1 = cmd.sqlcommand(sqlCumlesi);
            bag.BaglantiAc();
            SqlDataReader dr = cmd1.ExecuteReader();

            List<PersonelDTO> pdto = new List<PersonelDTO>();
           
            while(dr.Read())
            {
                pdto.Add(new PersonelDTO
                {

                    Id=Convert.ToInt32( dr["Id"]),
                    Adi = dr["Adi"].ToString(),
                    Soyadi=dr["Soyadi"].ToString(),
                    KayitTarihi=Convert.ToDateTime( dr["KayitTarihi"].ToString()),
                
                } );
            }
            bag.BaglantiKapat();
            return pdto;

        }
    }
}
