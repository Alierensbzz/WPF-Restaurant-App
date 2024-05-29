using RestaurantApp.VarlikKatmani.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantApp.VarlikKatmani.Models
{
    [Table("tblKategori")]
    public class Kategori : BaseEntity
    {
        public string Ad { get; set; }


    }
}
